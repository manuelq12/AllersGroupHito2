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
            int[] itemCode = { 1, 2, 3, 4, 5, 6 };
            List<List<int>> numeros = controlador.CombinacionHasta7(2,itemCode);
            int count = controlador.Ventas.GroupBy(n=> n.CardCode).Count();

            List<int> b = controlador.RepeticionEnVentas(numeros);
            List<double> porcentajes = controlador.Support(b);

            Console.WriteLine("Combinaciones \n");
            numeros.ForEach(x => controlador.ImprimirCombinaciones(x));

            Console.WriteLine("Repeticiones \n");
            controlador.ImprimirCombinaciones(b);

            Console.WriteLine("Tamaño \n");
            Console.WriteLine( count +  " \n");

            Console.WriteLine("Porcentajes \n");
            controlador.ImprimirPorcentajes(porcentajes);


        }

    }
}
