using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [DataContract]
    public class Question
    {
        [DataMember]
        public int QuestionId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public string ExpiredFlag { get; set; }

        [DataMember]
        public DateTime DateExpired { get; set; }

        [DataMember]
        public int CreatedBy { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public int ModifiedBy { get; set; }

        [DataMember]
        public DateTime DateModified { get; set; }
    }
}
