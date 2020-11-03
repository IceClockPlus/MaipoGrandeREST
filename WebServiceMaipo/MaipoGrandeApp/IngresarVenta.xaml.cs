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
    /// Lógica de interacción para IngresarVenta.xaml
    /// </summary>
    public partial class IngresarVenta : Page
    {
        MenuPrincipal main;
        public IngresarVenta(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
            //CargarTabla();
        }

        /*private void CargarTabla()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Venta", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var ventas = JsonConvert.DeserializeObject<List<Venta>>(response.Content);
                dataVenta.ItemsSource = ventas;
            }
        }*/

        private void DeshabilitarBtn()
        {
            txtCantidad.IsEnabled = false;
            txtTipoVenta.IsEnabled = false;
            txtIdCliente.IsEnabled = false;
            txtIdProducto.IsEnabled = false;
            txtNombreCliente.IsEnabled = false;
            txtNombreProducto.IsEnabled = false;

        }

        private void HabilitarBtn()
        {
            txtCantidad.IsEnabled = true;
            txtTipoVenta.IsEnabled = true;
            txtIdCliente.IsEnabled = true;
            txtIdProducto.IsEnabled = true;
            txtNombreCliente.IsEnabled = true;
            txtNombreProducto.IsEnabled = true;
        }

        private void LimpiarCampos()
        {
            txtCantidad.Clear();
            txtTipoVenta.Clear();
            txtIdCliente.Clear();
            txtIdProducto.Clear();
            txtNombreCliente.Clear();
            txtNombreProducto.Clear();
        }



        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
           /* try
            {
                Venta venta = new Venta
                {
                    CantidadProducto = int.Parse(txtCantidad.Text),
                    TipoVenta = txtTipoVenta.Text,
                    cliente = new Cliente 
                    {
                        Id = int.Parse(txtIdCliente.Text),
                        Nombre = txtNombreCliente.Text
                    },
                    producto = new Producto 
                    {
                        IdProducto = int.Parse(txtIdProducto.Text),
                        NombreProducto = txtNombreProducto.Text
                    }
                };

                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(venta), Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:54192/api/Venta", content).Result;


                Console.WriteLine(response);



                Cliente cli = new Cliente();
                cli.Id = int.Parse(txtIdCliente.Text);

                if (cli.leer())
                {

                    if (cli.usuario.rol.NombreRol == "Productor")
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            main.Mensaje("Venta", "Venta ingresada con exito");

                            MailMessage msg = new MailMessage();
                            msg.To.Add(cli.usuario.Correo);
                            msg.Subject = "Venta";
                            msg.SubjectEncoding = Encoding.UTF8;
                            //msg.Bcc.Add(txtCopia.Text);

                            msg.Body = "Notificamos que a realizado una venta de sus productos, con el siguiente detalle: Cantidad vendida: "+ txtCantidad.Text +" Tipo de venta: "+ txtTipoVenta.Text 
                                +" Nombre del cliente: "+ txtNombreCliente.Text +" Tipo de producto vendido: "+ txtNombreProducto.Text +"." ;
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
                                LimpiarCampos();
                                CargarTabla();
                                MessageBox.Show("Mensaje Enviado", "Correo");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                MessageBox.Show("Mensaje no enviado", "Correo");
                            }

                            
                            
                        }
                        else
                        {
                            main.Mensaje("Venta", "Venta no ingresada");
                        }
                    }
                    else
                    {
                        main.Mensaje("Venta", "El rol "+ cli.usuario.rol.NombreRol +" del cliente no corresponde para ingresar una venta (debe ser un productor.)");
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                main.Mensaje("Venta","Venta Existente");
            }*/
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            /*RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Productos", Method.GET);
            request.AddParameter("id", txtIdProducto.Text);
            var response = client.Execute(request);
            var result = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pro = JsonConvert.DeserializeObject<Producto>(result);
                txtNombreProducto.Text = pro.NombreProducto;


                RestRequest request2 = new RestRequest("/Cliente", Method.GET);
                request2.AddParameter("id", txtIdCliente.Text);
                var response2 = client.Execute(request2);
                var result2 = response2.Content;
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var cli = JsonConvert.DeserializeObject<Cliente>(result2);
                    txtNombreCliente.Text = cli.Nombre;
                }
                else
                {
                    main.Mensaje("Error", "Cliente no encontrado");
                }
            }
            else
            {
                main.Mensaje("Error", "Producto no encontrado");
            }*/
        }
    }
}
