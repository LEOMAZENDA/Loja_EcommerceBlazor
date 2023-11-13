using System;
using System.Collections.Generic;

namespace Modelo;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
