using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class EstadoSubasta
    {
        [DataMember]
        public int IdEstadoSubasta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }


        public EstadoSubasta()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdEstadoSubasta = 0;
            this.Descripcion = string.Empty;
        }
    }
}
