
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    public class OfertaProducto
    {
        public int Id { get; set; }
        public float PrecioUsd { get; set; }
        public float PrecioClp { get; set; }
        public Producto Producto { get; set; }

    }
}
