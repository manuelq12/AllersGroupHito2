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
            //sdad
            Controlador controlador = new Controlador();
            Console.WriteLine("Numero de articulos: "+controlador.Articulos.Count());
            Console.WriteLine("Numero de clientes: " + controlador.Clientes.Count());
            Console.WriteLine("Numero de ventas: " + controlador.Ventas.Count());
            Console.ReadLine();
        }
    }
}
