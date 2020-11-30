using System;
using LibreriaMaipo;
using LibreriaMaipo.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingMaipoGrande
{
    [TestClass]
    public class TestPedido
    {
        [TestMethod]
        public void BuscarPedidoPorId()
        {
            int idPedido = 11;
            Pedido pedido = RepositorioPedido.ObtenerPedidoPorId(idPedido);

            Assert.IsNotNull(pedido);

        }

        [TestMethod]
        public void AgregarPedido()
        {
            //Arrange
            Pedido pedido = new Pedido();
            pedido.FechaPedido = DateTime.Now;
            pedido.FechaEntrega = null;
            pedido.EstadoPedido.IdEstado = 1;
            pedido.Cliente.Id = 19191651;
            pedido.Direccion = "Direccion Test";
            pedido.Ciudad = "Ciudad Test";
            pedido.Pais = "Pais Test";

            //Act
            bool result = pedido.Insert();

            //Assert
            Assert.IsTrue(result);

        }


    }
}
