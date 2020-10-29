using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class ProduccionViewModel : SecurityViewModel
    {
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public float PrecioPremium { get; set; }
        [DataMember]
        public float PrecioEstandar { get; set; }
        [DataMember]
        public float PrecioLower { get; set; }
    }
}