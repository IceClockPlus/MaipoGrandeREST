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

                ex.StackTrace.ToString();
            }
        }
    }
}
