using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TareaProgramada3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                using (var db = new ProductosContext())
                {
                    //Nombre del producto
                    Console.Write("Ingrese el nombre del producto: ");
                    var nombre = Console.ReadLine();

                    //Se guarda el producto
                    Console.WriteLine("Guardando...");
                    var producto = new Productos { Nombre = nombre};
                    db.Productos.Add(producto);
                    db.SaveChanges();

                    //Cantidad de numeros aleatorios
                    Console.Write("Ingrese la cantidad de números aleatorios: ");
                    int cantidad = int.Parse(Console.ReadLine());

                    //Valida si la cantidad de número aleatorios es menor a 100
                    if (cantidad < 100)
                    {
                        Console.Write("Los numeros aleatorios se pueden repetir? "); Console.WriteLine("s/n");
                        var repetir = Console.ReadLine().ToLower();

                        if (repetir == "s")
                        {
                            //Generar los números aleatorios permitiendo repetir
                            var aleatorio = new Random();
                            for (int i = 0; i <= cantidad; i++)
                            {
                                int numero = aleatorio.Next(0, 99);
                                var numeroAleatorio = new Numeros
                                {
                                    Orden = i + 1,
                                    Num = numero,
                                    ProductoId = producto.ProductosId
                                };
                                db.Numeros.Add(numeroAleatorio);
                            }
                            //guarda el orden, cantidad y números aleatorios
                            Console.WriteLine("Guardando...");
                            db.SaveChanges();

                            //Consulta si desea agregar otro producto
                            Console.Write("Desea agregar otro producto: "); Console.WriteLine("s/n");
                            var nuevo = Console.ReadLine().ToLower();
                            if (nuevo == "s")
                            {
                                //Retorna al inicio del programa
                                continuar = true;
                            }
                            else if (nuevo == "n")
                            {
                                var listaProductos = db.Productos.ToList();

                                //Imprime todos los datos del programa
                                Console.WriteLine("Valores generados");
                                foreach (var p in listaProductos)
                                {
                                    Console.WriteLine($"{p.ProductosId} - {p.Nombre} - {p.FechaHora}");

                                    // Mostrar los números relacionados a ese producto
                                    var numeros = db.Numeros
                                                    .Where(n => n.ProductoId == p.ProductosId)
                                                    .OrderBy(n => n.Orden)
                                                    .ToList();

                                    foreach (var n in numeros)
                                    {
                                        Console.WriteLine($"\tID: {n.NumerosId} Orden: {n.Orden} - Número: {n.Num}");
                                    }
                                }

                                //Finaliza el programa
                                Console.WriteLine("Programa Finalizado. Presione cualquier tecla para salir");
                                Console.ReadKey();
                                continuar = false;
                            }
                        }
                        else if (repetir == "n")
                        {
                            //Generar los números aleatorios sin valores repetidos
                            var aleatorio = new Random();
                            var numerosUnicos = new HashSet<int>();//Variable que no permite valores duplicados
                            while (numerosUnicos.Count < cantidad)
                            {
                                numerosUnicos.Add(aleatorio.Next(0, 99));
                            }

                            int orden = 1;
                            foreach (var numero in numerosUnicos)
                            {
                                var numeroAleatorio = new Numeros
                                {
                                    Orden = orden++,
                                    Num = numero,
                                    ProductoId = producto.ProductosId
                                };
                                db.Numeros.Add(numeroAleatorio);
                            }
                            //guarda el orden, cantidad y números aleatorios
                            Console.WriteLine("Guardando...");
                            db.SaveChanges();

                            //Consulta si desea agregar otro producto
                            Console.Write("Desea agregar otro producto: "); Console.WriteLine("s/n");
                            var nuevo = Console.ReadLine().ToLower();
                            if (nuevo == "s")
                            {
                                //Retorna al inicio del programa
                                continuar = true;
                            }
                            else if (nuevo == "n")
                            {
                                var listaProductos = db.Productos.ToList();

                                //Imprime todos los datos del programa
                                Console.WriteLine("Valores generados");
                                foreach (var p in listaProductos)
                                {
                                    Console.WriteLine($"{p.ProductosId} - {p.Nombre} - {p.FechaHora}");

                                    // Mostrar los números relacionados a ese producto
                                    var numeros = db.Numeros
                                                    .Where(n => n.ProductoId == p.ProductosId)
                                                    .OrderBy(n => n.Orden)
                                                    .ToList();

                                    foreach (var n in numeros)
                                    {
                                        Console.WriteLine($"\tID: {n.NumerosId} Orden: {n.Orden} - Número: {n.Num}");
                                    }
                                }

                                //Finaliza el programa
                                Console.WriteLine("Programa Finalizado. Presione cualquier tecla para salir");
                                Console.ReadKey();
                                continuar = false;
                            }
                        }
                    }
                    if (cantidad >= 100)
                    {
                        //Generar los números aleatorios permitiendo repetir
                        var aleatorio = new Random();
                        for (int i = 0; i <= cantidad; i++)
                        {
                            int numero = aleatorio.Next(0, 99);
                            var numeroAleatorio = new Numeros
                            {
                                Orden = i + 1,
                                Num = numero,
                                ProductoId = producto.ProductosId
                            };
                            db.Numeros.Add(numeroAleatorio);
                        }
                        //guarda el orden, cantidad y números aleatorios
                        Console.WriteLine("Guardando...");
                        db.SaveChanges();

                        //Consulta si desea agregar otro producto
                        Console.Write("Desea agregar otro producto: "); Console.WriteLine("s/n");
                        var nuevo = Console.ReadLine().ToLower();
                        if (nuevo == "s")
                        {
                            //Retorna al inicio del programa
                            continuar = true;
                        }
                        else if (nuevo == "n")
                        {
                            var listaProductos = db.Productos.ToList();

                            //Imprime todos los datos del programa
                            Console.WriteLine("Valores generados");
                            foreach(var p in listaProductos)
                            {
                                Console.WriteLine($"{p.ProductosId} - {p.Nombre} - {p.FechaHora}");

                                // Mostrar los números relacionados a ese producto
                                var numeros = db.Numeros
                                                .Where(n => n.ProductoId == p.ProductosId)
                                                .OrderBy(n => n.Orden)
                                                .ToList();

                                foreach (var n in numeros)
                                {
                                    Console.WriteLine($"\tID: {n.NumerosId} Orden: {n.Orden} - Número: {n.Num}");
                                }
                            }

                            //Finaliza el programa
                            Console.WriteLine("Programa Finalizado. Presione cualquier tecla para salir");
                            Console.ReadKey();
                            continuar = false;
                        }
                    }
                    
                }
            }
        }

        ///
        public class ProductosContext : DbContext
        {
            public DbSet<Productos> Productos { get; set; }
            public DbSet<Numeros> Numeros { get; set; }
        }

        public class Productos
        {
            public int ProductosId { get; set; }
            public string Nombre { get; set; }
            public DateTime FechaHora { get; set; } = DateTime.Now;
        }

        public class Numeros
        {
            public int NumerosId { get; set; }
            public int Orden { get; set; }
            public int Num { get; set; }
            public int ProductoId { get; set; }
        }
    }
}