using System;
using System.Collections.Generic;
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
            List<List<int>> numeros = controlador.Combinacion();
            numeros.ForEach(i => controlador.ImprimirCombinaciones(i));
            Console.WriteLine(numeros[0][0]);
            Console.ReadLine();
        }
    }
}
