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
    
    public partial class CLIENTE
    {
        public CLIENTE()
        {
            this.PEDIDO = new HashSet<PEDIDO>();
        }
    
        public decimal IDCLIENTE { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public string DIRECCIONCLIENTE { get; set; }
        public string TELEFONOCLIENTE { get; set; }
        public decimal IDUSUARIO { get; set; }
        public string CORREO { get; set; }
    
        public virtual ICollection<PEDIDO> PEDIDO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
    }
}
