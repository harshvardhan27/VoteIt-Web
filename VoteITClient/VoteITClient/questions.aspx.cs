using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class questions : System.Web.UI.Page
    {
        private static string strValidationFailedItem;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SKEY"] != null)
            {
                if (!IsPostBack)
                {
                    BindCateogry();
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ValidateData(out strValidationFailedItem, VT_Util.CRUDOperation.Insert))
            {
                VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
                VoteServiceReference.Question question = new VoteServiceReference.Question();
                question.CategoryId = Convert.ToInt16(ddlCategory.Value);
                question.Name = txtQuestion.InnerText;
                question.DateCreated = DateTime.Now;
                question.CreatedBy = Convert.ToInt16(Session["SKEY"]);
                question.ExpiredFlag = "N";
                int i = vClient.InsertQuestion(question);
                if (i > 0)
                {
                    Response.Redirect("dashboard.aspx");
                }
                else
                {
                    showMessage("Error", "Please provide correct input.", VT_Util.ReturnCode.Failure);
                    Clear();
                    ddlCategory.Focus();
                }
            }


        }

        public void BindCateogry()
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            DataSet ds = vClient.GetCategory();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlCategory.Items.Clear();
                ddlCategory.DataSource = ds.Tables[0];
                ddlCategory.DataTextField = "NAME";
                ddlCategory.DataValueField = "CATEGORY_ID";
                ddlCategory.DataBind();
            }
        }

        private void Clear()
        {
            ddlCategory.SelectedIndex = 0;
            txtQuestion.InnerText = "";
        }

        private bool ValidateData(out string strValidationFailedItem, VT_Util.CRUDOperation operation)
        {
            bool ValidationStatus = true;
            string strToReturn = string.Empty;

            if (operation == VT_Util.CRUDOperation.Insert || operation == VT_Util.CRUDOperation.Update)
            {
                strToReturn += (string.IsNullOrEmpty(ddlCategory.Value)) ? "Please select category. <br />" : "";
                strToReturn += (string.IsNullOrEmpty(txtQuestion.InnerText)) ? "Please enter question. <br />" : "";
            }

            ValidationStatus = (string.IsNullOrEmpty(strToReturn.Trim())) ? true : false;
            strValidationFailedItem = strToReturn;
            showMessage("Validation Error", strValidationFailedItem, VT_Util.ReturnCode.Failure);

            return ValidationStatus;
        }


        private void showMessage(string errorMessage_Head, string errorMessage_Body, string errorCode)
        {
            errorPanel.Visible = true;
            string successClass = "panel panel-success", errorClass = "panel panel-danger", warningClass = "panel panel-warning", finalClass = "";
            switch (errorCode)
            {
                case "00": finalClass = successClass; break;
                case "02": finalClass = errorClass; break;
                case "01": finalClass = warningClass; break;
                default: finalClass = successClass; break;
            }
            errorPanel.Attributes["class"] = finalClass;
            panelHead.InnerHtml = errorMessage_Head;
            panelContent.InnerHtml = errorMessage_Body;
        }
    }
}