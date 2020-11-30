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
        [DataMember]
        public Productor Productor { get; set; }

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
            this.Productor = new Productor();
        }

        public List<Produccion> ReadAll()
        {
            List<Produccion> listProduccion = new List<Produccion>();
            TipoUsuarioFactory factory = new ProductorFactory();
            try
            {

                using (var db = new DBEntities())
                {
                    var query = db.PRODUCCION.ToList();
                    foreach (var dbProd in query)
                    {
                        Produccion produccion = new Produccion();
                        produccion.IdProduccion = (int)dbProd.IDPRODUCCION;
                        produccion.PrecioPremium = (float)dbProd.PRECIOPREMIUM;
                        produccion.PrecioEstandar = (float)dbProd.PRECIOESTANDAR;
                        produccion.PrecioLower = (float)dbProd.PRECIOLOWER;
                        produccion.Producto = MantenedorProducto.BuscarPorId((int)dbProd.IDPRODUCTO);

                        TipoUsuario productor = factory.createTipoUsuario();
                        int idProductor = (int)dbProd.IDPRODUCTOR;
                        productor.ObtenerDatosPorId(idProductor);
                        produccion.Productor = (Productor)productor;

                        listProduccion.Add(produccion);
                    }
                    return listProduccion;
                }

            }
            catch (Exception ex)
            {
                ex.InnerException.ToString();
                return new List<Produccion>();
            }
        }

        /// <summary>
        /// Metodo que entrega un listado de la produccion de un productor
        /// </summary>
        /// <returns></returns>
        public List<Produccion> ReadByIdProductor()
        {
            try
            {
                List<Produccion> listado = new List<Produccion>();
                listado = this.ReadAll();
                listado = listado.Where(p => p.Productor.Id == this.Productor.Id).ToList();
                return listado;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Produccion>();
            }
        }


    }
}
