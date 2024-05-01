using DistribuidoraDM.Models;
using System.Data.SqlClient;
namespace DistribuidoraDM.Data
{
    public class DataProveedor
    {
        private static string connectionString = Program.connectionString;


        public static Respuesta ObtenerTodosProductosProveedor()
        {
            Respuesta respuesta = new Respuesta();

            List<Proveedor> productos = new List<Proveedor>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string storedProcedure = "spObtenerProveedores";
                    SqlCommand command = new(storedProcedure, conn);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader myReader = command.ExecuteReader();

                    while (myReader.Read())
                    {
                        productos.Add(new Proveedor()
                        {
                            Id = Convert.ToInt32(myReader["Id"]),
                            Nombre = myReader["Nombre"].ToString(),
                            Descripcion = myReader["Descripcion"].ToString()


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
