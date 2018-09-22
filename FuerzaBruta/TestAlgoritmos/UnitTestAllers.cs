using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FuerzaBruta;
using System.Collections.Generic;

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
            try
            {
                controlador.CargarArticulos();
                Assert.IsNotNull(controlador.Articulos);
            }
            catch
            {
                Assert.Fail();
            }


        }

        [TestMethod]
        public void TestCargarClientes()
        {
            Escenario();
            try
            {
                controlador.CargarClientes();
                Assert.IsNotNull(controlador.Clientes);
                
            }
            catch
            {
                Assert.Fail();
            }



        }

        [TestMethod]
        public void TestCargarVentas()
        {
            Escenario();

            try
            {
                controlador.CargarVentas();
                Assert.IsNotNull(controlador.Ventas);
            }
            catch
            {
                Assert.Fail();
            }
        }


        [TestMethod]
        public void TestCombinar()
        {
           // Escenario();
            int[] arreglo = { 1, 2, 3, 4, 5, 6, 7, 8 };

            List<List<int>> listResult = new List<List<int>>();
            listResult = controlador.CombinacionP(arreglo);

            //Combinaciones
            List<int> combinacionExistente = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> combinacion = new List<int>();

            for (int i= 0; i< listResult.Count; i++ ) //Recorrer lista de listas
            {
                combinacion = listResult[i];

                for (int j=0; j<combinacion.Count;j++) // Recorrer elementos de una lista
                {
                    Assert.AreEqual(combinacion[j], combinacionExistente[j]);
                }



            }

        
        }

    }
}
