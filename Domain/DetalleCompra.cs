using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DetalleCompra
    {
        #region Propiedades
        public int Id { get; private set; }
        public CabeceraCompra CabeceraCompra { get; private set; }
        public Producto Producto { get; private set; }
        public int Cantidad { get; private set; }
        public decimal PrecioUnitario { get; private set; }
        public decimal Subtotal
        {
            get { return PrecioUnitario * Cantidad; }
        }
        #endregion

        #region Constructor
        public DetalleCompra(CabeceraCompra cabecera, Producto producto, int cantidad, decimal precioUnitario)
        {
            if (cabecera == null || producto == null)
                throw new Exception("Debe especificar compra o producto");
            if (cantidad <= 0)
                throw new Exception("Cantidad debe ser mayor a cero");
            if (precioUnitario <= 0)
                throw new Exception("El precio debe ser mayor a cero");

            CabeceraCompra = cabecera;
            Producto = producto;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
        }
        #endregion
    }
}
