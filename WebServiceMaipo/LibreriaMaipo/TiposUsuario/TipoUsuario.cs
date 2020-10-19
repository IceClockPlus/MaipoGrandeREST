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
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Direccion { get; set; }
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

        public abstract bool ObtenerDatosPorIdUsuario(int idUsuario);
        public abstract void ObtenerDatosPorId(int id);


    }
}
