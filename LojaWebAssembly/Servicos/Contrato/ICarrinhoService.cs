using DTO;

namespace LojaWebAssembly.Servicos.Contrato;

public interface ICarrinhoService
{
    event Action MostrarItens;
    int CantidadProduct();
    Task AdicionarAoCarrinho(CarrinhoDTO dto);
    Task EliminarCarrinho(int idProducto);
    Task<List<CarrinhoDTO>> ListarCarrinho(int idProducto);
    Task LimparCarrinho();
}
