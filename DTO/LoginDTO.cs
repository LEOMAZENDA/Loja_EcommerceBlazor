using System.ComponentModel.DataAnnotations;

namespace DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "Digite o eeu email")]
    public string? Correo { get; set; }


    [Required(ErrorMessage = "Digite a sua senha")]
    public string? Clave { get; set; }
}
