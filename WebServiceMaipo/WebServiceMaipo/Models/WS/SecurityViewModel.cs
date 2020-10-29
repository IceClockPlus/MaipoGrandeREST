using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class SecurityViewModel
    {
        [DataMember]
        public string Token { get; set; }
    }
}