using DTO;

namespace Servico.Contrato;

public interface IUsuarioServico
{
    Task<List<UsuarioDTO>> Listar(string rol, string buscar);   
    Task<UsuarioDTO> Obter(int id);   
    Task<SessaoIniciadaDTO> Autorizacao(LoginDTO dto);   
    Task<UsuarioDTO> Criar(UsuarioDTO dto);   
    Task<bool> Editar(UsuarioDTO dto);   
    Task<bool> Eliminar(int id);   
}
