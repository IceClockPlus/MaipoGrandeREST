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
using WebServiceMaipo.Models.WS;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para RevisarPedidos.xaml
    /// </summary>
    public partial class RevisarPedidos : Page
    {
        private MenuPrincipal main;
        public RevisarPedidos(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
            CargarTabla();
            CargarTablaProductor();
            CargarTablaProducto();
        }



        private void CargarTabla()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/DetallePedido", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pedido = JsonConvert.DeserializeObject<List<DetallePedido>>(response.Content);
                dataPedido.ItemsSource = pedido;
            }
        }

        private void CargarTablaProductor()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Productor", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var productor = JsonConvert.DeserializeObject<List<Productor>>(response.Content);
                dataProductor.ItemsSource = productor;
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


        private void btnAsignar_Click(object sender, RoutedEventArgs e) { }

        private void btnAsignar_Click_1(object sender, RoutedEventArgs e)
        {
            var productor = (Productor)dataProductor.SelectedItem;
            var DetallePedido = (DetallePedido)dataPedido.SelectedItem;
            var producto = (Producto)dataProducto.SelectedItem;

            

            DetallePedido.productor = productor;

            try
            {
                
                
                    MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de actualizar?", "Confirmacion", MessageBoxButton.YesNo);
                    if (messageBox == MessageBoxResult.Yes)
                    {
                       

                            HttpClient cliente = new HttpClient();
                            var content = new StringContent(JsonConvert.SerializeObject(DetallePedido), Encoding.UTF8, "application/json");
                            var response2 = cliente.PutAsync("http://localhost:54192/api/DetallePedido", content).Result;


                            Console.WriteLine(response2);


                            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                //var pedido2 = JsonConvert.DeserializeObject<Pedido>(response2.ToString());

                                MailMessage msg = new MailMessage();
                                msg.To.Add(DetallePedido.productor.usuario.Correo);
                                msg.Subject = "Detalle Pedido";
                                msg.SubjectEncoding = Encoding.UTF8;
                                //msg.Bcc.Add(txtCopia.Text);

                                msg.Body = "Se le a asigando el siguiente pedido: id: "+ DetallePedido.Id + ", Fecha de Pedido: "+ DetallePedido.pedido.FechaInicio.ToString("d") +", Fecha de entrega: " + DetallePedido.pedido.FechaEntrega.ToString("d") + 
                                ", Direccion: " + DetallePedido.pedido.Direccion + ", Cliente: " + DetallePedido.pedido.cliente.Nombre + ", Estado Pedido: " + DetallePedido.pedido.estado.Descripcion + ", Ubicacion: " + DetallePedido.pedido.Ciudad + " - " +
                                DetallePedido.pedido.Pais + ", Productor asignado: " + DetallePedido.productor.Nombre;
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
                                    CargarTabla();
                                    
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }
                            
                                main.Mensaje("Detalle Pedido", "Pedido Actualizado con exito. (Notificacion enviada a productor.)");
                                /*HabilitarBtn();
                                LimpiarCampos();
                                flyActualizarContra.IsOpen = false;*/
                                CargarTabla();
                            }
                            else
                            {
                                main.Mensaje("Error", "Detalle Pedido no Actualizado");
                            }
                    }
                    else if (messageBox == MessageBoxResult.No)
                    {
                        main.Mensaje("Detalle Pedido", "Detalle Pedido no actualizado");
                    }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
