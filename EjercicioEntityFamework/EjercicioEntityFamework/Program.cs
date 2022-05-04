using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EjercicioEntityFamework
{

    
    public class Program
    {

        

        static void Main(string[] args)
        {
           
            using (BarDbEntities db = new BarDbEntities())
            {
                Producto oProducto = new Producto();
                int Numero = 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("|                                                                        |");
                Console.WriteLine("|                           BIENVENIDOS A MI BAR                         |");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("|                 INGRESA UNA DE LAS SIGUIENTES OPCIONES                 |");
                Console.WriteLine("|                                                                        |"+
                    "\n|                         1) Mostrar producto                            |" +
                    "\n|                         2) Insertar producto                           |" +
                    "\n|                         3) Actualizar producto                         |" +
                    "\n|                         4) Eliminar producto                           |" +
                    "\n|                         5) Cerrar aplicación                           |");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.ResetColor();

                Console.WriteLine("\n¿Qué opción tienes pensado?");
                Numero = Convert.ToInt32(Console.ReadLine());
                



                if (Numero < 1|| Numero > 5)
                {
                    Console.WriteLine("\n La opcion que usted a elegido no se encuentra en el menu");
                    Console.ReadLine();

                }


                Console.Clear();
                BarDbEntities barDbEntities = new BarDbEntities();
                switch (Numero)
                {
                    case 1:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine(" ESTOS SON LOS PRODUCTOS DE NUESTRO BAR :D");
                            Console.ResetColor();
                            var lst = db.Producto;
                            foreach (var producto in lst)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("-------------------------------------------");
                                Console.ResetColor ();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                System.Console.Write("\nID : {0} \nNombre: {1} \nDescripcion: {2} \nPrecio: {3} \nCantidad: {4} \nEstado: {5}\n", producto.Id, producto.Nombre, producto.Descripcion, producto.Precio,producto.Cantidad,producto.Estado);
                                Console.ResetColor();

                            }



                            break;
                        }


                  case 2:
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("              INSERTAR PRODUCTOS");
                            Console.WriteLine("--------------------------------------------------");
                            Console.ResetColor();

                            Producto objProducto = new Producto();
                            Console.WriteLine("\nEscriba el nombre por favor:");
                            objProducto.Nombre = Convert.ToString(Console.ReadLine());


                            Console.WriteLine("\nEscriba la descripcion por favor:");
                            objProducto.Descripcion = Console.ReadLine();


                            Console.WriteLine("\nEscriba el precio por favor:");
                            objProducto.Precio = Convert.ToDouble(Console.ReadLine());


                            Console.WriteLine("\nEscriba la cantidad por favor:");
                            objProducto.Cantidad = Convert.ToInt32(Console.ReadLine());



                            Console.WriteLine("\nIntroduzca el estado por favor:");
                            objProducto.Estado = Convert.ToInt32(Console.ReadLine());


                            db.Producto.Add(objProducto);
                            db.SaveChanges();
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("\nDatos ingresados: ");
                            Console.ResetColor();
                            Console.WriteLine("Nombre:" + objProducto.Nombre +
                                "\nDescrpcion: " + objProducto.Descripcion +
                                "\nPrecio: " + objProducto.Precio + "\nCantidad: "
                                + objProducto.Cantidad + "\nEstado: " + objProducto.Estado);

                            break;
                        }


                    case 3:
                        {

                            Producto objProducto = new Producto();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("AQUI PODRAS HACER ACTUALIZACIÓN A TUS PRODUCTOS");
                            Console.WriteLine("--------------------------------------------------");
                            Console.ResetColor();


                            Console.WriteLine("\nIngrese el ID: ");
                            objProducto.Id = Convert.ToInt32(Console.ReadLine());
                            objProducto = db.Producto.Find(objProducto.Id);

                            Console.WriteLine("\nIngrese el Nombre: ");
                            objProducto.Nombre = Console.ReadLine();

                            Console.WriteLine("\nEscriba la descripcion por favor:");
                            objProducto.Descripcion = Console.ReadLine();


                            Console.WriteLine("\nEscriba el precio por favor:");
                            objProducto.Precio = Convert.ToDouble(Console.ReadLine());


                            Console.WriteLine("\nEscriba la cantidad por favor:");
                            objProducto.Cantidad = Convert.ToInt32(Console.ReadLine());



                            Console.WriteLine("\nIntroduzca el estado del producto:");
                            objProducto.Estado = Convert.ToInt32(Console.ReadLine());

                            db.Entry(objProducto).State = System.Data.Entity.EntityState.Modified;
                            db.SaveChanges();

                            Console.ForegroundColor = ConsoleColor.Green;   
                            Console.WriteLine("¡La actualizacion se hizo correctamente! :D");
                            Console.ReadLine();
                            Console.ResetColor();
                            break;


                        }


                    case 4:
                        {

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("--------------------------------------------------");
                            Console.WriteLine("EN ESTE APARTADO PODRAS ELIMINAR UN PRODUCTO");
                            Console.WriteLine("--------------------------------------------------");
                            Console.ResetColor();

                            Producto objProducto = new Producto();
                            Console.WriteLine("\nIntroduzca el id a eliminar: ");
                            objProducto.Id = Convert.ToInt32(Console.ReadLine());


                            db.Entry(objProducto).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                            break;
                        }


                    case 5:
                        {
                            Environment.Exit(0);


                            break;

                        }
                        


                       

                }



                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nPresiones cualquier tecla para continuar");
                Console.ReadKey();
                Console.ResetColor();
                Console.ReadLine();


            }

        }
    }
}
