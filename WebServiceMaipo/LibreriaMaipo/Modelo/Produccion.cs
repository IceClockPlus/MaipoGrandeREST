using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class Produccion
    {
        [DataMember]
        public int IdProduccion { get; set; }
        [DataMember]
        public int IdProductor { get; set; }
        [DataMember]
        public Producto Producto { get; set; }
        [DataMember]
        public float PrecioPremium { get; set; }
        [DataMember]
        public float PrecioEstandar { get; set; }
        [DataMember]
        public float PrecioLower { get; set; }

        public Produccion()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdProduccion = 0;
            this.IdProductor = 0;
            this.Producto = new Producto();
            this.PrecioEstandar = 0;
            this.PrecioPremium = 0;
            this.PrecioLower = 0;
        }
    }
}
