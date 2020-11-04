using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    /// <summary>
    /// Clase que especifica el detalle sobre lo que se va a solicitar
    /// </summary>
    public class ItemPedido
    {
        /// <summary>
        /// Campo de identidad del item que se ha solicitado
        /// </summary>
        public int IdItemPedido { get; set; }
        /// <summary>
        /// Campo que indica la cantidad en kilos del producto que se solicita
        /// </summary>
        public int Cantidad { get; set; }
        /// <summary>
        /// Campo que especifica el producto que se va a solicitar
        /// </summary>
        public Producto Producto { get; set; }
        /// <summary>
        /// Campo que indica la calidad del producto solicitado
        /// </summary>
        public string Calidad { get; set; }
        /// <summary>
        /// Campo que indica el productor asignado para el item solicitado
        /// </summary>
        public Productor Productor { get; set; }

        public ItemPedido()
        {
            this.InitClass();
        }
        /// <summary>
        /// Inicializacion de la clase 
        /// </summary>
        private void InitClass()
        {
            this.IdItemPedido = 0;
            this.Cantidad = 0;
            this.Calidad = string.Empty;
            this.Producto = new Producto();
            this.Productor = new Productor();
        }

        public List<ItemPedido> ReadAll()
        {
            try
            {
                TipoUsuarioFactory factory = new ProductorFactory();
                //Crear listado del detalle a devolver
                List<ItemPedido> list = new List<ItemPedido>();
                using (var db = new DBEntities())
                {
                    var listadoDetalle = db.DETALLEPEDIDO.ToList();
                    if(listadoDetalle.Count > 0)
                    {
                        foreach(var det in listadoDetalle)
                        {
                            ItemPedido item = new ItemPedido();
                            item.IdItemPedido = (int)det.IDDETALLEPEDIDO;
                            item.Calidad = det.CALIDAD;
                            item.Cantidad = (int)det.CANTIDAD;

                            item.Producto = MantenedorProducto.BuscarPorId((int)det.IDPRODUCTO);

                            TipoUsuario productor = factory.createTipoUsuario();
                            productor.ObtenerDatosPorId((int)det.IDPRODUCTOR.GetValueOrDefault());

                            item.Productor = (Productor)productor;

                            list.Add(item);
                        }

                    }
                    return list;
                }


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ItemPedido>();
            }



        }

        public bool Update()
        {
            try
            {
                using (var db = new DBEntities())
                {

                    db.SP_UPDATE_DETALLE_PEDIDO(this.IdItemPedido, this.Producto.IdProducto, this.Cantidad, this.Calidad, this.Productor.Id);
                    return true;

                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }


    }
}
