using DTO;

namespace Servico.Contrato;

public interface IUsuarioServico
{
    Task<List<UsuarioDTO>> Listar(string rol, string buscar);   
    Task<UsuarioDTO> Obter(int id);   
    Task<SessaoIniciadaDTO> Autorizacao(LoginDTO modelo);   
    Task<UsuarioDTO> Criar(UsuarioDTO modelo);   
    Task<bool> Editar(UsuarioDTO modelo);   
    Task<bool> Eliminar(int id);   
}
