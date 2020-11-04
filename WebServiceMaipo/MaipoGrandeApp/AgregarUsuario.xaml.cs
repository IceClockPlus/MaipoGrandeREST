using LibreriaMaipo.Modelo;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Lógica de interacción para AgregarUsuario.xaml
    /// </summary>
    public partial class AgregarUsuario : Page
    {
        public AgregarUsuario()
        {
            InitializeComponent();
            CargarTabla();
            cargarCB();
        }

        private void CbRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuario user = new Usuario
                {
                    NombreUsuario = txtAgregarUsuario.Text,
                    Contrasenia = txtAgregarContraseña.Text,
                    IsHabilitado = txtHabilitar.Text,
                    Rol = new Rol
                    {
                        IdRol = CbRol.SelectedIndex + 1
                    },
                    Correo = txtCorreo.Text
                };

                HttpClient client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                var response = client.PostAsync("http://localhost:54192/api/Usuario", content).Result;


                Console.WriteLine(response);


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    

                    MessageBox.Show("Usuario agregado con exito", "Usuario");
                    LimpiarCampos();
                    CargarTabla();
                }
                else
                {
                    MessageBox.Show("Usuario no agregado", "Usuario");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }

        private void cargarCB() 
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Rol", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var rols = JsonConvert.DeserializeObject<List<Rol>>(response.Content);
                foreach (var item in rols)
                {
                    CbRol.Items.Add(item.NombreRol);
                }

            }
        }

        private void CargarTabla()
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Usuario", Method.GET);
            var response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var usuarios = JsonConvert.DeserializeObject<List<Usuario>>(response.Content);
                dataPerfiles.ItemsSource = usuarios;
            }
        }

        private void DeshabilitarBtn()
        {
            txtAgregarUsuario.IsEnabled = false;
            txtAgregarContraseña.IsEnabled = false;
            txtCorreo.IsEnabled = false;
            txtHabilitar.IsEnabled = false;
            CbRol.IsEnabled = false;
            
        }

        private void HabilitarBtn()
        {
            txtAgregarUsuario.IsEnabled = true;
            txtAgregarContraseña.IsEnabled = true;
            txtCorreo.IsEnabled = true;
            txtHabilitar.IsEnabled = true;
            CbRol.IsEnabled = true;
        }

        private void LimpiarCampos()
        {
            txtAgregarUsuario.Clear();
            txtAgregarContraseña.Clear();
            txtCorreo.Clear();
            txtHabilitar.Clear();
            CbRol.SelectedIndex = 0;
        }
    }
}
