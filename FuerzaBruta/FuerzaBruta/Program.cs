﻿using System;
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
            List<List<Articulo>> resultado = controlador.Combinacion();
            resultado.ForEach(a => controlador.MostrarCombinaciones(a));
            Console.WriteLine(resultado.Count());
            Console.ReadLine();
        }
    }
}
