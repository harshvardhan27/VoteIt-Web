using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [DataContract]
    public class Answer
    {
        [DataMember]
        public int AnswerID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ExpiredFlag { get; set; }
    }
}
