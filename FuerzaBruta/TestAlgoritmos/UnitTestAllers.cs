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
            String rutaArticulos = "../../Data/Articulos.csv";
            

            
            


        }

        [TestMethod]
        public void TestCargarClientes()
        {
            String rutaCliente = "../../Data/Clientes.csv";

           



        }

        [TestMethod]
        public void TestCargarVentas()
        {

            String rutaVentas = "../../Data/Ventas.csv";

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
