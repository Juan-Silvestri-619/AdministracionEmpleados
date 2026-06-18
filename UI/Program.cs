using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using BLL;
using DAL;

namespace UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var producto = new ProductoService();
            MenuProducto(producto);
        }

        static void MenuProducto(ProductoService producto)
        {
            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("1. Listar productos");
                Console.WriteLine("2. Buscar producto");
                Console.WriteLine("3. Agregar producto");
                Console.WriteLine("4. Modificar producto");
                Console.WriteLine("5. Ingresar stock");
                Console.WriteLine("6. Retirar stock");
                Console.WriteLine("7. Eliminar producto");
                Console.WriteLine("0. Salir");

                Console.Write("=== Ingrese una opción: ");
                if(!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Entrada inválida en las opciones. Vuelva a intentarlo");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ListarProductos(producto);
                        break;
                    case 2:
                        BuscarProducto(producto);
                        break;
                    case 3:
                        AgregarProducto(producto);
                        break;
                    case 4:
                        ModificarProducto(producto);
                        break;
                    case 5:
                        IngresarStock(producto);
                        break;
                    case 6:
                        RetirarStock(producto);
                        break;
                    case 7:
                        EliminarProducto(producto);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opción inexistente. Vuelva a intentarlo");
                        continue;
                }

                if (opcion == 0)
                    break;
                
            }
        }
        private static int PedirId()
        {
            Console.Write("Ingrese ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                throw new Exception("ID Inválido");
            }

            return id;

        }
        private static int PedirCantidad()
        {
            Console.Write("Ingrese cantidad: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidad))
            {
                throw new Exception("cantidad inválida");
            }

            if (cantidad <= 0)
            {
                throw new Exception("La cantidad debe ser mayor a cero");
            }

            return cantidad;
        }
        static void ListarProductos(ProductoService productoService)
        {
            List<Producto> productos = productoService.ListarProductos();

            foreach(var item in productos)
            {
                Console.WriteLine($"id: {item.Id}, nombre: {item.Nombre} - precio: {item.Precio} " +
                   $"- stock actual: {item.StockActual} - stock mínimo: {item.StockMinimo}");
            }
        }
        static void BuscarProducto(ProductoService productoService)
        {
            int id = PedirId();

            Producto producto = productoService.BuscarId(id);

            if(producto == null)
            {
                Console.WriteLine("Producto inexistente");
                return;
            }

            Console.WriteLine($"Nombre: {producto.Nombre} - Precio: {producto.Precio}");
        }
        static void AgregarProducto(ProductoService productoService)
        {
            Console.WriteLine("============================== Agregar un producto ==============================");
            Console.Write("Nombre producto: ");
            string nombre = Console.ReadLine();

            Console.Write("Precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.Write("Stock mínimo: ");
            int stockMinimo = int.Parse(Console.ReadLine());

            Console.Write("Stock actual: ");
            int stockActual = int.Parse(Console.ReadLine());

            Producto producto = new Producto(nombre, precio, stockActual, stockMinimo);

            productoService.AgregarProducto(producto);
        }
        static void ModificarProducto(ProductoService productoService)
        {
            try
            {
                Console.WriteLine("============================== Modificar producto ==============================");
                int id = PedirId();
                Producto producto = productoService.BuscarId(id);

                if(producto == null)
                {
                    Console.WriteLine("Producto no existe");
                    return;
                }

                Console.Write("Nuevo nombre: ");
                string nombre = Console.ReadLine();

                Console.Write("Nuevo precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());

                Console.Write("Nuevo stock mínimo: ");
                int stockMinimo = int.Parse(Console.ReadLine());

                Console.Write("Nuevo stock actual: ");
                int stockActual = int.Parse(Console.ReadLine());

                Producto productoModificado = new Producto(id, nombre, precio, stockActual, stockMinimo);

                productoService.ModificarProducto(productoModificado);
                Console.WriteLine("Producto modificado correctamente");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        static void IngresarStock(ProductoService productoService)
        {
            Console.WriteLine("============================== Ingresar stock de producto ==============================");
            try
            {
                int id = PedirId();
                int cantidad = PedirCantidad();

                productoService.IngresarStock(id, cantidad);
                Console.WriteLine("Stock ingresado correctamente");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }

        static void RetirarStock(ProductoService productoService)
        {            
            try
            {
                int id = PedirId();
                int cantidad = PedirCantidad();

                productoService.RetirarStock(id, cantidad);
                Console.WriteLine("Stock retirado correctamente");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        static void EliminarProducto(ProductoService productoService)
        {
            try
            {
                Console.WriteLine("============================== Eliminar un producto ==============================");

                int id = PedirId();

                productoService.EliminarProducto(id);
                Console.WriteLine("El producto fue eliminado con éxito");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
         

        }
    }
}
