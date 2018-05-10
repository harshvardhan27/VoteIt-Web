using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BusinessObjects;
using System.Data.SqlClient;

namespace VoteITServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Vote" in both code and config file together.
    public class Vote : IVote
    {
        #region CATEGORY

        public DataSet GetCategory()
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM CATEGORY", con))
            {
                ds = new DataSet("category");
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        #endregion

        #region ANSWER

        public DataSet GetAnswers()
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM ANSWER", con))
            {
                ds = new DataSet("answer");
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        #endregion

        #region QUESTION

        public DataSet GetQuestion()
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM QUESTIONS_VW", con))
            {
                ds = new DataSet("question");
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        public int InsertQuestion(Question objQuestion)
        {
            int pkey = -1;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO QUESTION(NAME,CATEGORY_ID,DATE_CREATED,CREATED_BY,EXPIRED_FLAG) OUTPUT INSERTED.QUESTION_ID VALUES(@NAME,@CATEGORY_ID,@DATE_CREATED,@CREATED_BY,@EXPIRED_FLAG)", con))
            {
                cmd.Parameters.AddWithValue("@NAME", objQuestion.Name);
                cmd.Parameters.AddWithValue("@CATEGORY_ID", objQuestion.CategoryId);
                cmd.Parameters.AddWithValue("@DATE_CREATED", objQuestion.DateCreated);
                cmd.Parameters.AddWithValue("@CREATED_BY", objQuestion.CreatedBy);
                cmd.Parameters.AddWithValue("@EXPIRED_FLAG", objQuestion.ExpiredFlag);
                con.Open();
                pkey = Convert.ToInt32(cmd.ExecuteScalar());
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return pkey;


        }

        public DataSet GetQuestionDetails(int questionID)
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM QUESTIONS_VW WHERE QUESTION_ID=@QUESTION_ID", con))
            {
                ds = new DataSet("question");
                cmd.Parameters.AddWithValue("@QUESTION_ID", questionID);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        public DataSet GetQuestionByUser(int createdBy)
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM QUESTIONS_VW WHERE CREATED_BY=@CREATED_BY", con))
            {
                ds = new DataSet("question");
                cmd.Parameters.AddWithValue("@CREATED_BY", createdBy);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        #endregion

        #region ACCOUNT

        public int Login(Login objLogin)
        {
            int ID = 0;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM LOGIN WHERE EMAIL=@EMAIL AND PASSWORD=@PASSWORD", con))
            {
                DataSet ds = new DataSet("user");
                cmd.Parameters.AddWithValue("@EMAIL", objLogin.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", objLogin.Password);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if ((ds.Tables[0].Rows[0]["EMAIL"].ToString().ToLower() == objLogin.Email.ToLower()) && (ds.Tables[0].Rows[0]["PASSWORD"].ToString() == objLogin.Password))
                    {
                        ID = Convert.ToInt16(ds.Tables[0].Rows[0]["LOGIN_ID"]);
                    }
                }
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ID;
        }

        public int Register(Login objLogin)
        {
            int pkey = -1;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO LOGIN(EMAIL,PASSWORD,EXPIRED_FLAG) OUTPUT INSERTED.LOGIN_ID VALUES(@EMAIL,@PASSWORD,@EXPIRED_FLAG)", con))
            {
                cmd.Parameters.AddWithValue("@EMAIL", objLogin.Email);
                cmd.Parameters.AddWithValue("@PASSWORD", objLogin.Password);
                cmd.Parameters.AddWithValue("@EXPIRED_FLAG", objLogin.ExpiredFlag);
                con.Open();
                pkey = Convert.ToInt32(cmd.ExecuteScalar());
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return pkey;
        }

        #endregion

        #region RESULT

        public DataSet GetResult(int questionId)
        {
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM USER_RESULT_VW WHERE QUESTION_ID=@QUESTION_ID", con))
            {
                ds = new DataSet("result");
                cmd.Parameters.AddWithValue("@QUESTION_ID", questionId);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return ds;
        }

        public int InsertResponse(Result objResponse)
        {
            int ID = -1;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("INSERT INTO USER_RESULT(CATEGORY_ID,QUESTION_ID,ANSWER_ID,DATE_CREATED,CREATED_BY,VOTED_FLAG) OUTPUT INSERTED.USER_RESULT_ID VALUES(@CATEGORY_ID,@QUESTION_ID,@ANSWER_ID,@DATE_CREATED,@CREATED_BY,@VOTED_FLAG)", con))
            {
                cmd.Parameters.AddWithValue("@CATEGORY_ID", objResponse.CategoryID);
                cmd.Parameters.AddWithValue("@QUESTION_ID", objResponse.QuestionID);
                cmd.Parameters.AddWithValue("@ANSWER_ID", objResponse.AnswerID);
                cmd.Parameters.AddWithValue("@DATE_CREATED", objResponse.DateCreated);
                cmd.Parameters.AddWithValue("@CREATED_BY", objResponse.CreatedBy);
                cmd.Parameters.AddWithValue("@VOTED_FLAG", objResponse.VotedFlag);
                con.Open();
                ID = Convert.ToInt32(cmd.ExecuteScalar());
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    con.Close();
                }
            }
            return ID;
        }

        public bool Voted(int questionId, int createdBy)
        {
            bool userHasVoted = false;
            DataSet ds;
            SqlConnection con = GetConnection();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM USER_RESULT_VW WHERE QUESTION_ID=@QUESTION_ID AND CREATED_BY=@CREATED_BY", con))
            {
                ds = new DataSet("result");
                cmd.Parameters.AddWithValue("@QUESTION_ID", questionId);
                cmd.Parameters.AddWithValue("@CREATED_BY", createdBy);
                con.Open();
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["VOTED_FLAG"].ToString().ToUpper() == "Y")
                {
                    userHasVoted = true;
                }
                else
                {
                    userHasVoted = false;
                }
                if (con.State == ConnectionState.Open)
                {
                    cmd.Dispose();
                    adap.Dispose();
                    con.Close();
                }
            }
            return userHasVoted;
        }

        #endregion


        private SqlConnection GetConnection()
        {
            string connectionString = "Data Source=DESKTOP-D1B2PCM;Initial Catalog=VOTE_IT;Persist Security Info=True;User ID=sa;Password=hvs@123";
            return new SqlConnection(connectionString);
        }


    }
}
