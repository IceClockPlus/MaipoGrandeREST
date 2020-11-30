using DatoMaipo;
using LibreriaMaipo.TiposUsuario;
using LibreriaMaipo.UsuarioFactory;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaMaipo.Modelo
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public DateTime FechaPedido { get; set; }
        [DataMember]
        public Nullable<DateTime> FechaEntrega { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Ciudad { get; set; }
        [DataMember]
        public Cliente Cliente { get; set; }
        [DataMember]
        public string Pais { get; set; }
        [DataMember]
        public EstadoPedido EstadoPedido { get; set; }
        [DataMember]
        public List<ItemPedido> DetallePedido { get; set; }
        

        public Pedido()
        {
            this.InitClass();
        }

        public void InitClass()
        {
            this.IdPedido = 0;
            this.FechaPedido = DateTime.Today;
            this.FechaEntrega = null;
            this.Direccion = string.Empty;
            this.Ciudad = string.Empty;
            this.Pais = string.Empty;
            this.Cliente = new Cliente();
            this.EstadoPedido = new EstadoPedido();
            this.DetallePedido = new List<ItemPedido>();
        }

        /// <summary>
        /// Metodo para registrar un nuevo pedido
        /// </summary>
        /// <returns></returns>
        public bool Insert()
        {
            try
            {
                //Objeto para recuperar el resultado
                System.Data.Objects.ObjectParameter output = new System.Data.Objects.ObjectParameter("pIDPEDIDO", typeof(int));

                using (var db = new DBEntities())
                {
                    //Ejecución del metodo para agregar el pedido
                    db.SP_INSERT_PEDIDO1(FechaPedido, FechaEntrega, Direccion, Cliente.Id, EstadoPedido.IdEstado, Ciudad, Pais, output);

                    //Conversion del valor del objeto output a Int
                    int idResultado = Convert.ToInt32(output.Value);

                    //Asignar el id del pedido generado al campo correspondiente
                    this.IdPedido = idResultado;

                    return true;


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }


        public bool Read()
        {
            TipoUsuarioFactory factory = new ClienteFactory();
            using (var db = new DBEntities())
            {
                try
                {
                    //Realizar consulta para obtener datos del pedido
                    var pedido = db.PEDIDO.Where(p => p.IDPEDIDO == this.IdPedido).FirstOrDefault();

                    //Devolver null si la consulta no entrega resultados
                    if (pedido != null)
                    {
                        this.FechaPedido = pedido.FECHAPEDIDO;
                        this.FechaEntrega = pedido.FECHAENTREGA;
                        this.Direccion = pedido.DIRECCIONPEDIDO;
                        this.Ciudad = pedido.CIUDAD;
                        this.Pais = pedido.PAIS;
                        //Crear una instancia cliente con el uso de ClienteFactory
                        TipoUsuario cli = factory.createTipoUsuario();

                        //Recuperar datos del cliente por su id
                        cli.ObtenerDatosPorId((int)pedido.IDCLIENTE);
                        this.Cliente = (Cliente)cli;

                        //Obtener el estado del pedido por su id
                        EstadoPedido estado = new EstadoPedido();
                        estado.IdEstado = (int)pedido.IDESTADOPEDIDO;
                        estado.Read();
                        this.EstadoPedido = estado;

                        //Obtener el detalle del pedido por id
                        this.DetallePedido = ItemPedido.ReadByIdPedido(this.IdPedido);
                        return true;
                    }
                    return false;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Update()
        {
            try
            {
                using (var bd = new DBEntities())
                {
                    bd.SP_ACTUALIZAR_PEDIDO(this.IdPedido, this.FechaPedido, this.FechaEntrega, this.Direccion, this.Cliente.Id, this.EstadoPedido.IdEstado, this.Ciudad, this.Pais);
                    
                    return true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }


        public bool UpdateEstado()
        {
            try
            {
                using (var db = new DBEntities())
                {
                    db.SP_UPDATE_PEDIDO_ESTADO(this.IdPedido, this.EstadoPedido.IdEstado);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
