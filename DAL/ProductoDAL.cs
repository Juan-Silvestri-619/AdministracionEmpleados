using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL
{
    public class ProductoDAL
    {
        private string _cadenaConexion;
        public ProductoDAL() 
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        }

        //Método que nos permite obtener la lista de productos de la base de datos
        public List<Producto> ListarProductos()
        {
            //Lista que nos permite guardar la información obtenida de SQL SERVER
            List<Producto> lista = new List<Producto>();
            //Abrimos conexión con la BD
            //El bloque using garantiza la conexión se cierre y libere recursos automáticamente
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                //SqlCommand representa la query que deseamos ejecutar
                using (SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Producto";
                    //SqlDataReader nos permite leer el query
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        //Hasta que haya algo para leerlo, si hay algo devuelve true
                        while (reader.Read())
                        {
                            Producto producto = new Producto(
                                    Convert.ToInt32(reader["id"]),
                                    reader["nombre"].ToString(),
                                    Convert.ToDecimal(reader["precio"]),
                                    Convert.ToInt32(reader["stockActual"]),
                                    Convert.ToInt32(reader["stockMinimo"])
                                );
                            //Agregamos el producto en la lista para luego recorrerla 
                            lista.Add(producto);
                        }
                    }
                }

            }
            return lista;
        }
        public Producto BuscarId(int id)
        {
            using(SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                using(SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, nombre, precio, stockActual, stockMinimo" +
                        " FROM Producto" +
                        " WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Producto producto = new Producto(
                                    Convert.ToInt32(reader["id"]),
                                    reader["nombre"].ToString(),
                                    Convert.ToDecimal(reader["precio"]),
                                    Convert.ToInt32(reader["stockActual"]),
                                    Convert.ToInt32(reader["stockMinimo"])
                                );
                            return producto;
                        }
                        return null;
                    }
                }
            }
        }
        public void AgregarProducto(Producto producto)
        {
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                using(SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Producto (nombre, precio, stockActual, stockMinimo)" +
                        "VALUES (@nombre, @precio, @stockActual, @stockMinimo)";

                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stockActual", producto.StockActual);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);

                    cmd.ExecuteNonQuery();
                }
            }
           
        }
        public void ModificarProducto(Producto producto)
        {
            using(SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();

                using(SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Producto " +
                        "SET nombre = @nombre, precio = @precio, stockActual = @stockActual, stockMinimo = @stockMinimo " +
                        "WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id",  producto.Id);
                    cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@stockActual", producto.StockActual);
                    cmd.Parameters.AddWithValue("@stockMinimo", producto.StockMinimo);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void EliminarProducto(int id)
        {
            using(SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                conexion.Open();
                using(SqlCommand cmd = conexion.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Producto WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
