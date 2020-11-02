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
    }
}
