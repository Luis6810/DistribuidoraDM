﻿using System.Data.SqlClient;
using DistribuidoraDM.Models;

namespace DistribuidoraDM.Data
{
    public class DataProduct
    {
        private static string connectionString = Connection.connectionString;

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
    }
}