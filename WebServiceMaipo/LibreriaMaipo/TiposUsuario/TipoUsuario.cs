using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.TiposUsuario
{
    [DataContract]
    public abstract class TipoUsuario
    {
        /// <summary>
        /// Indica la Id especifica del usuario
        /// </summary>
        [DataMember]
        public int Id { get; set; }
        /// <summary>
        /// Campo que indica el nombre real del usuario
        /// </summary>
        [DataMember]
        public string Nombre { get; set; }
        /// <summary>
        /// Campo que indica la direccion del usuario
        /// </summary>
        [DataMember]
        public string Direccion { get; set; }
        /// <summary>
        /// Campo que indica el numero telefonica del usuario
        /// </summary>
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Correo { get; set; }
        

        public TipoUsuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Direccion = string.Empty;
            this.Telefono = string.Empty;
            this.Correo = string.Empty;
        }

        public abstract bool ReadById(int idUsuario);
        public abstract void ObtenerDatosPorId(int id);

        public abstract List<TipoUsuario> ReadAll();


    }
}
