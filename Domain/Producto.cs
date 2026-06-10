using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Producto
    {
        #region Propiedades
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public decimal Precio { get; private set; }
        #endregion

        #region Constructor
        public Producto(string nombre, decimal precio)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio");
            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a cero");

            Nombre = nombre;
            Precio = precio;
        }
        #endregion
    }
}
