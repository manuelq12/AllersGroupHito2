using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuerzaBruta;

namespace TestAlgoritmos
{
    [TestClass]
    public class UnitTestAllers
    {

        Controlador relacionControlador = new Controlador();


        [TestMethod]
        public void TestCargarArticulos()
        {
            try
            {
                relacionControlador.cargarArticulosP();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }     
        }

        [TestMethod]
        public void TestCargarClientes()
        {
            try
            {
                relacionControlador.cargarClientesP();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestCargarVentas()
        {
            try
            {
                relacionControlador.cargarVentasP();
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.Fail();
            }
        }


    }
}
