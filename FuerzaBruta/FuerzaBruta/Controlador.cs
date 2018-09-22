using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuerzaBruta
{
    public class Controlador
    {
        public const String rutaArticulos = "../../Data/Articulos.csv";
        public const String rutaClientes = "../../Data/Clientes.csv";
        public const String rutaVentas = "../../Data/Ventas.csv";
        private List<Articulo> articulos;
        private List<Cliente> clientes;
        private List<Venta> ventas;

        List<List<Articulo>> combinaciones;



        public List<Articulo> Articulos { get => articulos; set => articulos = value; }
        public List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public List<Venta> Ventas { get => ventas; set => ventas = value; }


        public Controlador()
        {

            articulos = new List<Articulo>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();
            combinaciones = new List<List<Articulo>>();
            //cantRepeticionesPorGrupo(Combinacion());          
          
          

        }

        public void CargarDatos()
        {
            CargarArticulos();
            CargarClientes();
            CargarVentas();

        }

        public void CargarArticulos()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(rutaArticulos);
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] todo = line.Split(';');
                    if (todo.Length == 3 && !todo.ToList().Any(r => r.Equals("")))
                    {
                        int itemCode = Int16.Parse(todo[0]);
                        String itemName = todo[1];
                        int itemClasification = Int16.Parse(todo[2]);
                        articulos.Add(new Articulo(itemCode, itemName, itemClasification));
                    }

                }
                sr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al cargar los articulos");
            }
        }
        public void CargarClientes()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(rutaClientes);
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] todo = line.Split(';');
                    if (todo.Length == 5 && !todo.ToList().Any(r => r.Equals("")))
                    {
                        String cardCode = todo[0];
                        String groupName = todo[1];
                        String city = todo[2];
                        String department = todo[3];
                        String paymentGroup = todo[4];
                        clientes.Add(new Cliente(cardCode, groupName, city, department, paymentGroup));
                    }
                }
                sr.Close();
            }
            catch
            {
                throw new Exception("Error al cargar los Clientes");
            }
        }
        public void CargarVentas()
        {
            String line;
            string uno="";
            string dos="";
            string tres="";
            try
            {

                StreamReader sr = new StreamReader(rutaVentas);
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] todo = line.Split(';');
                    if (todo.Length == 8 && !todo.ToList().Any(r => r.Equals("")))
                    {
                        String cardCode = todo[0];
                        String docNum = todo[1];
                        String[] tiempo = todo[2].Split('/');
                        int ano = Convert.ToInt32(tiempo[2]);
                        int mes = Convert.ToInt32(tiempo[1]);
                        int dia = Convert.ToInt32(tiempo[0]);
                        DateTime docDate = new DateTime(ano, mes, dia);

                        String docTotal = todo[3];
                        String itemCode = todo[4];
                        uno = todo[5];
                        dos = todo[6];
                        tres = todo[7];
                        int cantidad = Convert.ToInt32(todo[5]);
                        int precio = Convert.ToInt32(todo[6]);
                        double totalVenta = Convert.ToInt64(todo[7]);
                        ventas.Add(new Venta(cardCode, docNum, docDate,docTotal, itemCode, cantidad, precio, totalVenta));
                    }
                }
                sr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error al cargar las Ventas");
            }
        }
        public void ImprimirCombinaciones(List<int> n)
        {
            String mensaje = "";
            int tamanho = n.Count();
            for (int i = 0; i < tamanho; i++)
            {
                mensaje += (i + 1) + ". " + n.ElementAt(i) + "\n";
            }
          
        }

        public List<List<int>> Combinacion()
        {
            List<List<int>> resultado = new List<List<int>>();
            int[] code = MasFrecuentes();

            for (int i = 0; i < code.Length; i++)
            {
                for (int j = i + 1; j < code.Length; j++)
                {
                    for (int k = j + 1; k < code.Length; k++)
                    {
                        for (int l = k + 1; l < code.Length; l++)
                        {
                            for (int m = l + 1; m < code.Length; m++)
                            {
                                for (int n = m + 1; n < code.Length; n++)
                                {
                                    for (int o = n + 1; o < code.Length; o++)
                                    {
                                        List<int> combinacion = new List<int>();
                                        combinacion.Add(code[i]);
                                        combinacion.Add(code[j]);
                                        combinacion.Add(code[k]);
                                        combinacion.Add(code[l]);
                                        combinacion.Add(code[m]);
                                        combinacion.Add(code[n]);
                                        combinacion.Add(code[o]);
                                        resultado.Add(combinacion);
                                    }

                                }

                            }

                        }

                    }

                }
            }
            return resultado;
        }
        public int repetecionEnVentas(List<int> combinacion)
        {
            int contador = 0;
            int aux = 0;
            for (int i = 0; i < ventas.Count(); i++)
            {
                if (ventas[i].ItemCode.Equals(combinacion[aux]+""))
                {
                    aux++;
                    if (aux == combinacion.Count())
                    {
                        aux = 0;
                        contador++;
                    }
                }
                else aux = 0;

            }
            return contador;
        }


        //Método supremamente extenso.
        public int[] MasFrecuentes()
        {
            List<int> todos = new List<int>();
            ventas.ForEach(i => todos.Add((int)Convert.ToDouble(i.ItemCode)));
            var group = todos.GroupBy(i => i);
            int max1 = 0;
            int id1 = 0;
            int max2 = -2;
            int id2 = 0;
            int max3 = -4;
            int id3 = 0;
            int max4 = 0;
            int id4 = 0;
            int max5 = -2;
            int id5 = 0;
            int max6 = -4;
            int id6 = 0;
            int max7 = 0;
            int id7 = 0;
            int max8 = -2;
            int id8 = 0;
            int max9 = -4;
            int id9 = 0;
            int max10 = 0;
            int id10 = 0;
            int max11 = -2;
            int id11 = 0;
            int max12 = -4;
            int id12 = 0;
            int max13 = 0;
            int id13 = 0;
            int max14 = -2;
            int id14 = 0;
            int max15 = -4;
            int id15 = 0;
            int max16 = 0;
            int id16 = 0;
            int max17 = -2;
            int id17 = 0;
            int max18 = -4;
            int id18 = 0;
            int max19 = 0;
            int id19 = 0;
            int max20 = -2;
            int id20 = 0;
            int max21 = -2;
            int id21 = 0;
            int max22 = -2;
            int id22 = 0;
            int max23 = -2;
            int id23 = 0;
            int max24 = 0;
            int id24 = -2;
            int max25 = 0;
            int id25 = -2;
            int max26 = 0;
            int id26 = -2;
            int max27 = 0;
            int id27 = -2;
            int max28 = 0;
            int id28 = -2;
            int temp = -30;
            foreach (IGrouping<int, int> n in group)
            {
                temp = n.Count();
                if (n.Key != -1)
                {
                    if (temp > max1)
                    {
                        max1 = temp;
                        id1 = n.Key;
                    }
                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                temp = n.Count();
                if (n.Key != id1 && n.Key != -1)
                {
                    if (temp < max1 && temp > max2)
                    {
                        max2 = temp;
                        id2 = n.Key;
                    }
                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max2 && temp > max3)
                    {
                        max3 = temp;
                        id3 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max3 && temp > max4)
                    {
                        max4 = temp;
                        id4 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max4 && temp > max5)
                    {
                        max5 = temp;
                        id5 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max5 && temp > max6)
                    {
                        max6 = temp;
                        id6 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max6 && temp > max7)
                    {
                        max7 = temp;
                        id7 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max7 && temp > max8)
                    {
                        max8 = temp;
                        id8 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max8 && temp > max9)
                    {
                        max9 = temp;
                        id9 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max9 && temp > max10)
                    {
                        max10 = temp;
                        id10 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max10 && temp > max11)
                    {
                        max11 = temp;
                        id11 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max11 && temp > max12)
                    {
                        max12 = temp;
                        id12 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max12 && temp > max13)
                    {
                        max13 = temp;
                        id13 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max13 && temp > max14)
                    {
                        max14 = temp;
                        id14 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max14 && temp > max15)
                    {
                        max15 = temp;
                        id15 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max15 && temp > max16)
                    {
                        max16 = temp;
                        id16 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max16 && temp > max17)
                    {
                        max17 = temp;
                        id17 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max17 && temp > max18)
                    {
                        max18 = temp;
                        id18 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max18 && temp > max19)
                    {
                        max19 = temp;
                        id19 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max19 && temp > max20)
                    {
                        max20 = temp;
                        id20 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max20 && temp > max21)
                    {
                        max21 = temp;
                        id21 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max21 && temp > max22)
                    {
                        max22 = temp;
                        id22 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max22 && temp > max23)
                    {
                        max23 = temp;
                        id23 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != id23 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max23 && temp > max24)
                    {
                        max24 = temp;
                        id24 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != id23 && n.Key != id24 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max24 && temp > max25)
                    {
                        max25 = temp;
                        id25 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != id23 && n.Key != id24 && n.Key != id25 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max25 && temp > max26)
                    {
                        max26 = temp;
                        id26 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != id23 && n.Key != id24 && n.Key != id25 && n.Key != id26 && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max26 && temp > max27)
                    {
                        max27 = temp;
                        id27 = n.Key;
                    }

                }
            }
            foreach (IGrouping<int, int> n in group)
            {
                if (n.Key != id1 && n.Key != id2 && n.Key != id3 && n.Key != id4 && n.Key != id5 && n.Key != id6 && n.Key != id7 && n.Key != id8 && n.Key != id9 &&
                    n.Key != id10 && n.Key != id11 && n.Key != id12 && n.Key != id13 && n.Key != id14 && n.Key != id15 && n.Key != id16 && n.Key != id17 && n.Key != id18
                    && n.Key != id19 && n.Key != id20 && n.Key != id21 && n.Key != id22 && n.Key != id23 && n.Key != id24 && n.Key != id25 && n.Key != id26 && n.Key != id27
                    && n.Key != -1)
                {
                    temp = n.Count();
                    if (temp < max27 && temp > max28)
                    {
                        max28 = temp;
                        id28 = n.Key;
                    }

                }
            }
            int[] code = new int[28];
            code[0] = id1;
            code[1] = id2;
            code[2] = id3;
            code[3] = id4;
            code[4] = id5;
            code[5] = id6;
            code[6] = id7;
            code[7] = id8;
            code[8] = id9;
            code[9] = id10;
            code[10] = id11;
            code[11] = id12;
            code[12] = id13;
            code[13] = id14;
            code[14] = id15;
            code[15] = id16;
            code[16] = id17;
            code[17] = id18;
            code[18] = id19;
            code[19] = id20;
            code[20] = id21;
            code[21] = id22;
            code[22] = id23;
            code[23] = id24;
            code[24] = id25;
            code[25] = id26;
            code[26] = id27;
            code[27] = id28;

            return code;
        }

        //Método de Support
        public void cantRepeticionesPorGrupo(List<List<int>> grupos)
        {
            for (int i = 1; i <= grupos.Count(); i++)
            {
                int a = repetecionEnVentas(grupos[i - 1]);
                //Console.WriteLine("Grupos {0}, Repeticiones {1}", i, a);
            }
   
        }


        //Método de asociaciones


        /*private static int Partition(int[] A, int p, int r)
            Usar partition para realizar metodo de soporte!!!!!!
        {
            int x = A[r];
            int temp;

            int i = p;
            for (int j = p; j < r; j++)
            {
                if (A[j] <= x)
                {
                    temp = A[j];
                    A[j] = A[i];
                    A[i] = temp;
                    i++;
                }
            }

            A[r] = A[i];
            A[i] = x;
            return i;
        }*/



        //--------------------------------------------------------------------
        //Método para UnitTest


        public List<List<int>> CombinacionP(int [] arreglo )
        {
            List<List<int>> resultado = new List<List<int>>();
            int[] code = arreglo; 

            for (int i = 0; i < code.Length; i++)
            {
                for (int j = i + 1; j < code.Length; j++)
                {
                    for (int k = j + 1; k < code.Length; k++)
                    {
                        List<int> combinacion = new List<int>();

                        combinacion.Add(code[i]);
                        combinacion.Add(code[j]);
                        combinacion.Add(code[k]);
                        resultado.Add(combinacion);
    
                    }

                }
            }

            

            return resultado;
        }

        
        public bool encontrarCombinacion(List<List<int>> combinaciones ,List<int> combinacionEncontrar)
        {
            bool encontrado = false;
            List<int> combinacioAComparar = new List<int>();
            for (int i=0; i<combinaciones.Count;i++)
            {

                combinacioAComparar = combinaciones[i];

                for (int j=0; j<combinacioAComparar.Count;i++)
                {
                    if (combinacioAComparar[j] == combinacionEncontrar[j])
                    {
                        encontrado = true;
                    }
                }

            }


            return encontrado;
        }
        



    }
}
