using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class Usuario
    {

        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public string NombreUsuario { get; set; }
        [DataMember]
        public string Contrasenia { get; set; }
        [DataMember]
        public string IsHabilitado { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string NombreRol { get; set; }
        [DataMember]
        public TipoUsuario TipoUsuario { get; set; }
        [DataMember]
        public Pais Pais { get; set; }
        public Usuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdUsuario = 0;
            this.NombreUsuario = string.Empty;
            this.Contrasenia = string.Empty;
            this.IsHabilitado = "0";
            this.Token = string.Empty;
            this.Pais = new Pais();
            this.NombreRol = string.Empty;
        }
    }
}
