using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasenia { get; set; }
        public String IsHabilitado { get; set; }
        public String Token { get; set; }
        public String NombreRol { get; set; }
        //public TipoUsuario TipoUsuario { get; set; }
        public Usuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdUsuario = 0;
            this.NombreUsuario = String.Empty;
            this.Contrasenia = String.Empty;
            this.IsHabilitado = "0";
            this.Token = String.Empty;
            this.NombreRol = String.Empty;
        }
    }
}
