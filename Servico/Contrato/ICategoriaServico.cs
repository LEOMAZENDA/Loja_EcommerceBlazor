using DTO;

namespace Servico.Contrato;

public interface ICategoriaServico
{
    Task<List<CategoriaDTO>> Listar(string buscar);
    Task<CategoriaDTO> Obter(int id);
    Task<CategoriaDTO> Criar(CategoriaDTO dto);
    Task<bool> Editar(CategoriaDTO dto);
    Task<bool> Eliminar(int id);
}
