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
            List<List<int>> numeros = controlador.CombinacionPrueba();
            int count = numeros.Count();

            List<int> b= new List<int>();
            int mayor=0;

            foreach (var a in numeros)
            {
                int contador = controlador.RepeticionEnVentas(a);
                if (contador>mayor)
                {
                b = a;
                mayor=contador; 
                }
            }

            String mensaje = "";

            for (int i = 0; i < b.Count; i++)
            {
                mensaje += b[i]+ " ";
            }
            Console.WriteLine("La combinacion "+ mensaje +"Con las siguientes repeticiones "+mayor);
            Console.ReadLine();

        }

    }
}
