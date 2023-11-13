using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO;

public partial class ProductoDTO
{
    public int IdProducto { get; set; }

    [Required(ErrorMessage = "Digite o nome")]
    public string? Nombre { get; set; }
    [Required(ErrorMessage = "Digite a Descripcion")]
    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    [Required(ErrorMessage = "Digite o Precio")]
    public decimal? Precio { get; set; }

    [Required(ErrorMessage = "Digite o Precio da Oferta")]
    public decimal? PrecioOferta { get; set; }
    [Required(ErrorMessage = "Digite a Cantidad")]
    public int? Cantidad { get; set; }
    [Required(ErrorMessage = "Digite a Imagen")]
    public string? Imagen { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public virtual CategoriaDTO? IdCategoriaNavigation { get; set; }
}
