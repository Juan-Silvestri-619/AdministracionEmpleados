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

        #endregion

        #region Constructor
        public Proveedor(int id, string nombre, string correo, string telefono)
        {
            Validar(nombre, correo, telefono);

            Id = id;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
        }
        public Proveedor(string nombre, string correo, string telefono)
        {
            Validar(nombre, correo, telefono);

            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
        }

        private static void Validar(string nombre, string correo, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio");

            if (!correo.Contains("@"))
                throw new Exception("Correo inválido");

            if (string.IsNullOrWhiteSpace(telefono))
                throw new Exception("El teléfono es obligatorio");
        }
        #endregion

    }
}
