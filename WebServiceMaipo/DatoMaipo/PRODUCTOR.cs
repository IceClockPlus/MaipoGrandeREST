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
    
    public partial class PRODUCTOR
    {
        public PRODUCTOR()
        {
            this.CONTRATO = new HashSet<CONTRATO>();
            this.OFERTAPRODUCTO = new HashSet<OFERTAPRODUCTO>();
        }
    
        public decimal IDPRODUCTOR { get; set; }
        public string NOMBREPRODUCTOR { get; set; }
        public string DIRECCIONPRODUCTOR { get; set; }
        public decimal IDUSUARIO { get; set; }
        public string TELEFONOPRODUCTRO { get; set; }
    
        public virtual ICollection<CONTRATO> CONTRATO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual ICollection<OFERTAPRODUCTO> OFERTAPRODUCTO { get; set; }
    }
}
