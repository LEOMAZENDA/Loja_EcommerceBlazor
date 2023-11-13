namespace DTO;

public class CarrinhoDTO
{
    public ProductoDTO Producto { get; set; }
    public int? Cantidad { get; set; }
    public decimal? Precio { get; set; }
    public decimal? Total { get; set; }
}
