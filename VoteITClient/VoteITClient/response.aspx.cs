using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VoteITClient
{
    public partial class response : System.Web.UI.Page
    {
        int qid = 0;
        int categoryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["SKEY"] != null)
            {

                qid = Convert.ToInt32(Request.QueryString["qid"]);
                Voted();
                BindQuestion(qid);
                if (!IsPostBack)
                {
                    BindAnswer();
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
            DataSet ds = vClient.GetQuestionDetails(questionID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                questionContent.InnerText = ds.Tables[0].Rows[0]["NAME"].ToString();
                userContent.InnerText = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                categoryContent.InnerText = ds.Tables[0].Rows[0]["CATEGORY"].ToString();
                categoryId = Convert.ToInt32(ds.Tables[0].Rows[0]["CATEGORY_ID"]);
            }
            else
            {
                questionContent.InnerText = "";
                userContent.InnerText = "";
                categoryContent.InnerText = "";
                categoryId = 0;
            }
        }

        public void BindAnswer()
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            DataSet ds = vClient.GetAnswers();
            if (ds.Tables[0].Rows.Count > 0)
            {
                rbAnswerList.DataSource = ds.Tables[0];
                rbAnswerList.DataTextField = "NAME";
                rbAnswerList.DataValueField = "ANSWER_ID";
                rbAnswerList.DataBind();
            }
            rbAnswerList.SelectedIndex = 2;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            VoteServiceReference.Result votingResult = new VoteServiceReference.Result();
            votingResult.CategoryID = categoryId;
            votingResult.QuestionID = qid;
            votingResult.AnswerID = Convert.ToInt32(rbAnswerList.SelectedValue);
            votingResult.DateCreated = DateTime.Now;
            votingResult.CreatedBy = Convert.ToInt32(Session["SKEY"]);
            votingResult.VotedFlag = "Y";
            int i = vClient.InsertResponse(votingResult);
            if (i > 0)
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }

        public void Voted()
        {
            VoteServiceReference.VoteClient vClient = new VoteServiceReference.VoteClient("BasicHttpBinding_IVote");
            bool response = vClient.Voted(Convert.ToInt32(Request.QueryString["qid"]), Convert.ToInt32(Session["SKEY"]));
            if (response == false)
            {
                infoPanel.Visible = false;
                panelHeadAlert.InnerText = "";
                panelContentAlert.InnerText = "";

                votePanel.Visible = true;
            }
            else
            {
                infoPanel.Visible = true;
                panelHeadAlert.InnerText = "Information..!!";
                panelContentAlert.InnerText = "Your response has been submitted..!! Thank you.!!";

                votePanel.Visible = false;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("dashboard.aspx");
        }
    }
}