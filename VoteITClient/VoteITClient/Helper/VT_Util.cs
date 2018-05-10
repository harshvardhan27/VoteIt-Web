using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteITClient
{
    public class VT_Util
    {
        public sealed class ReturnMessage
        {
            public const string Success = "Success";
            public const string Failure = "Failure";
            public const string InsertSuccess = "Record(s) Created Successfully.";
            public const string InsertFailure = "Failed to Create Record(s).";
            public const string UpdateSuccess = "Record(s) Updated Successfully.";
            public const string UpdateFailure = "Failed to Update Record(s).";
            public const string DeleteSuccess = "Record(s) Deleted Successfully.";
            public const string DeleteFailure = "Failed to Delete Record(s).";
            public const string NoRecordFound = "No Record Found matching your search criteria.";
        }

        public sealed class ReturnCode
        {
            public const string Success = "00";
            public const string Warning = "01";
            public const string Failure = "02";
        }

        public enum CRUDOperation
        {
            Insert,
            Update,
            Delete,
            Select
        }
    }
}