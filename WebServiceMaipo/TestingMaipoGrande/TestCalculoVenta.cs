using LibreriaMaipo.Modelo;
using LibreriaMaipo.Proceso;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestingMaipoGrande
{
    [TestClass]
    public class TestCalculoVenta
    {
        [TestMethod]
        public void TestCalculoTotalProductos()
        {
            //Arrange
            DocumentoVenta documento = new DocumentoVenta();
            documento.IdDocumento = 22;
            documento.Read();

            CalculoVenta calculoVenta = new CalculoVenta();
            calculoVenta.DocumentoVenta = documento;

            //Act
            decimal totalproducto = calculoVenta.CalcularCostoProductos();

            //Assert
            Assert.AreEqual(660, totalproducto);
        }

        [TestMethod]
        public void TestCalculoTotalTransporte()
        {
            //Arrange

            DocumentoVenta documento = new DocumentoVenta();
            documento.IdDocumento = 21;
            documento.Read();

            CalculoVenta calculoVenta = new CalculoVenta();
            calculoVenta.DocumentoVenta = documento;

            //Act
            decimal totaltransporte = calculoVenta.CalcularCostoTransporte();

            //Assert
            Assert.AreEqual(500, totaltransporte);

        }

        [TestMethod]
        public void TestCalculoSubtotal()
        {
            //Arrange
            DocumentoVenta documento = new DocumentoVenta();
            documento.PrecioProducto = 1110;
            documento.PrecioTransporte = 510;

            CalculoVenta calculoVenta = new CalculoVenta();
            calculoVenta.DocumentoVenta = documento;

            //Act
            decimal subtotal = calculoVenta.CalcularSubtotal();

            //Assert
            Assert.AreEqual(1620, subtotal);

        }

        [TestMethod]
        public void TestCalculoImpuesto() {

            //Arrange
            DocumentoVenta documento = new DocumentoVenta();
            documento.Subtotal = 1300;

            CalculoVenta calculoVenta = new CalculoVenta();
            calculoVenta.DocumentoVenta = documento;

            //Act
            decimal impuesto = calculoVenta.CalcularImpuesto();

            //Assert
            Assert.AreEqual(247,impuesto);

        }


        [TestMethod]
        public void TestCalculoTotal()
        {
            //Arrange
            DocumentoVenta documento = new DocumentoVenta();
            documento.Subtotal = 1300;
            documento.Impuesto = 247;

            CalculoVenta calculoVenta = new CalculoVenta();
            calculoVenta.DocumentoVenta = documento;

            //Act
            decimal total = calculoVenta.CalcularTotal();

            //Assert
            Assert.AreEqual(1547, total);

        }

    }
}
