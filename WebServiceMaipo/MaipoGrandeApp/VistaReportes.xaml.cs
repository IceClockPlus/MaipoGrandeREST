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
using Microsoft.Reporting.WinForms;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para IngresarVenta.xaml
    /// </summary>
    public partial class VistaReportes : Page
    {
        MenuPrincipal main;
        public VistaReportes(MenuPrincipal m)
        {
            InitializeComponent();
            main = m;
        }

    }
}
