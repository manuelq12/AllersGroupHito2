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
            controlador.CargarDatos();
            List<List<int>> numeros = controlador.Combinacion();
            numeros.ForEach(i => controlador.ImprimirCombinaciones(i));


            //Console.WriteLine("Cantidad Lista 1: "+controlador.repetecionEnVentas(numeros[0]));
            Console.WriteLine("Cantidad Lisa 1: " + controlador.repeticionesEnVentas2222(numeros[5]));

            Console.ReadLine();

        }

    }
}
