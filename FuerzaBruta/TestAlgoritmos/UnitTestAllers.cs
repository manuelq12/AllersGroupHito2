using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuerzaBruta;

namespace TestAlgoritmos
{
    [TestClass]
    public class UnitTestAllers
    {
        Controlador controlador;
      public void Escenario()
        {
            controlador = new Controlador();
        }

        [TestMethod]
        public void TestCargarArticulos()
        {
            Escenario();
            Assert.IsNotNull(controlador.Articulos);
        }

        [TestMethod]
        public void TestCargarClientes()
        {
            Escenario();
            Assert.IsNotNull(controlador.Clientes);

        }

        [TestMethod]
        public void TestCargarVentas()
        {
            Escenario();
            Assert.IsNotNull(controlador.Ventas);
        }


    }
}
