using DTO;

namespace LojaWebAssembly.Servicos.Contrato
{
    public interface ICategoriaService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> Listar(string buscar);
        Task<ResponseDTO<CategoriaDTO>> Obter(int id);
        Task<ResponseDTO<CategoriaDTO>> Criar(CategoriaDTO dto);
        Task<ResponseDTO<bool>> Editar(CategoriaDTO dto);
        Task<ResponseDTO<bool>> Eliminar(int id);       
    }
}
