using System;
using System.Collections.Generic;
using System.Linq;
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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using System.Net.Http;
using Newtonsoft.Json;
using RestSharp;
using LibreriaMaipo.Modelo;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private async void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            RestClient client = new RestClient("http://localhost:54192/api");


            RestRequest request = new RestRequest("/Access/Login", Method.POST);
            request.AddParameter("nombreUsuario", txtUsuario.Text);
            request.AddParameter("contrasenia", txtContraseña.Password);
            IRestResponse response = client.Execute(request);
            var result = response.Content;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //Convertir datos Json en el objeto usuario
                var usuario = JsonConvert.DeserializeObject<Usuario>(result);

                //Validar que el usuario este habilitado
                if (this.VerificarHabilitado(usuario.IsHabilitado) == true)
                {
                    //Generar la vista en base al rol del usuario conectado
                    switch (usuario.NombreRol)
                    {
                        case "Administrador":
                            this.MostrarVistaAdmin(usuario);
                            break;
                        case "Consultor":
                            this.MostrarVistaConsultor(usuario);
                            break;
                        default:
                            await this.ShowMessageAsync("Error", "Usuario no permitido");
                            break;
                    }
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Usuario no habilitado");
                }
        
            }
            else
            {
                await this.ShowMessageAsync("Inicio sesion", "Datos no validos");
            }

        }

        /// <summary>
        /// Valida si el usuario esta habilitado
        /// </summary>
        /// <param name="habilitado"></param>
        /// <returns></returns>
        public Boolean VerificarHabilitado(string habilitado)
        {
            if (habilitado.Equals("0"))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Generar la vista para el usuario administrador
        /// </summary>
        /// <param name="usr"></param>
        public void MostrarVistaAdmin(Usuario usr)
        {
            this.Visibility = Visibility.Hidden;
            MenuPrincipal menu = new MenuPrincipal(usr);
            menu.Title = "Administrador";
            menu.Visibility = Visibility.Visible;
            menu.btnReportes.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Generar vista para el usuario consultor
        /// </summary>
        /// <param name="usr"></param>
        public void MostrarVistaConsultor(Usuario usr)
        {
            this.Visibility = Visibility.Hidden;
            MenuPrincipal menu = new MenuPrincipal(usr);
            menu.Title = "Consultor";
            menu.Visibility = Visibility.Visible;
            menu.btnGrafico.Visibility = Visibility.Hidden;
            menu.btnPerfilUsuario.Visibility = Visibility.Hidden;
            menu.btnPerfiTransporte.Visibility = Visibility.Hidden;
            menu.btnTienda.Visibility = Visibility.Hidden;
        }
    }
}
