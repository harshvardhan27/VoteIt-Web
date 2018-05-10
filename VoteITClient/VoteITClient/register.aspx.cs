using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class register : System.Web.UI.Page
    {
        private static string strValidationFailedItem;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateData(out strValidationFailedItem, VT_Util.CRUDOperation.Insert))
            {
                VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
                VoteServiceReference.Login login = new VoteServiceReference.Login();
                login.Email = txtEmail.Text;
                login.Password = txtPassword.Text;
                login.ExpiredFlag = "N";
                int skey = vClient.Register(login);
                if (skey > 0)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    showMessage("Error", "Please provide correct username & password", VT_Util.ReturnCode.Failure);
                    Clear();
                    txtEmail.Focus();
                }
            }
        }

        private void Clear()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
        }

        private bool ValidateData(out string strValidationFailedItem, VT_Util.CRUDOperation operation)
        {
            bool ValidationStatus = true;
            string strToReturn = string.Empty;

            if (operation == VT_Util.CRUDOperation.Insert || operation == VT_Util.CRUDOperation.Update)
            {
                strToReturn += (string.IsNullOrEmpty(txtEmail.Text)) ? "Please enter email. <br />" : ((!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*")) ? "Username accepts only alphabetical characters. <br />" : "");
                strToReturn += (string.IsNullOrEmpty(txtPassword.Text)) ? "Please enter password. <br />" : ((!System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, "^[a-zA-Z0-9]+$")) ? "Password accepts only alphabetical & numeric characters. <br />" : "");
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