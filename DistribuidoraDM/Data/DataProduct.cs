using System.Data.SqlClient;
using DistribuidoraDM.Models;
using Microsoft.Extensions.Configuration;

namespace DistribuidoraDM.Data
{
    public class DataProduct { 

        private static string connectionString = Program.connectionString;


        public static Respuesta ObtenerTodosProductosProveedor()
        {
            Respuesta respuesta = new Respuesta();

            List<Producto> productos = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductos";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        productos.Add(new Producto()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Clave = myReader["Clave"].ToString(),
                            Nombre = myReader["Nombre"].ToString(),
                            IdTipoProducto = Convert.ToInt32(myReader["IdTipoProducto"]),
                            Precio = Convert.ToDecimal(myReader["Precio"]),
                            EsActivo = Convert.ToBoolean(myReader["EsActivo"]),


                        }); ;
                    }
                    respuesta.Ok = true;
                    respuesta.resultado = productos;
                    respuesta.excepcion = null;
                    respuesta.Mensaje = "Operación completada con éxito";
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

        public static Respuesta ObtenerProductoProveedor(string clave)
        {
            Respuesta respuesta = new Respuesta();

            Producto productos = new Producto();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductoPorClave";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Clave", clave);
                    SqlDataReader myReader = command.ExecuteReader();

                    if (myReader.Read())
                    {
                        productos = new Producto()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Clave = myReader["Clave"].ToString(),
                            Nombre = myReader["Nombre"].ToString(),
                            IdTipoProducto = Convert.ToInt32(myReader["IdTipoProducto"]),
                            Precio = Convert.ToDecimal(myReader["Precio"]),
                            EsActivo = Convert.ToBoolean(myReader["EsActivo"]),


                        };
                        respuesta.Ok = true;
                        respuesta.resultado = productos;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Operación completada con éxito";
                    }
                    else
                    {
                        respuesta.Ok = false;
                        respuesta.resultado = null;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "No hay resultados";
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
