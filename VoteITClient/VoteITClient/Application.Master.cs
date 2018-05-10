using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class Application : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SKEY"] == null)
            {
                year.InnerText = DateTime.Now.Year.ToString();
                Response.Redirect("Login.aspx");
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("login.aspx");
        }
    }
}