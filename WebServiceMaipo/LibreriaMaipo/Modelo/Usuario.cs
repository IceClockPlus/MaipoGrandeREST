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
        /// <summary>
        /// Indica la id del usuario
        /// </summary>
        [DataMember]
        public int IdUsuario { get; set; }
        /// <summary>
        /// Indica el nombre de usuario
        /// </summary>
        [DataMember]
        public string NombreUsuario { get; set; }
        /// <summary>
        /// Indica la clave de acceso del usuario
        /// </summary>
        [DataMember]
        public string Contrasenia { get; set; }
        /// <summary>
        /// Indica si el usuario esta habilitado para usar su cuenta
        /// </summary>
        [DataMember]
        public string IsHabilitado { get; set; }
        /// <summary>
        /// Campo que tiene el token de acceso del usuario
        /// </summary>
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public string NombreRol { get; set; }
        /// <summary>
        /// Campo que define el rol asignado al usuario
        /// </summary>
        [DataMember]
        public Rol Rol { get; set; }
        /// <summary>
        /// Campo de Objeto TipoUsuario que contiene informacion detallada del usuario
        /// </summary>
        [DataMember]
        public TipoUsuario TipoUsuario { get; set; }
        /// <summary>
        /// Campo que indica el pais del usuario
        /// </summary>
        [DataMember]
        public Pais Pais { get; set; }
        /// <summary>
        /// Campo que indica el correo electronico del usuario
        /// </summary>
        /// 
        [DataMember]
        public string Correo { get; set; }

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
            this.Rol = new Rol();
            this.Correo = string.Empty;
        }
    }
}
