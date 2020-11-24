using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class DocumentoVentaPatch
    {
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public Nullable<decimal> PrecioProducto { get; set; }
        [DataMember]
        public Nullable<decimal> PrecioTransporte { get; set; }
        [DataMember]
        public Nullable<decimal> Impuesto { get; set; }
        [DataMember]
        public Nullable<decimal> Subtotal { get; set; }
        [DataMember]
        public Nullable<decimal> Total { get; set; }
    }
}