namespace FrontEnd 
{
	public class Producto
	{
		public int Id { get; set; }
		public String? Clave { get; set; }
		public String? Nombre { get; set; }
		public int IdTipoProducto { get; set; }
		public decimal Precio { get; set; }
		public bool EsActivo { get; set; }

	}

}