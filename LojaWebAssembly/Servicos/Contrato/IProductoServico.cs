using DTO;

namespace LojaWebAssembly.Servicos.Contrato
{
    public interface IProductoServico
    {
        Task<ResponseDTO<List<ProductoDTO>>> Listar(string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Obter(int id);
        Task<ResponseDTO<ProductoDTO>> Criar(ProductoDTO dto);
        Task<ResponseDTO<bool>> Editar(ProductoDTO dto);
        Task<ResponseDTO<bool>> Eliminar(int id);
    }
}
