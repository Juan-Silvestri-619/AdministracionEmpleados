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
            //var producto = new ProductoService();
            //MenuProducto(producto);
            var proveedor = new ProveedorService();
            MenuProveedor(proveedor);
             
        }

        #region Producto
        //Falta crear un método para poder crear productos y que me sirva para modificarlos
        //Validaciones en tryCatch o tryparse, etc
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
                if (!int.TryParse(Console.ReadLine(), out int opcion))
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
        #region Métodos auxiliares
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
        #endregion

        #region Métodos CRUD  producto

        static void ListarProductos(ProductoService productoService)
        {
            List<Producto> productos = productoService.ListarProductos();

            foreach (var item in productos)
            {
                Console.WriteLine($"id: {item.Id}, nombre: {item.Nombre} - precio: {item.Precio} " +
                   $"- stock actual: {item.StockActual} - stock mínimo: {item.StockMinimo}");
            }
        }
        static void BuscarProducto(ProductoService productoService)
        {
            int id = PedirId();

            Producto producto = productoService.BuscarId(id);

            if (producto == null)
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

                if (producto == null)
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
        #endregion

        #endregion

        #region Proveedor
        static void MenuProveedor(ProveedorService proveedorService)
        {
            while (true)
            {
                Console.WriteLine("====================================");
                Console.WriteLine("1. Listar proveedor");
                Console.WriteLine("2. Buscar proveedor");
                Console.WriteLine("3. Agregar proveedor");
                Console.WriteLine("4. Modificar proveedor");
                Console.WriteLine("5. Eliminar proveedor");
                Console.WriteLine("6. Salir");

                Console.Write("=== Ingrese una opción: ");
                if (!int.TryParse(Console.ReadLine(), out int opcion))
                {
                    Console.WriteLine("Entrada inválida en las opciones. Vuelva a intentarlo");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ListarProveedores(proveedorService);
                        break;
                    case 2:
                        BuscarPorId(proveedorService);
                        break;
                    case 3:
                        AgregarProveedor(proveedorService);
                        break;
                    case 4:
                        ModificarProveedor(proveedorService);
                        break;
                    case 5:
                        EliminarProveedor(proveedorService);
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Opción inexistente. Vuelva a intentarlo");
                        continue;
                }

                if (opcion == 6)
                    break;

            }
        }

        #region Métodos auxiliares
        private static string DevolverProveedorNombre()
        {
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine();

            if(string.IsNullOrWhiteSpace(nombre) || !nombre.All(c => char.IsLetter(c) || c == ' '))
            {
                throw new Exception("Nombre inválido");
            }

            return nombre;
        }
        private static string DevolverProveedorCorreo()
        {
            Console.Write("Ingrese correo: ");
            string correo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
            {
                throw new Exception("correo inválido");
            }

            return correo;
        }
        private static string DevolverProveedorTelefono()
        {
            Console.Write("Ingrese telefono: ");
            string telefono = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(telefono) || !telefono.All(char.IsDigit))
            {
                throw new Exception("Telefono inválido");
            }

            return telefono;
        }
        #endregion

        #region CRUD
        static void ListarProveedores(ProveedorService proveedorService)
        {
            Console.WriteLine("Proveedores");

            foreach (var item in proveedorService.ListarProveedores())
            {
                Console.WriteLine($"ID: {item.Id} - Nombre: {item.Nombre} - Correo: {item.Correo} " +
                    $"- Tel: {item.Telefono}");
            }
        }
        static void BuscarPorId(ProveedorService service)
        {
            try
            {
                int id = PedirId();

                Proveedor proveedor = service.BuscarId(id);
                if (proveedor == null)
                {
                    Console.WriteLine("No existe el proveedor en el sistema");
                    return;
                }

                Console.WriteLine($"ID: {proveedor.Id} - Nombre: {proveedor.Nombre} - Correo: {proveedor.Correo}" +
                    $" - Telefono: {proveedor.Telefono}");

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
        static void AgregarProveedor(ProveedorService service)
        {
            try
            {
                string nombre = DevolverProveedorNombre();
                string correo = DevolverProveedorCorreo();
                string telefono = DevolverProveedorTelefono();

                Proveedor proveedor = new Proveedor(nombre, correo, telefono);

                service.AgregarProveedor(proveedor);
                Console.WriteLine("El proveedor fue agregado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }
        static void ModificarProveedor(ProveedorService service)
        {
            try
            {
                Console.WriteLine("============================== Modificar proveedor ==============================");
                int id = PedirId();
                Proveedor proveedor = service.BuscarId(id);

                if(proveedor == null)
                {
                    throw new Exception("El proveedor no existe en la base de datos.");
                }

                string nombre = DevolverProveedorNombre();
                string correo = DevolverProveedorCorreo();
                string telefono = DevolverProveedorTelefono();

                proveedor = new Proveedor(id,nombre, correo, telefono);

                service.ActualizarProveedor(proveedor);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }
        static void EliminarProveedor(ProveedorService service)
        {
            try
            {
                Console.WriteLine("============================== Eliminar un producto ==============================");
                int id = PedirId();

                service.EliminarProveedor(id);
                Console.WriteLine("Proveedor fue eliminado correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
        #endregion
    }
}
