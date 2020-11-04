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
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Productos", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var producto = JsonConvert.DeserializeObject<List<Producto>>(response.Content);
                dataProducto.ItemsSource = producto;
            }
        }

        /// <summary>
        /// Boton para creacion de pedidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCrear_Click(object sender, RoutedEventArgs e)
        {
            /*
            var producto = (Producto)dataProducto.SelectedItem;
            var pedido = (Pedido)dataPedido.SelectedItem;
            var detalle = new DetallePedido();

            detalle.pedido.Id = pedido.Id;
            detalle.producto.IdProducto = producto.IdProducto;
            detalle.Cantidad = int.Parse(txtCantidad.Text);

            try
            {
                //POST HttpClient
                HttpClient client = new HttpClient();
                //Serializa el objeto a enviar
                var content = new StringContent(JsonConvert.SerializeObject(detalle), Encoding.UTF8, "application/json");
                //Realizar solicitud
                var response = client.PostAsync("http://localhost:54192/api/DetallePedido", content).Result;

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    RestClient client2 = new RestClient("http://localhost:54192/api");
                    RestRequest request = new RestRequest("/Productor", Method.GET);
                    var response2 = client2.Execute(request);
                    

                    if (response2.StatusCode == HttpStatusCode.OK)
                    {
                        var productor = JsonConvert.DeserializeObject<List<Productor>>(response2.Content);
                        foreach (var item in productor)
                        {
                            MailMessage msg = new MailMessage();
                            msg.To.Add(item.usuario.Correo);
                            msg.Subject = "Detalle Pedido";
                            msg.SubjectEncoding = Encoding.UTF8;
                            //msg.Bcc.Add(txtCopia.Text);

                            msg.Body = "Se a creado un nuevo proceso de ventas para su visualizacion";
                            msg.BodyEncoding = Encoding.UTF8;
                            msg.IsBodyHtml = true;
                            msg.From = new MailAddress("mapacheco75@gmail.com");

                            SmtpClient clientM = new SmtpClient();

                            clientM.Credentials = new NetworkCredential("mapacheco75@gmail.com", "matias29031998");

                            clientM.Port = 587;
                            clientM.EnableSsl = true;
                            clientM.Host = "smtp.gmail.com";

                            try
                            {
                                clientM.Send(msg);

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                    else
                    {
                        main.Mensaje("Error","Mensaje no enviado");
                    }

                    main.Mensaje("Detalle Pedido", "Detalle Pedido Creado con exito. (Notificacion enviada a productor.)");

                    CargarTabla();
                }
                else
                {
                    main.Mensaje("Error", "Detalle Pedido no Creado");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
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
            this.ObtenerDetallePedido();
        }
    }
}
