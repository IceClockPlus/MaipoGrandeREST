using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebServiceMaipo.Models.WS
{
    [DataContract]
    public class OfertaSubastaModelView: SecurityViewModel
    {
        [DataMember]
        public int IdSubasta { get; set; }
        [DataMember]
        public float PrecioOferta { get; set; }
        [DataMember]
        public int IdTipoTransporte { get; set; }
    }
}