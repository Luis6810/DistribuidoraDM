namespace DistribuidoraDM.Models
{
    public class ProductoProveedorDTO
    {
        public int Id { get; set; }
        public string? ClaveProveedor { get; set; }

        public string? NombreProducto { get; set; }
        public string? ClaveProducto { get; set; }
        public bool EsActivoProducto { get; set; }
        public string? NombreTipoProducto { get; set; }
        public string? NombreProveedor { get; set; }
    }


}
