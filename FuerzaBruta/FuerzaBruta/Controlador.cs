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
        private  List<Articulo> articulos;
        private  List<Cliente> clientes;
        private  List<Venta> ventas;

        List<List<Articulo>> combinaciones;
        bool[] used;


        public  List<Articulo> Articulos { get => articulos; set => articulos = value; }
        public  List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public  List<Venta> Ventas { get => ventas; set => ventas = value; }


        public Controlador()
        {

            articulos = new List<Articulo>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();

            combinaciones = new List<List<Articulo>>();


            CargarDatos();


        }

        public void CargarDatos()
        {
            CargarArticulos();
            CargarClientes();
            CargarVentas();

            {
                Console.WriteLine(articulos.Count());

                //for (int i = 0; i < articulos.Count() -4; i++)
                //{
                //int cero = i;
                //int uno = i+1;
                //int dos = i+2;
                //int tres = i+3;
                //int cuatro = i+4;
                //Articulo[] arr = { articulos[cero], articulos[uno], articulos[dos], articulos[tres], articulos[cuatro]};
                Articulo[] arr = articulos.ToArray();
                used = new bool[arr.Length];
                    used.ToList().ForEach(r => r = false);
                    List<Articulo> c = new List<Articulo>();
                    GetComb(arr, 0, c);
                //}
                Console.WriteLine(combinaciones.Count());
            }
        }
        public void GetComb(Articulo[] arr, int colindex, List<Articulo> c)
        {

            if (colindex >= arr.Length)
            {
                combinaciones.Add(new List<Articulo>(c));
                return;

            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    c.Add(arr[i]);
                    GetComb(arr, colindex + 1, c);
                    c.RemoveAt(c.Count - 1);
                    used[i] = false;
                }
            }
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
                Console.WriteLine(e.Message);
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
                        int ano= Convert.ToInt32(tiempo[2]);
                        int mes=Convert.ToInt32(tiempo[1]);
                        int dia= Convert.ToInt32(tiempo[0]);
                        DateTime docDate = new DateTime(ano,mes,dia);

                        String itemCode = todo[3];
                        int cantidad = Convert.ToInt32(todo[4]);
                        int precio = Convert.ToInt32(todo[5]);
                        int totalVenta = Convert.ToInt32(todo[6]);
                        ventas.Add(new Venta(cardCode, docNum, docDate, itemCode, cantidad, precio, totalVenta));
                    }
                }
                sr.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new Exception("Error al cargar las Ventas");
            }
        }

    }
}
