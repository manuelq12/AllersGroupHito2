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
            int count = numeros.Count();

            numeros.ForEach(n => controlador.RepeticionEnVentas(n));

            //List<int> combinacion = new List<int>();
            //combinacion = numeros[0];
            //int cant = controlador.RepeticionEnVentasP(combinacion);
            //Console.WriteLine("Cantidad : {0}", cant);

            Console.ReadLine();

        }

    }
}
