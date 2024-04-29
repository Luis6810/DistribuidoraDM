using DistribuidoraDM.Models;
using System.Data.SqlClient;

namespace DistribuidoraDM.Data
{
    public class DataTipoProductos
    {
        private static string connectionString = Connection.connectionString;

        public static Respuesta ObtenerTodosTiposProductos()
        {
            Respuesta respuesta = new Respuesta();

            List<TipoProducto> tiposProductos = new List<TipoProducto>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerTiposProductos";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        tiposProductos.Add(new TipoProducto()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Nombre = myReader["Nombre"].ToString(),
                            Descripcion = myReader["Descripcion"].ToString(),


                        }); ;
                    }
                    respuesta.Ok = true;
                    respuesta.resultado = tiposProductos;
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
