using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SKEY"] != null)
            {
                BindGridView();
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void BindGridView()
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            DataSet ds = vClient.GetQuestion();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvQuestions.DataSource = ds.Tables[0];
                gvQuestions.DataBind();
            }
            else
            {
                gvQuestions.DataBind();
            }
        }

        protected void gvQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvQuestions.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void gvQuestions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Vote")
            {
                //To fetch row index
                int index = Convert.ToInt32(e.CommandArgument);
                //To fetch row data
                GridViewRow row = gvQuestions.Rows[index];

                int id = Convert.ToInt32(row.Cells[0].Text);
                //string title = row.Cells[1].Text; 
                Response.Redirect("response.aspx?qid=" + id);
            }
        }
    }
}