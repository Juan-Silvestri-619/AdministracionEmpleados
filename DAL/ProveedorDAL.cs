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
    public class ProveedorDAL
    {
        private string _cadenaConexion;

        public ProveedorDAL()
        {
            _cadenaConexion = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        }

        public Proveedor BuscarId(int id)
        {
            using(SqlConnection conn = new SqlConnection(_cadenaConexion))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, nombre, correo, telefono FROM Proveedor " +
                        "WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor(
                                    Convert.ToInt32(reader["id"]),
                                    reader["nombre"].ToString(),
                                    reader["correo"].ToString(),
                                    reader["telefono"].ToString()

                            );
                            return proveedor;
                        }
                        return null;
                    }
                }
            }
        }
        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using(SqlConnection connection = new SqlConnection(_cadenaConexion))
            {
                connection.Open();

                using(SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Proveedor";

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Proveedor proveedor = new Proveedor(
                                    Convert.ToInt32(reader["id"]),
                                    reader["nombre"].ToString(),
                                    reader["correo"].ToString(),
                                    reader["telefono"].ToString()
                                );

                            proveedores.Add(proveedor);
                        }
                    }
                }
            }
            return proveedores;
        }
        public void AgregarProveedor(Proveedor proveedor)
        {
            using(SqlConnection connection = new SqlConnection(_cadenaConexion))
            {
                connection.Open();
                using(SqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Proveedor (nombre, correo, telefono) " +
                        "VALUES (@nombre, @correo, @telefono)";

                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void ActualizarProveedor(Proveedor proveedor)
        {
            using(SqlConnection conn = new SqlConnection(_cadenaConexion))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "UPDATE Proveedor " +
                        "SET nombre = @nombre, correo = @correo, telefono = @telefono " +
                        "WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", proveedor.Id);
                    cmd.Parameters.AddWithValue("@nombre", proveedor.Nombre);
                    cmd.Parameters.AddWithValue("@correo", proveedor.Correo);
                    cmd.Parameters.AddWithValue("@telefono", proveedor.Telefono);

                    cmd.ExecuteNonQuery();

                }
            }
        }
        public void EliminarProveedor(int id)
        {
            using(SqlConnection conn = new SqlConnection(_cadenaConexion))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Proveedor WHERE id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
