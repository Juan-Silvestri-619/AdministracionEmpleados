using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DAL;

namespace BLL
{
    public class ProductoService
    {
        private ProductoDAL _productoDal;
        public ProductoService() 
        {
            _productoDal = new ProductoDAL();
        }


        #region CRUD
        public List<Producto> ListarProductos()
        {
            return _productoDal.ListarProductos();
        }
        public Producto BuscarId(int id)
        {
            return _productoDal.BuscarId(id);
        }
        public void AgregarProducto(Producto producto)
        {
            _productoDal.AgregarProducto(producto);
        }
        public void ModificarProducto(Producto producto)
        {
            if (_productoDal.BuscarId(producto.Id) == null)
                throw new Exception("EL producto no existe");

            _productoDal.ModificarProducto(producto);
        }

        public void EliminarProducto(int id)
        {
            if (_productoDal.BuscarId(id) == null)
                throw new Exception("EL producto no existe");
            _productoDal.EliminarProducto(id);
        }
        #endregion
        private Producto ObtenerProductoExistentes(int id)
        {
            Producto producto = _productoDal.BuscarId(id);

            if (producto == null)
                throw new Exception("El producto no existe en la base de datos");

            return producto;
        }
        public void IngresarStock(int idProducto, int cantidad)
        {
            Producto producto = ObtenerProductoExistentes(idProducto);

            producto.IngresarStock(cantidad); //Tene en cuenta que vos tenes el objeto Producto con toda su info
            //Solo modificas la cantidad actual que tiene

            _productoDal.ModificarProducto(producto);
        }
        public void ModificarPrecio(int idProducto, decimal precioNuevo)
        {
            Producto producto = ObtenerProductoExistentes(idProducto);

            producto.ModificarPrecio(precioNuevo);

            _productoDal.ModificarProducto(producto);
        }
        public void ModificarMinimoProducto(int idProducto, int minimo)
        {
            Producto producto = ObtenerProductoExistentes(idProducto);

            producto.ModificarMinimo(minimo);

            _productoDal.ModificarProducto(producto);
        }
        public void RetirarStock(int idProducto, int cantidad)
        {
            Producto producto = ObtenerProductoExistentes(idProducto);

            producto.RetirarStock(cantidad);

            _productoDal.ModificarProducto(producto);
        }
    }
}
