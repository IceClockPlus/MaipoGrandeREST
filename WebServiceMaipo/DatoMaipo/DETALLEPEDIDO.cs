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
    
    public partial class DETALLEPEDIDO
    {
        public decimal IDPEDIDO { get; set; }
        public decimal IDPRODUCTO { get; set; }
        public decimal CANTIDAD { get; set; }
        public string CALIDAD { get; set; }
        public decimal IDDETALLEPEDIDO { get; set; }
        public Nullable<decimal> IDPRODUCTOR { get; set; }
        public string ESTADO { get; set; }
        public Nullable<decimal> PRECIO { get; set; }
    
        public virtual PEDIDO PEDIDO { get; set; }
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
