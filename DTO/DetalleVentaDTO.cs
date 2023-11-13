namespace DTO;

public partial class DetalleVentaDTO
{
    public int IdDetalleVenta { get; set; }
    public int? IdProducto { get; set; }
    public int? Cantidad { get; set; }
    public decimal? Total { get; set; }
}
