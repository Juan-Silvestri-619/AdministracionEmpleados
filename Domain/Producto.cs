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
        public int StockActual { get; private set; }
        public int StockMinimo { get; private set; }
        #endregion

        #region Constructor
        public Producto(string nombre, decimal precio, int stockMinimo)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre es obligatorio");
            if (precio <= 0)
                throw new Exception("El precio debe ser mayor a cero");
            if (stockMinimo < 0)
                throw new Exception("Stock mínimo inválido");

            Nombre = nombre;
            Precio = precio;
            StockMinimo = stockMinimo;
        }

        #endregion

        #region Métodos
        public void IngresarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            StockActual += cantidad;
        }

        public void RetirarStock(int cantidad)
        {
            if (cantidad <= 0)
                throw new Exception("Cantidad inválida");

            if (cantidad > StockActual)
                throw new Exception("Stock insuficiente");

            StockActual -= cantidad;
        }
        public void ModificarMinimo(int nuevoMinimo)
        {
            if (nuevoMinimo <= 0)
                throw new Exception("Stock minimo inválido");

            StockMinimo = nuevoMinimo;
        }
        public bool DebeReponer()
        {
            return StockActual <= StockMinimo;
        }
        public void ModificarPrecio(decimal nuevoPrecio)
        {
            if (nuevoPrecio <= 0)
                throw new Exception("Nuevo precio inválido");
            
            Precio = nuevoPrecio;
        }
        #endregion
    }
}
