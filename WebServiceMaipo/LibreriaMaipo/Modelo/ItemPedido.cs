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
    /// <summary>
    /// Clase que especifica el detalle sobre lo que se va a solicitar
    /// </summary>
    /// 
    [DataContract]
    public class ItemPedido
    {
        /// <summary>
        /// Campo de identidad del item que se ha solicitado
        /// </summary>
        /// 
        [DataMember]
        public int IdItemPedido { get; set; }
        /// <summary>
        /// Campo que indica la cantidad en kilos del producto que se solicita
        /// </summary>
        [DataMember]
        public int Cantidad { get; set; }
        /// <summary>
        /// Campo que especifica el producto que se va a solicitar
        /// </summary>
        [DataMember]
        public Producto Producto { get; set; }
        /// <summary>
        /// Campo que indica la calidad del producto solicitado
        /// </summary>
        [DataMember]
        public string Calidad { get; set; }
        /// <summary>
        /// Campo que indica el productor asignado para el item solicitado
        /// </summary>
        [DataMember]
        public Productor Productor { get; set; }
        /// <summary>
        /// Campo que indica el estado del item del pedido
        /// </summary>
        [DataMember]
        public string Estado { get; set; }
        /// <summary>
        /// Campo que indica el precio unitario asignado al item solicitado
        /// </summary>
        [DataMember]
        public Nullable<float> Precio { get; set; }

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
            this.Estado = string.Empty;
            this.Precio = null;
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
                            item.Estado = det.ESTADO;
                            item.Producto = MantenedorProducto.BuscarPorId((int)det.IDPRODUCTO);
                            item.Precio = (float?)det.PRECIO;

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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<ItemPedido> ReadByIdPedido(int idPedido)
        {
            try
            {
                TipoUsuarioFactory factory = new ProductorFactory();
                //Crear listado del detalle a devolver
                List<ItemPedido> list = new List<ItemPedido>();
                using (var db = new DBEntities())
                {
                    var listadoDetalle = db.DETALLEPEDIDO.Where(d => d.IDPEDIDO == idPedido).ToList();
                    if (listadoDetalle.Count > 0)
                    {
                        foreach (var det in listadoDetalle)
                        {
                            ItemPedido item = new ItemPedido();
                            item.IdItemPedido = (int)det.IDDETALLEPEDIDO;
                            item.Calidad = det.CALIDAD;
                            item.Cantidad = (int)det.CANTIDAD;
                            item.Estado = det.ESTADO;
                            item.Precio = (float?)det.PRECIO;

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
            catch (Exception ex)
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

                    db.SP_UPDATE_DETALLE_PEDIDO(this.IdItemPedido, this.Producto.IdProducto, this.Cantidad, this.Calidad,this.Estado, this.Productor.Id, (decimal?)this.Precio);
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
