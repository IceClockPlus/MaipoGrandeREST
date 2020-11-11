using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para ProcesoVenta.xaml
    /// </summary>
    public partial class ProcesoVenta : Page
    {
        private MenuPrincipal main;

        public ProcesoVenta(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
            CargarTabla();
            CargarTablaPedido();
            CargarTablaProducto();
            CargarComboEstadoPedido();
        }

        /// <summary>
        /// Cargar tabla de datos de pedidos
        /// </summary>
        private void CargarTabla()
        {
            /*
            dataDetalle.ItemsSource = null;
            //Establecer ruta de la api
            RestClient client = new RestClient("http://localhost:54192/api");
            //Request de la api
            RestRequest request = new RestRequest("/DetallePedido", Method.GET);
            //Ejecucion del request y la respuesta obtenida
            var response = client.Execute(request);
            //Verificar el codigo de respuesta
            if (response.StatusCode == HttpStatusCode.OK)
            {
                //Deserializa la respuesta en objetos c#
                var detalle = JsonConvert.DeserializeObject<List<DetallePedido>>(response.Content);
                //Muestra detalles sin productores asignados
                List<DetallePedido> listaDetalle = new List<DetallePedido>();
                foreach (var p in detalle)
                {
                    if (p.productor.Nombre == "")
                    {
                        listaDetalle.Add(p);
                    }
                }
                dataDetalle.ItemsSource = listaDetalle;
            }
            */
        }

        private void CargarComboEstadoPedido()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/EstadoPedido", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var estadoPedidos = JsonConvert.DeserializeObject<List<EstadoPedido>>(response.Content);
                foreach (var item in estadoPedidos)
                {
                    cbxEstadoPedido.Items.Add(item.DescripcionEstado);
                }


            }


        }

        private void CargarTablaPedido()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Pedidos", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pedido = JsonConvert.DeserializeObject<List<Pedido>>(response.Content);
                dataPedido.ItemsSource = pedido;
            }
        }
        private void CargarTablaProducto()
        {
            /*
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Productos", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var producto = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
                dataProducto.ItemsSource = producto;
            }
            */
        }


        private void cbxEstadoPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string estado = cbxEstadoPedido.SelectedItem.ToString();
            
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Pedidos", Method.GET);
            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pedido = JsonConvert.DeserializeObject<List<Pedido>>(response.Content);
                var list = pedido.Where(p => p.EstadoPedido.DescripcionEstado == estado);
                dataPedido.ItemsSource = list;
            }
            

        }

        private void ObtenerDetallePedido()
        {
            var detalle = (Pedido)dataPedido.SelectedItem;

            dataDetalle.ItemsSource = detalle.DetallePedido;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Pedido pedido = (Pedido)dataPedido.SelectedItem;
                int total = pedido.DetallePedido.Count();
                int aceptados = pedido.DetallePedido.Where(d => d.Estado == "Aceptado").Count();
                if(aceptados == total)
                {
                    pedido.EstadoPedido.IdEstado = 7;
                    HttpClient cliente = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
                    var response = cliente.PutAsync("http://localhost:54192/api/Pedidos", content).Result;

                }
                else
                {
                    main.Mensaje("Aviso", "Para subastar un transporte, es necesario que todas las solicitudes esten aceptadas");
                }

                this.ObtenerDetallePedido();
            }
            catch (Exception ex)
            {
                main.Mensaje("Aviso", "Debe seleccionar un pedido del listado");
            }
            finally
            {
                this.CargarTablaPedido();
            }




        }

        private void BtnAsignarProductor_Click(object sender, RoutedEventArgs e)
        {
            //Despliega Flyout de asignacion
            var Item = (ItemPedido)dataDetalle.SelectedItem;
            int idProducto = Item.Producto.IdProducto;


            this.CargarProduccion(idProducto);
            FlyAsignarProductor.IsOpen = true;

        }


        private void CargarProduccion(int idProducto)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Produccion", Method.GET);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var produccion = JsonConvert.DeserializeObject<List<Produccion>>(response.Content);
                    var ls = produccion.Where(p => p.Producto.IdProducto == idProducto).ToList();
                    DataProduccion.ItemsSource = ls;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        private void BtnEnviarSolicitud_Click(object sender, RoutedEventArgs e)
        {
            

            try
            {
                ItemPedido Item = (ItemPedido)dataDetalle.SelectedItem;
                Item.Estado = "Pendiente";
                var Produccion = (Produccion)DataProduccion.SelectedItem;
                Item.Productor = Produccion.Productor;
                
                //Realizar llamada a la API
                HttpClient cliente = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(Item), Encoding.UTF8, "application/json");
                var response2 = cliente.PutAsync("http://localhost:54192/api/DetallePedido", content).Result;

                if(response2.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add(Item.Productor.Correo);
                    msg.Subject = "Detalle Pedido";
                    msg.SubjectEncoding = Encoding.UTF8;

                    msg.Body = "Se le ha asigando la siguiente solicitud: " + Item.IdItemPedido + ", Fecha de Solicitud: " + DateTime.Now.ToString() + " Producto:" + Item.Producto.NombreProducto + " Cantidad:" + Item.Cantidad + " Calidad:" + Item.Calidad/*+ ", Fecha de entrega: " + DetallePedido.pedido.FechaEntrega.ToString("d") +
                            ", Direccion: " + DetallePedido.pedido.Direccion + ", Cliente: " + DetallePedido.pedido.cliente.Nombre + ", Estado Pedido: " + DetallePedido.pedido.estado.Descripcion + ", Ubicacion: " + DetallePedido.pedido.Ciudad + " - " +
                            DetallePedido.pedido.Pais + ", Productor asignado: " + DetallePedido.productor.Nombre*/;
                    msg.BodyEncoding = Encoding.UTF8;
                    msg.IsBodyHtml = true;
                    msg.From = new MailAddress("aravenapro98@gmail.com");

                    SmtpClient clientM = new SmtpClient();

                    clientM.Credentials = new NetworkCredential("maipograndeduoc7@gmail.com", "Duoc2020");

                    clientM.Port = 587;
                    clientM.EnableSsl = true;
                    clientM.Host = "smtp.gmail.com";
                    clientM.Send(msg);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            finally
            {
                if(FlyAsignarProductor.IsOpen == true)
                {
                    FlyAsignarProductor.IsOpen = false;
                }
                dataDetalle.ItemsSource = null;

            }




        }
    }
}
