using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class DetallePedidoModel
    {
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public int Cantidad { get; set; }
        [DataMember]
        public string Calidad { get; set; }
    }
}