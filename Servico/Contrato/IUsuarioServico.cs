using DTO;

namespace Servico.Contrato;

public interface IUsuarioServico
{
    Task<List<UsuarioDTO>> Listar(string rol, string buscar);   
    Task<UsuarioDTO> Obter(int id);   
    Task<SessaoIniciadaDTO> Autorizacao(LoginDTO modeloDto);   
    Task<UsuarioDTO> Criar(UsuarioDTO modeloDto);   
    Task<bool> Editar(UsuarioDTO modeloDto);   
    Task<bool> Eliminar(int id);   
}
