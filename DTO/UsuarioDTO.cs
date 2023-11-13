using System.ComponentModel.DataAnnotations;

namespace DTO;

public class UsuarioDTO
{
    public int IdUsuario { get; set; }
    [Required(ErrorMessage ="Digite o seu primeiro e ultimo nome")]
    public string? NombreCompleto { get; set; }

    [Required(ErrorMessage = "Digite o eeu email")]
    public string? Correo { get; set; }


    [Required(ErrorMessage = "Digite a sua senha")]
    public string? Clave { get; set; }

    [Required(ErrorMessage = "Digite a confirmação da sua senha")]
    public string? ConfirmarClave { get; set; }

    public string? Rol { get; set; }

}
