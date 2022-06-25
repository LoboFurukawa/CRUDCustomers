using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WCFServiceHost.Models
{
    public class MaritalStatus
    {
        string description = string.Empty;

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
