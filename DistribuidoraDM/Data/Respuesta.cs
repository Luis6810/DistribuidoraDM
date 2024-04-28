namespace DistribuidoraDM.Data
{
    public class Respuesta
    {
        public bool Ok { get; set; }
        public string? Mensaje { get; set; }

        public object ?resultado { get; set; }
        public Exception? excepcion { get; set; }
    }
}
