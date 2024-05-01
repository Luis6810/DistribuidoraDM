//using DistribuidoraDM.Models;
using DistribuidoraDM.Models;
using System.Data.SqlClient;

namespace DistribuidoraDM.Data
{
    public class DataProductoProveedorDetalle
    {
        private static string connectionString = Program.connectionString;

        public static Respuesta ObtenerProductoProveedor(int id)
        {
            Respuesta respuesta = new Respuesta();
            ProductoProveedorDTO productoProveedor = new ProductoProveedorDTO();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductoProveedorDetalle";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader myReader = command.ExecuteReader();

                    if (myReader.Read())
                    {
                        productoProveedor = new ProductoProveedorDTO()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            ClaveProveedor = myReader["ClaveProveedor"].ToString(),
                            NombreProducto = myReader["NombreProducto"].ToString(),
                            ClaveProducto = myReader["ClaveProducto"].ToString(),
                            EsActivoProducto = Convert.ToBoolean(myReader["EsActivo"]),
                            NombreTipoProducto = myReader["NombreTipoProducto"].ToString(),
                            NombreProveedor = myReader["NombreProveedor"].ToString(),
                            PrecioProveedor = Convert.ToDecimal(myReader["PrecioProveedor"])

                        };

                        respuesta.Ok = true;
                        respuesta.resultado = productoProveedor;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Operación completada con éxito";
                    }
                    else
                    {
                        respuesta.Ok = true;
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


        public static Respuesta ObtenerTodosProductosProveedor()
        {
            Respuesta respuesta = new Respuesta();

            List<ProductoProveedorDTO> productosProvedor = new List<ProductoProveedorDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerTodosProductosProveedor";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        productosProvedor.Add(new ProductoProveedorDTO()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            ClaveProveedor = myReader["ClaveProveedor"].ToString(),
                            NombreProducto = myReader["NombreProducto"].ToString(),
                            ClaveProducto = myReader["ClaveProducto"].ToString(),
                            EsActivoProducto = Convert.ToBoolean(myReader["EsActivo"]),
                            NombreTipoProducto = myReader["NombreTipoProducto"].ToString(),
                            NombreProveedor = myReader["NombreProveedor"].ToString(),
                            PrecioProveedor = Convert.ToDecimal(myReader["PrecioProveedor"])


                        }); ;
                    }
                    respuesta.Ok = true;
                    respuesta.resultado = productosProvedor;
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

        public static Respuesta ObtenerProductoProveedorPorNombre(string nombre)
        {
            Respuesta respuesta = new Respuesta();
            List<ProductoProveedorDTO> productosProveedor = new List<ProductoProveedorDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductosProveedorPorNombre";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        productosProveedor.Add(new ProductoProveedorDTO()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            ClaveProveedor = myReader["ClaveProveedor"].ToString(),
                            NombreProducto = myReader["NombreProducto"].ToString(),
                            ClaveProducto = myReader["ClaveProducto"].ToString(),
                            EsActivoProducto = Convert.ToBoolean(myReader["EsActivo"]),
                            NombreTipoProducto = myReader["NombreTipoProducto"].ToString(),
                            NombreProveedor = myReader["NombreProveedor"].ToString(),
                            PrecioProveedor = Convert.ToDecimal(myReader["PrecioProveedor"])


                        });
                    }

                    respuesta.Ok = true;
                    respuesta.resultado = productosProveedor;
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

        public static Respuesta ObtenerProductoProveedorPorClave(string clave)
        {
            Respuesta respuesta = new Respuesta();
            List<ProductoProveedorDTO> productosProveedor = new List<ProductoProveedorDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductosProveedorPorClave";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Clave", clave);
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        productosProveedor.Add(new ProductoProveedorDTO()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            ClaveProveedor = myReader["ClaveProveedor"].ToString(),
                            NombreProducto = myReader["NombreProducto"].ToString(),
                            ClaveProducto = myReader["ClaveProducto"].ToString(),
                            EsActivoProducto = Convert.ToBoolean(myReader["EsActivo"]),
                            NombreTipoProducto = myReader["NombreTipoProducto"].ToString(),
                            NombreProveedor = myReader["NombreProveedor"].ToString(),
                            PrecioProveedor = Convert.ToDecimal(myReader["PrecioProveedor"])


                        });
                    }

                    respuesta.Ok = true;
                    respuesta.resultado = productosProveedor;
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

        public static Respuesta ObtenerProductoProveedorBusqueda(string clave, int idTipoProducto)
        {
            Respuesta respuesta = new Respuesta();
            List<ProductoProveedorDTO> productosProveedor = new List<ProductoProveedorDTO>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProductosProveedorBusqueda";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Clave", clave);
                    command.Parameters.AddWithValue("@IdTipoProducto", idTipoProducto);
                    SqlDataReader myReader = command.ExecuteReader();


                    while (myReader.Read())
                    {
                        productosProveedor.Add(new ProductoProveedorDTO()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            ClaveProveedor = myReader["ClaveProveedor"].ToString(),
                            NombreProducto = myReader["NombreProducto"].ToString(),
                            ClaveProducto = myReader["ClaveProducto"].ToString(),
                            EsActivoProducto = Convert.ToBoolean(myReader["EsActivo"]),
                            NombreTipoProducto = myReader["NombreTipoProducto"].ToString(),
                            NombreProveedor = myReader["NombreProveedor"].ToString(),
                            PrecioProveedor = Convert.ToDecimal(myReader["PrecioProveedor"])

                        });

                        
                    }
                    if (productosProveedor.Count() > 0) {
                        respuesta.Ok = true;
                        respuesta.resultado = productosProveedor;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Operación completada con éxito";
                    }
                    else
                    {
                        respuesta.Ok = true;
                        respuesta.resultado = productosProveedor;
                        respuesta.excepcion = null;
                        respuesta.Mensaje = "Sin resultados";
                    }

                    

                    //SqlDataAdapter datos = new(query, conn);
                }
                catch (SqlException ex)
                {
                    respuesta.Ok = false;
                    respuesta.resultado = null;
                    respuesta.excepcion = ex;
                    respuesta.Mensaje = ex.Message;
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
