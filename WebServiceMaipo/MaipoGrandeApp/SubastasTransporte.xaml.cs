using LibreriaMaipo.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        }

        private void BtnAgregarSubasta_Click(object sender, RoutedEventArgs e)
        {
             
            try
            {
                Subasta subasta = new Subasta();
                subasta.FechaInicio = (DateTime)dateFechaInicio.SelectedDate;
                subasta.FechaTermino = (DateTime)dateFechaTermino.SelectedDate;
                subasta.Pedido.IdPedido = int.Parse(txtIdPedido.Text);
                subasta.EstadoSubasta.IdEstadoSubasta = 1;
                

                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(subasta), Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:54192/api/Subasta", content).Result;


                Console.WriteLine(response);
                

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var subasta = JsonConvert.DeserializeObject<Subasta>(response.ToString());

                    MessageBox.Show("Subasta AGregada con exito","Subasta");
                    LimpiarCampos();
                    CargarTabla();
                }
                else
                {
                    MessageBox.Show("Subasta no agregada","Subasta");
                }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex);
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
                txtIdPedido.Text = sub.Pedido.IdPedido.ToString();
                txtIdEstadoSubasta.Text = sub.EstadoSubasta.IdEstadoSubasta.ToString();
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
            txtIdPedido.IsEnabled = false;
            txtIdEstadoSubasta.IsEnabled = false;
            dateFechaInicio.IsEnabled = false;
            dateFechaTermino.IsEnabled = false;
        }

        private void HabilitarBtn()
        {
            txtID.IsEnabled = true;
            txtIdPedido.IsEnabled = true;
            txtIdEstadoSubasta.IsEnabled = true;
            dateFechaInicio.IsEnabled = true;
            dateFechaTermino.IsEnabled = true;
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtIdPedido.Clear();
            txtIdEstadoSubasta.Clear();
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
                this.CargarTablaOfertas(subasta.IdSubasta);
                flyOfertasTransportista.IsOpen = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
