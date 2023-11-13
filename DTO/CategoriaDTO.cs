using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO;

public partial class CategoriaDTO
{
    public int IdCategoria { get; set; }
    [Required(ErrorMessage = "Digite o seu nome da categoria")]
    public string? Nombre { get; set; }

}
