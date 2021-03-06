﻿using LibreriaMaipo.Modelo;
using LibreriaMaipo.TiposUsuario;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mail;
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
using MailMessage = System.Net.Mail.MailMessage;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para SubastasTransporte.xaml
    /// </summary>
    public partial class SubastasTransporte : Page
    {
        private MenuPrincipal main;
        public SubastasTransporte(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
            CargarTabla();
            this.CargarTablaPedido();
        }

        private void CargarTablaPedido()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Pedidos", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var pedidos = JsonConvert.DeserializeObject<List<Pedido>>(response.Content);
                pedidos = pedidos.Where(p => p.EstadoPedido.IdEstado == 7).ToList();
                dataPedido.ItemsSource = pedidos;
            }
        }

        /// <summary>
        /// Evento del boton para agregar una nueva subasta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarSubasta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Obtener pedido del listado
                Pedido pedido = (Pedido)dataPedido.SelectedItem;
                if (pedido != null)
                {
                    //Creacion de subasta
                    Subasta subasta = new Subasta();
                    //Aignar pedido a la subasta
                    subasta.Pedido = pedido;
                    //Definir las fechas
                    subasta.FechaInicio = (DateTime)dateFechaInicio.SelectedDate;
                    subasta.FechaTermino = (DateTime)dateFechaTermino.SelectedDate;
                    //Asignar el estado abierto a la subasta
                    subasta.EstadoSubasta.IdEstadoSubasta = 1;
                    //Se llama al servicio rest
                    HttpClient client = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(subasta), Encoding.UTF8, "application/json");
                    var response = client.PostAsync("http://localhost:54192/api/Subasta", content).Result;

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        //var subasta = JsonConvert.DeserializeObject<Subasta>(response.ToString());

                        main.Mensaje("Subasta", "Subasta Agregada con exito");
                        LimpiarCampos();
                        CargarTabla();
                    }
                    else
                    {
                        main.Mensaje("Aviso", "Subasta no fue agregada. Intentelo más tarde");

                    }

                }
                else
                {
                    main.Mensaje("Aviso", "Debe selccionar un pedido de la lista");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Subasta", Method.GET);
            request.AddParameter("id", txtID.Text);
            var response = client.Execute(request);
            var result = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var sub = JsonConvert.DeserializeObject<Subasta>(result);
                //txtIdPedido.Text = sub.Pedido.IdPedido.ToString();
                //txtIdEstadoSubasta.Text = sub.EstadoSubasta.IdEstadoSubasta.ToString();
                dateFechaInicio.SelectedDate = sub.FechaInicio;
                dateFechaTermino.SelectedDate = sub.FechaTermino;
                DeshabilitarBtn();
                flyActualizarSubasta.IsOpen = true;
                
            }
            else
            {
                MessageBox.Show("Error, Subasta no encontrada", "Error al cargar");
            }
           
        }

        private void DeshabilitarBtn()
        {
            txtID.IsEnabled = false;
            //txtIdPedido.IsEnabled = false;
            //txtIdEstadoSubasta.IsEnabled = false;
            dateFechaInicio.IsEnabled = false;
            dateFechaTermino.IsEnabled = false;
        }

        private void HabilitarBtn()
        {
            txtID.IsEnabled = true;
            //txtIdPedido.IsEnabled = true;
            //txtIdEstadoSubasta.IsEnabled = true;
            dateFechaInicio.IsEnabled = true;
            dateFechaTermino.IsEnabled = true;
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            //txtIdPedido.Clear();
            //txtIdEstadoSubasta.Clear();
            dateFechaInicio.SelectedDate = DateTime.Now;
            dateFechaTermino.SelectedDate = DateTime.Now;
        }

        private void CargarTabla() 
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Subasta", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subasta = JsonConvert.DeserializeObject<List<Subasta>>(response.Content);
                tablaSubasta.ItemsSource = subasta;
            }
        }

        private void CargarTablaOfertas(int idSubasta)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/OfertasSubasta/{idSubasta}", Method.GET);
                request.AddParameter("idSubasta", idSubasta);
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var ofertas = JsonConvert.DeserializeObject<List<OfertaSubasta>>(response.Content);
                    GridOfertas.ItemsSource = ofertas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Subasta", Method.GET);
                request.AddParameter("id", txtID.Text);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de actualizar?", "Confirmacion", MessageBoxButton.YesNo);
                    if (messageBox == MessageBoxResult.Yes)
                    {
                        if (txtActualizarID.Text != string.Empty)
                        {
                            Subasta sub = new Subasta
                            {

                                IdSubasta = int.Parse(txtActualizarID.Text),
                                FechaInicio = (DateTime)dateActualizarInicio.SelectedDate,
                                FechaTermino = (DateTime)dateActualizarTermino.SelectedDate,
                                Pedido = new Pedido
                                {
                                    IdPedido = int.Parse(txtIdPedidoActualizar.Text)
                                },
                                EstadoSubasta = new EstadoSubasta
                                {
                                    IdEstadoSubasta = int.Parse(txtEstadoActualizar.Text)
                                }
                            };


                            HttpClient client2 = new HttpClient();
                            var content = new StringContent(JsonConvert.SerializeObject(sub), Encoding.UTF8, "application/json");
                            var response2 = client2.PutAsync("http://localhost:54192/api/Subasta", content).Result;


                            Console.WriteLine(response);


                            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                //var subasta = JsonConvert.DeserializeObject<Subasta>(response.ToString());

                                main.Mensaje("Subasta", "Subasta Actualizada con exito");
                                HabilitarBtn();
                                LimpiarCampos();
                                flyActualizarSubasta.IsOpen = false;
                                CargarTabla();
                            }
                            else
                            {
                                main.Mensaje("Error", "Subasta no encontrada");
                            }
                        }
                        else
                        {
                            main.Mensaje("Error","Ingrese los datos necesarios");
                        }
                        
                    }
                    else if (messageBox == MessageBoxResult.No)
                    {
                        main.Mensaje("Subasta", "Subasta no Actualizada");
                    }
                    
                }

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Subasta", Method.GET);
                request.AddParameter("id", txtID.Text);
                var response = client.Execute(request);
                
                
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmacion", MessageBoxButton.YesNo);
                    if (messageBox == MessageBoxResult.Yes)
                    {

                        RestRequest request2 = new RestRequest("/Subasta", Method.DELETE);
                        request.AddParameter("id", txtID.Text);
                        var response2 = client.Execute(request2);
                        main.Mensaje("ELiminar","Subasta Eliminada");
                        LimpiarCampos();
                        CargarTabla();

                    }
                    else if (messageBox == MessageBoxResult.No)
                    {
                        main.Mensaje("Error", "Error, Subasta no eliminada");
                    }
                }
                else
                {
                    main.Mensaje("Error", "Error, Subasta no encontrada");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show(ex.ToString(),"Error Interno");
            }
            
        }

        /// <summary>
        /// Despliega las ofertas de la subasta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerOfertas_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var subasta = (Subasta)tablaSubasta.SelectedItem;
                if(subasta.EstadoSubasta.IdEstadoSubasta == 1)
                {
                    BtnAsignarTransportista.IsEnabled = true;
                }
                else
                {
                    BtnAsignarTransportista.IsEnabled = false;

                }
                this.CargarTablaOfertas(subasta.IdSubasta);
                flyOfertasTransportista.IsOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Evento del boton para asignar un nuevo transportista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAsignarTransportista_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OfertaSubasta oferta = (OfertaSubasta)GridOfertas.SelectedItem;
                if(oferta != null)
                {
                    oferta.Seleccionado = "1";
                    HttpClient client2 = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(oferta), Encoding.UTF8, "application/json");
                    var response2 = client2.PutAsync("http://localhost:54192/api/OfertaSubasta", content).Result;

                    if(response2.StatusCode == HttpStatusCode.OK)
                    {
                        this.AsignarCostoTransporte(oferta.PrecioOferta);
                        flyOfertasTransportista.IsOpen = false;
                        this.CerrarSubasta();
                        this.CargarTabla();
                        this.EnviarMensaje(oferta.Transportista);
                        main.Mensaje("Transportista asignado", "El transportista ha sido asignado");
                    }

                }
                else
                {
                    main.Mensaje("Debe seleccionar una oferta","Aviso");
                }


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public void AsignarCostoTransporte(float precioTransporte)
        {
            try
            {
                Subasta subasta = (Subasta)tablaSubasta.SelectedItem;

                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/DocumentoVentaPedido/{idPedido}", Method.GET);
                request.AddParameter("idPedido", subasta.Pedido.IdPedido);
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var documento = JsonConvert.DeserializeObject<DocumentoVenta>(response.Content);
                    documento.PrecioTransporte = (decimal?)precioTransporte;

                    HttpClient client2 = new HttpClient();
                    var content = new StringContent(JsonConvert.SerializeObject(documento), Encoding.UTF8, "application/json");
                    var response2 = client2.PutAsync("http://localhost:54192/api/DocumentoVenta", content).Result;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Actualizar subasta para cerrarla
        /// </summary>
        public void CerrarSubasta()
        {
            try
            {
                Subasta subasta = (Subasta)tablaSubasta.SelectedItem;
                subasta.EstadoSubasta.IdEstadoSubasta = 2;

                HttpClient client2 = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(subasta), Encoding.UTF8, "application/json");
                var response2 = client2.PutAsync("http://localhost:54192/api/Subasta", content).Result;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }


        public void EnviarMensaje(Transportista t)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(t.Correo);
            msg.Subject = "Resultado Oferta";
            msg.SubjectEncoding = Encoding.UTF8;

            msg.Body = "Estimado "+ t.Nombre + ". Le informamos que su oferta ha sido seleccionada ";
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void BtnRevisarSubasta_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Pedido pedido = (Pedido)dataPedido.SelectedItem;
                List<Subasta> subastas = this.ObtenerSubastas();

                subastas = subastas.Where(sub => sub.Pedido.IdPedido == pedido.IdPedido).ToList();

                if(subastas.Count() >0)
                {
                    tablaSubasta.ItemsSource =subastas;
                }
                else
                {
                    tablaSubasta.ItemsSource = null;
                    main.Mensaje("Aviso","El pedido "+pedido.IdPedido+" no tiene una subasta asociada");
                }

            }
            catch (Exception ex)
            {

                
            }

        }

        public List<Subasta> ObtenerSubastas()
        {
            try
            {
                List<Subasta> subastas = new List<Subasta>();

                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Subasta", Method.GET);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                     subastas = JsonConvert.DeserializeObject<List<Subasta>>(response.Content);
                }
                return subastas;
            }
            catch (Exception ex)
            {
                main.Mensaje("Error","Ha ocurrido un error inesperado, intente más tarde");
                return new List<Subasta>();
            }

        }


        /*private void llenarCB() 
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Subasta", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var subasta = JsonConvert.DeserializeObject<List<Subasta>>(response.Content);
                foreach (var item in subasta)
                {
                    cbFiltroSubasta.Items.Add(item.FechaInicio);
                }

            }
        }*/
    }
}
