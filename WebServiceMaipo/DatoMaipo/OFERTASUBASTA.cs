//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatoMaipo
{
    using System;
    using System.Collections.Generic;
    
    public partial class OFERTASUBASTA
    {
        public decimal IDOFERTA { get; set; }
        public decimal PRECIOOFERTA { get; set; }
        public string SELECCIONADO { get; set; }
        public System.DateTime FECHAOFERTA { get; set; }
        public decimal IDTRANSPORTISTA { get; set; }
        public decimal IDTIPOTRANSPORTE { get; set; }
        public decimal IDSUBASTA { get; set; }
    
        public virtual SUBASTA SUBASTA { get; set; }
        public virtual TRANSPORTISTA TRANSPORTISTA { get; set; }
        public virtual TIPOTRANSPORTE TIPOTRANSPORTE { get; set; }
    }
}
