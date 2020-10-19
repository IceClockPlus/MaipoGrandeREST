using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibreriaMaipo;
using System.Collections.Generic;
using LibreriaMaipo.Modelo;

namespace TestingMaipoGrande
{
    [TestClass]
    public class TestDetallePedido
    {
        [TestMethod]
        public void BuscarDetallePedidoPorIdPedido()
        {
            //Arrange
            int idPedido = 1003;
            List<ItemPedido> listado = new List<ItemPedido>();

            //Act
            listado = RepositorioDetallePedido.ObtenerDetallePedido(idPedido);

            //Assert
            Assert.IsNotNull(listado);

        }
    }
}
