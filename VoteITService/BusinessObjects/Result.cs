using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [DataContract]
    public class Result
    {
        [DataMember]
        public int UserResultID { get; set; }

        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public int QuestionID { get; set; }

        [DataMember]
        public int AnswerID { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public string VotedFlag { get; set; }
    }
}
