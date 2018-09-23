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


            Escenario();
            int[] arreglo = { 1, 2, 3 };
            List<List<int>> listResult = new List<List<int>>();
            listResult = controlador.CombinacionP(arreglo);
            List<int> comExistente = new List<int>() { 1, 3, 2 };
            List<int> combinacion = new List<int>();

            for (int i=0; i<listResult.Count;i++)
            {
                combinacion = listResult[i];
                for (int j=0; j<combinacion.Count;j++)
                {
                    if (combinacion[j]==comExistente[j])
                    {
                        Assert.AreEqual(combinacion[j], comExistente[j]);
                    }

                }

            }

        }

        [TestMethod]
        public void TestCantCombinaciones()
        {
            //Crear un list con dos products
            //Dice cuantas veces esta esa asociación 

            Escenario();
            List<Articulo> combinacion = new List<Articulo>();
            Articulo producto1 = new Articulo(524, "TIJERA IRIS RECTA 11 cm" , 1);
            Articulo producto2 = new Articulo(514, "TIJERA LITAUER PUNTOS 14 cm", 2);
            Articulo producto3 = new Articulo(524, "PINZA MOSQUITO CURVA 12.5 cm", 7);

            combinacion.Add(producto1);
            combinacion.Add(producto2);
            combinacion.Add(producto3);


            //Crear 3 productos con ItemSet 524 514 552



           // int cantRepeticiones = 0;
           // cantRepeticiones = controlador.repetecionEnVentas(combinacion);
           // Assert.AreEqual(cantRepeticiones, 1);     


        }


    }
}
