using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Proveedor
    {
        #region Propiedades
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public string Correo { get; private set; }
        public string Telefono { get; private set; }

        public List<CabeceraCompra> Compras { get; private set; }
        #endregion

        #region Constructor
        public Proveedor(string nombre, string correo, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio");
            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El teléfono es obligatorio");

            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            Compras = new List<CabeceraCompra>();
        }
        #endregion


    }
}
