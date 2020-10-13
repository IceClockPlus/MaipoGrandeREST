using DatoMaipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int IdProducto { get; set; }
        [DataMember]
        public String NombreProducto { get; set; }
        [DataMember]
        public float PrecioEstimado { get; set; }
        [DataMember]
        public String ImagenProducto { get; set; }
        [DataMember]
        public String BannerProducto { get; set; }

        public Producto()
        {
            this.InitClass();
        }

        private void InitClass()
        {
            this.IdProducto = 0;
            this.NombreProducto = String.Empty;
            this.PrecioEstimado = 0;
            this.ImagenProducto = String.Empty;
            this.BannerProducto = String.Empty;

        }

        public Producto(PRODUCTO prod)
        {
            this.InitClass();

            this.IdProducto = (int)prod.IDPRODUCTO;
            this.NombreProducto = prod.NOMBREPRODUCTO;
            this.PrecioEstimado = (float)prod.PRECIOESTIMADO;
            this.ImagenProducto = prod.IMAGENPRODUCTO;
            this.BannerProducto = prod.BANNERPRODUCTO;
        }


    }
}
