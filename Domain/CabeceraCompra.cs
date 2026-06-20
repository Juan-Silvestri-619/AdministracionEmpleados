using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CabeceraCompra
    {
        #region Propiedades
        public int Id { get; private set; }
        public DateTime Fecha { get; private set; }
        public Proveedor Proveedor { get; private set; }
        public decimal Total { get { return Detalles.Sum(d => d.Subtotal); } }

        public List<DetalleCompra> Detalles { get; private set;}
        #endregion

        #region Constructor
        public CabeceraCompra(DateTime fecha, Proveedor proveedor)
        {
            Validar(proveedor);

            Fecha = fecha;
            Proveedor = proveedor;
            Detalles = new List<DetalleCompra>();
        }
        public CabeceraCompra(int id, DateTime fecha, Proveedor proveedor)
        {
            Validar(proveedor);

            Id = id;
            Fecha = fecha;
            Proveedor = proveedor;
            Detalles = new List<DetalleCompra>();
        }
        #endregion
        #region Métodos
        private void Validar(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new Exception("Debe especificar un proveedor");
        }
        public void AgregarDetalle(DetalleCompra detalle)
        {
            if (detalle == null)
                throw new Exception("Detalle inválido");

            Detalles.Add(detalle);
        }

        #endregion
    }
}
