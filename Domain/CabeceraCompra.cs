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

        public List<DetalleCompra> Detalles { get; private set;}
        #endregion

        #region Constructor
        public CabeceraCompra(DateTime fecha, Proveedor proveedor)
        {
            if (proveedor == null)
                throw new Exception("Debe especificar un proveedor");

            Fecha = fecha;
            Proveedor = proveedor;
            Detalles = new List<DetalleCompra>();
        }
        #endregion
    }
}
