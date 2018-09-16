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
            //String rutaArticulos = "../../Data/Articulos.csv";


            try
            {
                relacionControlador.cargarArticulosP();
               Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }

            
            


        }

        [TestMethod]
        public void TestCargarClientes()
        {
           // String rutaCliente = "../../Data/Clientes.csv";

            try
            {
                relacionControlador.cargarClientesP();
                Assert.IsTrue(true);
            }
            catch(Exception e)
            {
                Assert.IsTrue(false);
            }


        }

        [TestMethod]
        public void TestCargarVentas()
        {

            //String rutaVentas = "../../Data/Ventas.csv";

            try
            {
                relacionControlador.cargarClientesP();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                Assert.IsTrue(false);
            }




        }



    }
}
