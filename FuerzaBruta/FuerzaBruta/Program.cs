using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
    class Program
    {
       private Controlador controlador;

        public static Controlador Controlador { get; private set; }

        static void Main(string[] args)
        {
            Controlador = new Controlador();

        }
    }
}
