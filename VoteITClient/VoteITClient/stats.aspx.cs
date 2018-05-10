using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class stats : System.Web.UI.Page
    {
        int qid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SKEY"] != null)
            {
                qid = Convert.ToInt32(Request.QueryString["qid"]);
                if (!IsPostBack)
                {
                    BindQuestion(qid);
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }

        public void BindQuestion(int questionID)
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            DataSet ds = vClient.GetResult(questionID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                questionContent.InnerText = ds.Tables[0].Rows[0]["QUESTION"].ToString();
                userContent.InnerText = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                categoryContent.InnerText = ds.Tables[0].Rows[0]["CATEGORY"].ToString();

                stronglyAgree.InnerText = ds.Tables[0].Select("ANSWER_ID = 5").Length > 0 ? ds.Tables[0].Select("ANSWER_ID = 5").Length.ToString() : "0";
                agree.InnerText = ds.Tables[0].Select("ANSWER_ID = 4").Length > 0 ? ds.Tables[0].Select("ANSWER_ID = 4").Length.ToString() : "0";
                nietherAgreeNorDisagree.InnerText = ds.Tables[0].Select("ANSWER_ID = 3").Length > 0 ? ds.Tables[0].Select("ANSWER_ID = 3").Length.ToString() : "0";
                disagree.InnerText = ds.Tables[0].Select("ANSWER_ID = 2").Length > 0 ? ds.Tables[0].Select("ANSWER_ID = 2").Length.ToString() : "0";
                stronglyDisagree.InnerText = ds.Tables[0].Select("ANSWER_ID = 1").Length > 0 ? ds.Tables[0].Select("ANSWER_ID = 1").Length.ToString() : "0";
            }
            else
            {
                questionContent.InnerText = "";
                userContent.InnerText = "";
                categoryContent.InnerText = "";

                stronglyAgree.InnerText = "0";
                agree.InnerText = "0";
                nietherAgreeNorDisagree.InnerText = "0";
                disagree.InnerText = "0";
                stronglyAgree.InnerText = "0";
            }
        }


        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("result.aspx");
        }
    }
}