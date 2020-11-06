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
using System.Web.Configuration;
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
            CargarTablaProductor();
            CargarTablaProducto();
            NotificarEstado();
        }


        /// <summary>
        /// Cargar detalle del pedido
        /// </summary>
        private void CargarTabla(int idPedido)
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/DetallePedidos/{idPedido}", Method.GET);
            request.AddParameter("idPedido", idPedido);
            var response = client.Execute(request);
            
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pedido = JsonConvert.DeserializeObject<List<ItemPedido>>(response.Content);
                dataPedido.ItemsSource = pedido;
            }
            
        }

        /// <summary>
        /// Obtiene y muestra los datos de los productores
        /// </summary>
        private void CargarTablaProductor()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Produccion", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var productor = JsonConvert.DeserializeObject<List<Produccion>>(response.Content);
                dataProductor.ItemsSource = productor;
            }
        }

        /// <summary>
        /// Muestra las participaciones
        /// </summary>
        private void CargarTablaProducto()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Participacion", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var participaciones = JsonConvert.DeserializeObject<List<Participacion>>(response.Content);
                dataProducto.ItemsSource = participaciones;
            }
        }


        private void btnAsignar_Click(object sender, RoutedEventArgs e) { }

        /// <summary>
        /// Notifica la cantidad de productores que han aceptado la participacion
        /// </summary>
        private void NotificarEstado()
        {
            int participanteAceptados = 0;

            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Participacion", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var participaciones = JsonConvert.DeserializeObject<List<Participacion>>(response.Content);
                foreach(Participacion p in participaciones)
                {
                    if (p.EstadoParticipacion.Equals("Aceptado"))
                    {
                        participanteAceptados = +1;
                    }
             
                }

                MessageBox.Show("Se han encontrado " + participanteAceptados+ " invitacion aceptada", "Notificacion Participacion");

            }


        }


        private void btnAsignar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var participacion = (Participacion)dataProducto.SelectedItem;
                Productor productor = participacion.Productor;
                //Recuperar item 

                if (participacion.EstadoParticipacion.Equals("Aceptado"))
                {
                    var ItemPedido = (ItemPedido)dataPedido.SelectedItem;
                    ItemPedido.Productor = productor;
                    //Confirmacion
                    MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de actualizar?", "Confirmacion", MessageBoxButton.YesNo);

                    if (messageBox == MessageBoxResult.Yes)
                    {


                        HttpClient cliente = new HttpClient();
                        var content = new StringContent(JsonConvert.SerializeObject(ItemPedido), Encoding.UTF8, "application/json");
                        var response2 = cliente.PutAsync("http://localhost:54192/api/DetallePedido", content).Result;


                        Console.WriteLine(response2);


                        if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            MailMessage msg = new MailMessage();
                            msg.To.Add(participacion.Productor.Correo);
                            msg.Subject = "Detalle Pedido";
                            msg.SubjectEncoding = Encoding.UTF8;

                            msg.Body = "Se le ha asigando la siguiente solicitud: " + ItemPedido.IdItemPedido + ", Fecha de Solicitud: " + DateTime.Now.ToString() + " Producto:"+ItemPedido.Producto.NombreProducto+" Cantidad:"+ItemPedido.Cantidad+" Calidad:"+ItemPedido.Calidad/*+ ", Fecha de entrega: " + DetallePedido.pedido.FechaEntrega.ToString("d") +
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

                            try
                            {
                                clientM.Send(msg);
                                CargarTablaProducto();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }

                            main.Mensaje("Detalle Pedido", "Pedido Actualizado con exito. (Notificacion enviada a productor.)");

                            CargarTablaProducto();
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
                else
                {
                    main.Mensaje("Error", "El productor no ha aceptado la invitacion");
                }
            }
            catch (Exception ex)
            {

            }

        }


        private void btn_Detalle_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                var participacion = (Participacion)dataProducto.SelectedItem;
                int idPedido = participacion.IdPedido;
                this.CargarTabla(idPedido);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        private void dataProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var participacion = (Participacion)dataProducto.SelectedItem;
                int idPedido = participacion.IdPedido;
                this.CargarTabla(idPedido);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
