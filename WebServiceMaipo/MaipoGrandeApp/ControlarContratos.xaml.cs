using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Authentication;
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
    /// Lógica de interacción para ControlarContratos.xaml
    /// </summary>
    public partial class ControlarContratos : Page
    {
        public MenuPrincipal main;
        public ControlarContratos(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
            CargarTabla();
        }

        private void btnAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contrato con = new Contrato
                {
                    FechaCreacion = (DateTime)dateFechaInicio.SelectedDate,
                    FechaTermino = (DateTime)dateFechaTermino.SelectedDate,
                    PorcComision = int.Parse(txtComision.Text),
                    Vigente = txtVigente.Text,
                    Productor = new Productor 
                    {
                        Id = int.Parse(txtIdProductor.Text)
                    }
                };

                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(con), Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:54192/api/Contrato", content).Result;


                Console.WriteLine(response);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //var subasta = JsonConvert.DeserializeObject<Subasta>(response.ToString());

                    MessageBox.Show("Contrato agregado con exito", "Contrato");
                    LimpiarCampos();
                    CargarTabla();
                }
                else
                {
                    MessageBox.Show("Contrato no agregado", "Contrato");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Cargar tabla con los contratos registrados
        /// </summary>
        private void CargarTabla()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Contrato", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var contrato = JsonConvert.DeserializeObject<List<Contrato>>(response.Content);
                dataContratos.ItemsSource = contrato;
            }
        }

        /// <summary>
        /// Boton que ejecuta la actualizacion del contrato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Contrato", Method.GET);
                request.AddParameter("id", txtIdContrato.Text);
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de actualizar?", "Confirmacion", MessageBoxButton.YesNo);
                    if (messageBox == MessageBoxResult.Yes)
                    {
                        if (txtActualizarID.Text != string.Empty)
                        {
                            Contrato con = new Contrato
                            {

                                Id = int.Parse(txtActualizarID.Text),
                                FechaCreacion = (DateTime)dateActualizarInicio.SelectedDate,
                                FechaTermino = (DateTime)dateActualizarTermino.SelectedDate,
                                PorcComision = int.Parse(txtComisionActualizar.Text),
                                Vigente = txtVigenciaActualizar.Text,
                                Productor = new Productor
                                {
                                    Id = int.Parse(txtIdproductorActualizar.Text)
                                }
                            };


                            HttpClient cliente = new HttpClient();
                            var content = new StringContent(JsonConvert.SerializeObject(con), Encoding.UTF8, "application/json");
                            var response2 = cliente.PutAsync("http://localhost:54192/api/Contrato", content).Result;


                            Console.WriteLine(response);


                            if (response2.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                //var subasta = JsonConvert.DeserializeObject<Subasta>(response.ToString());

                                MessageBox.Show("Contrato Actualizado con exito", "Contrato");
                                HabilitarBtn();
                                LimpiarCampos();
                                flyActualizarContra.IsOpen = false;
                                CargarTabla();
                            }
                            else
                            {
                                main.Mensaje("Error", "Contrato no Actualizado");
                            }
                        }
                        else
                        {
                            main.Mensaje("Error","Ingrese los datos necesarios");
                        }
                        
                    }
                    else if (messageBox == MessageBoxResult.No)
                    {
                        main.Mensaje("Contrato","Contrato no actualizado");
                    }

                }
                else
                {
                    main.Mensaje("Contrato","Contrato no encontrado");
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
            RestRequest request = new RestRequest("/Contrato", Method.GET);
            request.AddParameter("id", txtIdContrato.Text);
            var response = client.Execute(request);
            var result = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var con = JsonConvert.DeserializeObject<Contrato>(result);

                txtIdProductor.Text = con.Productor.Id.ToString();
                txtVigente.Text = con.Vigente;
                txtComision.Text = con.PorcComision.ToString();
                dateFechaInicio.SelectedDate = con.FechaCreacion;
                dateFechaTermino.SelectedDate = con.FechaTermino;
                txtIdContrato.Text = con.Id.ToString();

                DeshabilitarBtn();

                flyActualizarContra.IsOpen = true;
            }
            else
            {
                MessageBox.Show("Error, Contrato no encontrado", "Error al cargar");
            }
        }

        private void DeshabilitarBtn() 
        {
            txtIdContrato.IsEnabled = false;
            txtIdProductor.IsEnabled = false;
            txtComision.IsEnabled = false;
            txtVigente.IsEnabled = false;
            dateFechaInicio.IsEnabled = false;
            dateFechaTermino.IsEnabled = false;
        }

        private void HabilitarBtn() 
        {
            txtIdContrato.IsEnabled = true;
            txtIdProductor.IsEnabled = true;
            txtComision.IsEnabled = true;
            txtVigente.IsEnabled = true;
            dateFechaInicio.IsEnabled = true;
            dateFechaTermino.IsEnabled = true;
        }

        private void LimpiarCampos() 
        {
            txtIdContrato.Clear();
            txtIdProductor.Clear();
            txtComision.Clear();
            txtVigente.Clear();
            dateFechaInicio.SelectedDate = DateTime.Now;
            dateFechaTermino.SelectedDate = DateTime.Now;
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Contrato", Method.GET);
            request.AddParameter("id", txtIdContrato.Text);
            var response = client.Execute(request);
            

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBoxResult messageBox = MessageBox.Show("¿Esta seguro de eliminar?", "Confirmacion", MessageBoxButton.YesNo);
                if (messageBox == MessageBoxResult.Yes)
                {
                    RestRequest request2 = new RestRequest("/Contrato", Method.DELETE);
                    request2.AddParameter("id", txtIdContrato.Text);
                    var response2 = client.Execute(request2);

                    main.Mensaje("Eliminar", "Contrato Eliminado con exito");
                    LimpiarCampos();
                    CargarTabla();
                }
                else if (messageBox == MessageBoxResult.No)
                {
                    main.Mensaje("Eliminar","Contrato no eliminado");
                }
                
            }
            else
            {
                main.Mensaje("Error al Eliminar", "Error, Contrato no encontrado");
            }
        }
    }
}
