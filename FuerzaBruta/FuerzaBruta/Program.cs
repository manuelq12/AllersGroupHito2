using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
   public class Program
    {
      
        static void Main(string[] args)
        {
            //listo
            Controlador controlador = new Controlador();
            controlador.CargarDatosPrueba();


            controlador.generarAsociaciones();

            //int[] codigos = { 1,2,3,4,5,6}; 
            //List<List<int>> numeros = controlador.CombinacionHasta7(2,codigos);


            //Console.WriteLine(controlador.getNumVentas());

            //foreach (var d in numeros)
            //{
            //    controlador.ImprimirCombinaciones(d);
            //}

            //int count = numeros.Count();

            //List<int> b= controlador.RepeticionEnVentas(numeros);

            //foreach (var e in b)
            //{
            //    Console.WriteLine(e);
            //}
            //Console.ReadLine();

        }

    }
}
