using DistribuidoraDM.Models;
using System.Data.SqlClient;
namespace DistribuidoraDM.Data
{
    public class DataProductoProveedor
    {
        private static string connectionString = Connection.connectionString;
        public static Respuesta ObtenerProductoProveedor(int id)
        {
            Respuesta respuesta = new Respuesta();
            ProductoProveedor productoProveedor = new ProductoProveedor();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductoProveedor";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader myReader = command.ExecuteReader();

                    if (myReader.Read())
                    {
                        productoProveedor = new ProductoProveedor()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            IdProducto = Convert.ToInt32(myReader["IdProducto"]),
                            Clave = myReader["Clave"].ToString(),
                            IdProveedor = Convert.ToInt32(myReader["IdProveedor"]),
                            Precio = Convert.ToDecimal(myReader["Precio"]),

                        };

                        respuesta.Ok = true;
                        respuesta.resultado = productoProveedor;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Operación completada con éxito";
                    }
                    else
                    {
                        respuesta.Ok = false;
                        respuesta.resultado = null;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Ninguna coincidencia en la base de datos";
                    }



                    //SqlDataAdapter datos = new(query, conn);
                }
                catch (Exception ex)
                {
                    respuesta.Ok = false;
                    respuesta.resultado = null;
                    respuesta.excepcion = ex;
                    respuesta.Mensaje = "Ocurrió un error en la base de datos";
                }
            }


            return respuesta;

        }

        public static Respuesta ActualizarProductoProveedor(ProductoProveedor producto)
        {
            Respuesta respuesta = new Respuesta();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spActualizarProductoProveedor";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", producto.Id);
                    command.Parameters.AddWithValue("@IdProveedor", producto.IdProveedor);
                    command.Parameters.AddWithValue("@Clave", producto.Clave);
                    command.Parameters.AddWithValue("@Precio", producto.Precio);

                   if(command.ExecuteNonQuery() > 0){
                        respuesta.Ok = true;
                        respuesta.resultado = null;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Operación completada con éxito";
                    }
                    
                    else
                    {
                        respuesta.Ok = false;
                        respuesta.resultado = null;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "No se pudo actualizar la base de datos";
                    }



                    //SqlDataAdapter datos = new(query, conn);
                }
                catch (Exception ex)
                {
                    respuesta.Ok = false;
                    respuesta.resultado = null;
                    respuesta.excepcion = ex;
                    respuesta.Mensaje = "Ocurrió un error en la base de datos";
                }
            }


            return respuesta;

        }
    }
}
