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
        private static List<Articulo> articulos;
        private static List<Cliente> clientes;
        private static List<Venta> ventas;

      

        public static List<Articulo> Articulos { get => articulos; set => articulos = value; }
        public static List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public static List<Venta> Ventas { get => ventas; set => ventas = value; }

   
        static void Main(string[] args)
        {
            Console.WriteLine("Holiwi :3 ggg");
            articulos = new List<Articulo>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();

         


            cargarDatos();
            Console.ReadLine();

        }

        public static void cargarDatos()
        {
            cargarArticulos();
            cargarClientes();
            cargarVentas();
        }
        public static void cargarArticulos()
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
        public static void cargarClientes()
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
        public static void cargarVentas()
        {
            String line;
            try
            {
                StreamReader sr = new StreamReader(rutaVentas);
                line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    String[] todo = line.Split(';');
                    if (todo.Length == 7 && !todo.ToList().Any(r => r.Equals("")))
                    {
                        String cardCode = todo[0];
                        String docNum = todo[1];
                        String[] tiempo = todo[2].Split('/');
                        DateTime docDate = new DateTime(Convert.ToInt32(tiempo[2]), Convert.ToInt32(tiempo[0]), Convert.ToInt32(tiempo[1]));
                        String itemCode = todo[3];
                        int cantidad = Convert.ToInt32(todo[4]);
                        int precio = Convert.ToInt32(todo[5]);
                        int totalVenta = Convert.ToInt32(todo[6]);
                        ventas.Add(new Venta(cardCode, docNum, docDate, itemCode, cantidad, precio, totalVenta));
                    }
                }
                sr.Close();
            }
            catch
            {
                throw new Exception("Error al cargar las Ventas");
            }
        }

        // ------------------------------------------------------------------------
        // Para probarlos en UnitTest


        public void cargarVentasP()
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
                        DateTime docDate = new DateTime(Convert.ToInt32(tiempo[2]), Convert.ToInt32(tiempo[0]), Convert.ToInt32(tiempo[1]));
                        String itemCode = todo[3];
                        int cantidad = Convert.ToInt32(todo[4]);
                        int precio = Convert.ToInt32(todo[5]);
                        int totalVenta = Convert.ToInt32(todo[6]);
                        ventas.Add(new Venta(cardCode, docNum, docDate, itemCode, cantidad, precio, totalVenta));
                    }
                }
                sr.Close();
            }
            catch
            {
                throw new Exception("Error al cargar las Ventas");
            }
        }


        public void cargarClientesP()
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

        public void cargarArticulosP()
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


    

    }
}
