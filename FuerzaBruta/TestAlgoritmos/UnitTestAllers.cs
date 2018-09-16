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
            String rutaArticulos = "../../BasesDatos/Articulos.csv";

            try
            {
            relacionControlador.cargarArticulosP(rutaArticulos);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            


        }

        [TestMethod]
        public void TestCargarClientes()
        {
            String rutaCliente = "../../BasesDatos/Clientes.csv";
            try
            {
                relacionControlador.cargarClientesP(rutaCliente);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
            



        }

        [TestMethod]
        public void TestCargarVentas()
        {

            String rutaVentas = "../../BasesDatos /Ventas.csv";

            try
            {
                relacionControlador.cargarVentasP(rutaVentas);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }




        }



    }
}
