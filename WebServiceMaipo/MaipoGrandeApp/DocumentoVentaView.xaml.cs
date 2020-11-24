using LibreriaMaipo.Modelo;
using LibreriaMaipo.Proceso;
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
    /// Lógica de interacción para DocumentoVentaView.xaml
    /// </summary>
    public partial class DocumentoVentaView : Page
    {
        private MenuPrincipal main;

        public DocumentoVentaView(MenuPrincipal m)
        {
            main = m;
            InitializeComponent();
            this.CargarTablaDocumento();
            gridPedido.Visibility = Visibility.Hidden;
        }

        public void CargarTablaDocumento()
        {
            dataDocumento.ItemsSource = null;
            CalculoVenta calculador = new CalculoVenta();
            try
            {
                RestClient client = new RestClient("http://localhost:54192/api");
                RestRequest request = new RestRequest("/DocumentoVenta", Method.GET);
                var response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var documentos = JsonConvert.DeserializeObject<List<DocumentoVenta>>(response.Content);
                    List<DocumentoVenta> docs = new List<DocumentoVenta>();
                    foreach(DocumentoVenta doc in documentos)
                    {
                        calculador.DocumentoVenta = doc;
                        calculador.CalcularPreciosDocumento();
                        docs.Add(doc);

                    }

                    dataDocumento.ItemsSource = docs;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void BtnRevisar_Click(object sender, RoutedEventArgs e)
        {
            DocumentoVenta documento = (DocumentoVenta)dataDocumento.SelectedItem;
            if(documento != null)
            {
                //Si el grid del pedido no esta  visible, se hace visible
                if(gridPedido.Visibility == Visibility.Hidden)
                {
                    gridPedido.Visibility = Visibility.Visible;
                }

                this.MostrarDatosPedido(documento.Pedido);

            }
            else
            {
                main.Mensaje("Aviso", "Debe seleccionar un documento para revisarlo");
            }

        }

        /// <summary>
        /// Mostrar los datos del pedido en el grid gridPedido
        /// </summary>
        /// <param name="pedido"></param>
        public void MostrarDatosPedido(Pedido pedido)
        {
            txtIdPedido.Content = pedido.IdPedido;
            txtDireccion.Content = pedido.Direccion;
            txtCiudad.Content = pedido.Ciudad;
            txtPais.Content = pedido.Pais;
            txtCliente.Content = pedido.Cliente.Nombre;
            txtEstado.Content = pedido.EstadoPedido.DescripcionEstado;

            //Insertar listado de los items del pedido en la tabla
            dataDetalle.ItemsSource = pedido.DetallePedido;
        }

        public void ActualizarPedidoEstado(Pedido pedido)
        {
            try
            {
                pedido.EstadoPedido.IdEstado = 3;
                HttpClient client2 = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(pedido), Encoding.UTF8, "application/json");
                var response2 = client2.PutAsync("http://localhost:54192/api/PedidoPutEstado", content).Result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message) ;
            }
        }


        private void BtnHabilitarPago_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DocumentoVenta documento = (DocumentoVenta)dataDocumento.SelectedItem;
                if(documento != null)
                {
                    if(documento.Pedido.EstadoPedido.IdEstado == 10)
                    {
                        documento.FechaEmision = DateTime.Now;
                        HttpClient client2 = new HttpClient();
                        var content = new StringContent(JsonConvert.SerializeObject(documento), Encoding.UTF8, "application/json");
                        var response2 = client2.PutAsync("http://localhost:54192/api/DocumentoVenta", content).Result;

                        if(response2.StatusCode == HttpStatusCode.OK)
                        {
                            this.ActualizarPedidoEstado(documento.Pedido);
                            main.Mensaje("Pago Habilitado", "El pago del pedido " + documento.Pedido.IdPedido + " ha sido habilitado");

                        }
                        else
                        {
                            main.Mensaje("Aviso", "El pago del pedido no fue habilitado. Intente más tarde");

                        }



                    }
                    else
                    {
                        main.Mensaje("No Permitido", "El cliente debe confirmar la recepción para habilitar el pago");
                    }

                }
                else
                {
                    main.Mensaje("Aviso", "Debe seleccionar un documento de la lista");
                }


            }catch(Exception ex)
            {

            }

        }
    }
}
