using DTO;

namespace Servico.Contrato;

public interface IProductoServico
{
    Task<List<ProductoDTO>> Listar(string buscar);
    Task<List<ProductoDTO>> Catalogo(string categoria, string buscar);
    Task<ProductoDTO> Obter(int id);
    Task<ProductoDTO> Criar(ProductoDTO dto);
    Task<bool> Editar(ProductoDTO dto);
    Task<bool> Eliminar(int id);
}
