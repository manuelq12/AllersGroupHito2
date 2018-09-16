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



        public  List<Articulo> Articulos { get => articulos; set => articulos = value; }
        public  List<Cliente> Clientes { get => clientes; set => clientes = value; }
        public  List<Venta> Ventas { get => ventas; set => ventas = value; }


        public Controlador()
        {

            articulos = new List<Articulo>();
            clientes = new List<Cliente>();
            ventas = new List<Venta>();




            CargarDatos();


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
