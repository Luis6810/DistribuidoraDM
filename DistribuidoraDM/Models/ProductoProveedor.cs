namespace DistribuidoraDM.Models
{
    public class ProductoProveedor
    {
        public int Id { get; set; }
        public int IdProducto { get; set; }
	    public string ?Clave { get; set; }
	    public int IdProveedor { get; set; }
        public decimal Precio { get; set; }
    }
}
