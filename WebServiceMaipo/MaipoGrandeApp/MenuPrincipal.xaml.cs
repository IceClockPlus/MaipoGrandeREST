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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using RestSharp;
using LibreriaMaipo.Modelo;
using System.Windows.Threading;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para MenuPrincipal.xaml
    /// </summary>
    public partial class MenuPrincipal : MetroWindow
    {
        public Usuario main;
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        public MenuPrincipal(Usuario usr)
        {
            this.main = usr;
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e) 
        {
            lbHora.Content = DateTime.Now.ToLongTimeString();
        }

        public async void Mensaje(string titulo, string mensaje) 
        {
            await this.ShowMessageAsync(titulo,mensaje);
        }
        private void btnPerfilUsuario_Click(object sender, RoutedEventArgs e)
        {
            frameMenu.Content = new AgregarUsuario();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            RestClient client = new RestClient("http://localhost:54192/api");
            RestRequest request = new RestRequest("/Logout/Logout", Method.POST);
            request.AddParameter("token", main.Token);
            try
            {
                IRestResponse response = client.Execute(request);
                var result = response.Content;


                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    main = new Usuario();
                    this.Close();
                    MainWindow login = new MainWindow();
                    login.Visibility = Visibility.Visible;
                    
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                ex.StackTrace.ToString();
            }
        }

        private void btnSubastas_Click(object sender, RoutedEventArgs e)
        {
            frameMenu.Content = new SubastasTransporte(this);
        }

        private void btnContratos_Click(object sender, RoutedEventArgs e)
        {
            frameMenu.Content = new ControlarContratos(this);
        }

        private void btnNotificarEstadoVenta_Click(object sender, RoutedEventArgs e)
        {
            frameMenu.Content = new NotificarEstado();
        }

        private void btnVenta_Click(object sender, RoutedEventArgs e)
        {
            frameMenu.Content = new RevisarPedidos(this);
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            if (main.NombreRol == "Ejecutivo")
            {
                frameMenu.Content = new ProcesoVenta(this);
            }
                        
        }
    }
}
