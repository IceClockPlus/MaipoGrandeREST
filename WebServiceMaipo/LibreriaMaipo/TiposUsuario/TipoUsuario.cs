using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public String Nombre { get; set; }
        /// <summary>
        /// Campo que indica la direccion del usuario
        /// </summary>
        [DataMember]
        public String Direccion { get; set; }
        /// <summary>
        /// Campo que indica el numero telefonica del usuario
        /// </summary>
        [DataMember]
        public String Telefono { get; set; }

        public TipoUsuario()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.Id = 0;
            this.Nombre = String.Empty;
            this.Direccion = String.Empty;
            this.Telefono = String.Empty;
        }

        public abstract bool ReadById(int idUsuario);
        public abstract void ObtenerDatosPorId(int id);

        public abstract List<TipoUsuario> ReadAll();


    }
}
