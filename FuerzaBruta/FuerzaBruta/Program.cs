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
            controlador.CargarDatos();
            List<List<int>> numeros = controlador.Combinacion();
            numeros.ForEach(i => controlador.ImprimirCombinaciones(i));
            var lista = CountList(numeros);
           
            Console.WriteLine();
            Console.ReadLine();
        }
        public static List<List<int>> CountList(List<List<int>> input)
        {
            List<List<int>> returnListList = new List<List<int>>();
            foreach (List<int> list in input)
                list.Sort();
            HashSet<int> alreadyMatched = new HashSet<int>();
            int count = 0;
            bool match = true;
            int lastEval = 0;
            for (int i = 0; i < input.Count - 1; i++)
            {
                if (alreadyMatched.Contains(i))
                    continue;
                returnListList.Add(input[i]);
                count = 1;
                lastEval = 0;
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (alreadyMatched.Contains(j))
                        continue;
                    lastEval = j;
                    if (input[i].Count() != input[j].Count())
                        continue;
                    match = true;
                    for (int k = 0; k < input[i].Count(); k++)
                    {
                        if (input[i][k] != input[j][k])
                        {
                            match = false;
                            break;
                        }
                    }
                    if (match)
                    {
                        count++;
                        alreadyMatched.Add(j);
                    }
                }
                Console.WriteLine("Count = {0}  List {1}", count, string.Join(", ", input[i]));
            }
            if (count == 1 && lastEval > 0)
            {
                Console.WriteLine("Count = {0}  List {1}", 1, string.Join(", ", input[lastEval]));
                returnListList.Add(input[lastEval]);
            }
            return returnListList;
        }
    }
}
