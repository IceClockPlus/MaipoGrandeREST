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
            _reportViewer.Load += ReportViewer_Load;
            main = m;
        }


        public List<DocumentoVenta> ObtenerDocumentosVenta()
        {
            try
            {
                List<DocumentoVenta> docs = new List<DocumentoVenta>();

                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/DocumentoVenta", Method.GET);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var documentos = JsonConvert.DeserializeObject<List<DocumentoVenta>>(response.Content);
                    docs = documentos;
                }
                return docs;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<DocumentoVenta>();
            }
        }


        private void ReportViewer_Load(object sender, EventArgs e)
        {
            
            List<DocumentoVenta> list = new List<DocumentoVenta>();
            //dataset = this.ObtenerDocumentosVenta();
            list = this.ObtenerDocumentosVenta();

            List<VentasReportes> dataset = new List<VentasReportes>();
            foreach(var doc in list) {

                VentasReportes vr = new VentasReportes();
                vr.IdDocumento = doc.IdDocumento;
                vr.FechaEmision = doc.FechaEmision;
                vr.Pais = doc.Pedido.Pais;
                vr.Cliente = doc.Pedido.Cliente.Nombre;
                vr.EstadoDocumento = doc.EstadoDocumento.Descripcion;
                vr.PrecioProducto = doc.PrecioProducto;
                vr.PrecioTransporte = doc.PrecioTransporte;
                vr.Impuesto = doc.Impuesto;
                vr.Subtotal = doc.Subtotal;
                vr.Total = doc.Total;
                dataset.Add(vr);
            }


            _reportViewer.LocalReport.DataSources.Clear();
            var rpds_model = new ReportDataSource() { Name = "VentasClienteDS", Value = dataset };
            _reportViewer.LocalReport.DataSources.Add(rpds_model);

            this._reportViewer.LocalReport.ReportEmbeddedResource = "MaipoGrandeApp.ReporteVentasCliente.rdlc";

            _reportViewer.Refresh();
            _reportViewer.RefreshReport();


            //fill data into adventureWorksDataSet


            
        }



    }
}
