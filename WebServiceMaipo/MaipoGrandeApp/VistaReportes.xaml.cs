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
using System.IO;
using System.Globalization;

namespace MaipoGrandeApp
{
    /// <summary>
    /// Lógica de interacción para IngresarVenta.xaml
    /// </summary>
    public partial class VistaReportes : Page
    {

        private List<VentasReportes> ventas = new List<VentasReportes>();

        MenuPrincipal main;
        public VistaReportes(MenuPrincipal m)
        {
            InitializeComponent();
            CargarComboReportes();
            _reportViewer.Load += ReportViewer_Load;
            main = m;
        }

        public void CargarComboReportes()
        {
            IEnumerable<string> reportes = Enumerable.Empty<string>();
            reportes = new string[] { "Ventas Cliente", "Encuestas"};
            CbxReportes.ItemsSource = reportes;

        }

        /// <summary>
        /// Metodo para obtener los datos de las ventas
        /// </summary>
        /// <returns></returns>
        public void ObtenerDocumentosVenta()
        {
            try
            {
                List<VentasReportes> docs = new List<VentasReportes>();

                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/DocumentoVenta", Method.GET);
                var response = client.Execute(request);
                //Se carga los datos de las ventas
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var documentos = JsonConvert.DeserializeObject<List<DocumentoVenta>>(response.Content);
                    documentos = documentos.Where(d => d.FechaEmision != null).ToList();
                    foreach(DocumentoVenta doc in documentos)
                    {
                        VentasReportes vr = new VentasReportes();
                        vr.IdDocumento = doc.IdDocumento;
                        vr.FechaEmision = (DateTime)doc.FechaEmision;
                        vr.Pais = doc.Pedido.Pais;
                        vr.Cliente = doc.Pedido.Cliente.Nombre;
                        vr.EstadoDocumento = doc.EstadoDocumento.Descripcion;
                        vr.MesAnno = vr.FechaEmision.ToString("M/yyyy", CultureInfo.CurrentCulture);
                        vr.PrecioProducto = doc.PrecioProducto;
                        vr.PrecioTransporte = doc.PrecioTransporte;
                        vr.Impuesto = doc.Impuesto;
                        vr.Subtotal = doc.Subtotal;
                        vr.Total = doc.Total;
                        ventas.Add(vr);
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Metodo para obtener todas las encuestas de satisfaccion
        /// </summary>
        /// <returns></returns>
        public List<Encuesta> ObtenerEncuestas()
        {
            try
            {

                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/Encuesta", Method.GET);
                var response = client.Execute(request);

                List<Encuesta> list = JsonConvert.DeserializeObject<List<Encuesta>>(response.Content);
                return list;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Encuesta>();
            }
        }


        /// <summary>
        /// Metodo para llenar el dataset del subinforme VentasCliente  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SubVentasClienteSubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (ventas == null)
                ObtenerDocumentosVenta();
            e.DataSources.Add(new ReportDataSource("VentasClienteDS", ventas));
            e.DataSources.Add(new ReportDataSource("VentasGraficoDS", ventas));
            e.DataSources.Add(new ReportDataSource("HistoricoVentaClienteDS", ventas));
        }

        /// <summary>
        /// Evento para llenar el dataset para los subinformes de Encuestas de Satisfaccion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ReporteEncuestaSubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            //Llamar al metodo para obtener las encuestas del servicio REST
            List<Encuesta> dataset = this.ObtenerEncuestas();
            //Asignar los datos al datasource de los subinformes
            e.DataSources.Add(new ReportDataSource("EncuestaDS", dataset));
            e.DataSources.Add(new ReportDataSource("EncuestaGraficoDS", dataset));

        }


        private void ReportViewer_Load(object sender, EventArgs e)
        {
            
            List<VentasReportes> dataset = new List<VentasReportes>();
            ObtenerDocumentosVenta();
            dataset = ventas;    

            //_reportViewer.LocalReport.DataSources.Clear();
            var rpds_model = new ReportDataSource() { Name = "DataVentas", Value = ventas };
            _reportViewer.LocalReport.DataSources.Add(rpds_model);

            //Obtener la url de la solucion de escritorio y concatenar con la ubicacion del reporte 
            //string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName+ "\\Reportes\\VentasCliente\\ReporteVenta.rdlc";

            //Establecer ubicacion del reporte principal
            //this._reportViewer.LocalReport.ReportPath = startupPath;

            //Llamar evento para llenar los datos de los subinformes
            

        }


        private void CbxReportes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string reporte = CbxReportes.SelectedItem.ToString();
            //Establecer ubicacion del archivo del proyecto MaipoGrandeApp
            string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            
            switch (reporte)
            {
                case "Ventas Cliente":
                    startupPath += "\\Reportes\\VentasCliente\\ReporteVenta.rdlc";
                    this._reportViewer.LocalReport.ReportPath = startupPath;
                    this._reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubVentasClienteSubreportProcessing);
                    break;
                case "Encuestas":
                    startupPath += "\\Reportes\\EncuestaSatisfaccion\\ReporteEncuesta.rdlc";
                    this._reportViewer.LocalReport.ReportPath = startupPath;
                    this._reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(ReporteEncuestaSubreportProcessing);
                    break;
                default:
                    break;
            }


            //Obtener la url de la solucion de escritorio y concatenar con la ubicacion del reporte 
            //string startupPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Reportes\\VentasCliente\\ReporteVenta.rdlc";

            //Establecer ubicacion del reporte principal
            //this._reportViewer.LocalReport.ReportPath = startupPath;

            _reportViewer.Refresh();
            _reportViewer.RefreshReport();
        }
    }
}
