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
    
    public partial class PARTICIPACION
    {
        public decimal IDPARTICIPACION { get; set; }
        public decimal IDPRODUCTOR { get; set; }
        public decimal IDPEDIDO { get; set; }
        public string ESTADOPARTICIPACION { get; set; }
    
        public virtual PEDIDO PEDIDO { get; set; }
        public virtual PRODUCTOR PRODUCTOR { get; set; }
    }
}
