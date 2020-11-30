using LibreriaMaipo.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Lógica de interacción para NotificarEstado.xaml
    /// </summary>
    public partial class NotificarEstado : Page
    {
        public NotificarEstado()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {


            MailMessage msg = new MailMessage();
            msg.To.Add(txtCorreoDestinatario.Text);
            msg.Subject = txtAsunto.Text;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Bcc.Add(txtCopia.Text);

            msg.Body = txtMensaje.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("mapacheco75@gmail.com");

            SmtpClient client = new SmtpClient();

            client.Credentials = new NetworkCredential("mapacheco75@gmail.com", "matias29031998");

            client.Port = 587;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";

            try
            {
                client.Send(msg);
                MessageBox.Show("Mensaje Enviado", "Correo");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Mensaje no enviado", "Correo");
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            /*
             RestClient cliente = new RestClient("http://localhost:54192/api");
             RestRequest request = new RestRequest("/NotificarEstado", Method.GET);
             request.AddParameter("id", txtNroPedido.Text);
             var response = cliente.Execute(request);
             var result = response.Content;

             if (response.StatusCode == HttpStatusCode.OK)
             {
                 var pedido = JsonConvert.DeserializeObject<Pedido>(result);

                 txtCorreoDestinatario.Text = pedido.cliente.usuario.Correo;
                 txtAsunto.Text = "Estado Pedido";
                 txtMensaje.Text = "El estado de su pedido es" + " " + pedido.estado.Descripcion;
                 txtCliente.Text = pedido.cliente.Nombre;


             }
             else
             {
                 MessageBox.Show("Error, Pedido no encontrado", "Error al cargar");
             }
         }
            */
        }
    }
}
