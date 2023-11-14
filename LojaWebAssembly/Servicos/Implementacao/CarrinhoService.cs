using Blazored.LocalStorage;
using Blazored.Toast.Services;
using DTO;
using LojaWebAssembly.Servicos.Contrato;

namespace LojaWebAssembly.Servicos.Implementacao;

public class CarrinhoService : ICarrinhoService
{
    private ILocalStorageService _localStorageService;
    private ISyncLocalStorageService _syncLocalStorageService;
    private IToastService _toastService;

    public CarrinhoService(ILocalStorageService ILocalStorageService,
    ISyncLocalStorageService ISyncLocalStorageService,
    IToastService IToastService)
    {
        _localStorageService = ILocalStorageService;
        _syncLocalStorageService = ISyncLocalStorageService;
        _toastService = IToastService;
    }

    public event Action MostrarItens;

    public async Task AdicionarAoCarrinho(CarrinhoDTO dto)
    {
        try
        {
            var carrinho = await _localStorageService.GetItemAsync<List<CarrinhoDTO>>("carrinho");
            if (carrinho == null)
                carrinho= new List<CarrinhoDTO>();

            var productoEncontrado = carrinho.FirstOrDefault(c => c.Producto.IdProducto == dto.Producto.IdProducto);

            if (productoEncontrado == null)
                carrinho.Remove(productoEncontrado);

            carrinho.Add(dto);
            await _localStorageService.SetItemAsync("carrinho", carrinho);

            if (productoEncontrado != null)
                _toastService.ShowSuccess("Producto actualizado no carrinho");
            else
                _toastService.ShowSuccess("Producto adcionado no carrinho");

            MostrarItens.Invoke();//Atulaiza o numero no carrinho
        }
        catch (Exception)
        {
            _toastService.ShowSuccess("Não foi possivel adcionado o producto ao carrinho");
        }
    }

    public int CantidadProduct()
    {
        var carrinho = _syncLocalStorageService.GetItem<List<CarrinhoDTO>>("carrinho");
        return carrinho == null ? 0 : carrinho.Count();
    }

    public async Task EliminarCarrinho(int idProducto)
    {
        try
        {
            var carrinho = await _localStorageService.GetItemAsync<List<CarrinhoDTO>>("carrinho");
            if (carrinho != null)
            {
                var elemento = carrinho.FirstOrDefault(x=> x.Producto.IdProducto == idProducto);
                if (elemento != null)
                {
                    carrinho.Remove(elemento);
                    await _localStorageService.SetItemAsync("carrinho", carrinho);
                    MostrarItens.Invoke();//Atulaiza o numero no carrinho
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task LimparCarrinho()
    {
        await _localStorageService.RemoveItemAsync("carrinho");
        MostrarItens.Invoke();//Atulaiza o numero no carrinho
    }

    public async Task<List<CarrinhoDTO>> ListarCarrinho(int idProducto)
    {
        var carrinho = await _localStorageService.GetItemAsync<List<CarrinhoDTO>>("carrinho");
        if (carrinho == null)
            carrinho = new List<CarrinhoDTO>();

        return carrinho;
    }
}
