using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Web_Service
{
    [DataContract]
    public class wsLogin
    {
        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }
    }

    [DataContract]
    public class wsPassword
    {
        [DataMember]
        public string password { get; set; }
    }
}