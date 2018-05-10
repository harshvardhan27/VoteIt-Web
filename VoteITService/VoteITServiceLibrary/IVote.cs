using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace VoteITServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IVote" in both code and config file together.
    [ServiceContract]
    public interface IVote
    {

        #region QUESTION

        [OperationContract]
        DataSet GetQuestion();

        [OperationContract]
        DataSet GetQuestionByUser(int createdBy);

        [OperationContract]
        DataSet GetQuestionDetails(int questionID);

        [OperationContract]
        int InsertQuestion(Question objQuestion);

        #endregion

        #region ANSWER

        [OperationContract]
        DataSet GetAnswers();

        #endregion

        #region CATEGORY

        [OperationContract]
        DataSet GetCategory();

        #endregion

        #region RESULT

        [OperationContract]
        int InsertResponse(Result objQuestion);

        [OperationContract]
        DataSet GetResult(int questionId);

        [OperationContract]
        bool Voted(int questionId, int createdBy);

        #endregion

        #region ACCOUNT

        [OperationContract]
        int Login(Login objLogin);

        [OperationContract]
        int Register(Login objLogin);

        #endregion
    }
}
