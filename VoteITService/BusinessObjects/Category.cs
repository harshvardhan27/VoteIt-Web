using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    [DataContract]
    public class Category
    {
        [DataMember]
        public int CategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ExpiredFlag { get; set; }
    }
}
