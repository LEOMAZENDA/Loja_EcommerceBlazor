using DTO;

namespace LojaWebAssembly.Servicos.Contrato
{
    public interface IUsuarioServico
    {
        Task<ResponseDTO<List<UsuarioDTO>>> Listar(string rol,string buscar);
        Task<ResponseDTO<UsuarioDTO>> Obter(int id);
        Task<ResponseDTO<SessaoIniciadaDTO>> Autorizacao(LoginDTO dto);
        Task<ResponseDTO<UsuarioDTO>> Criar(UsuarioDTO dto);
        Task<ResponseDTO<bool>> Editar(UsuarioDTO dto);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
