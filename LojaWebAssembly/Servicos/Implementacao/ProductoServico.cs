using DTO;
using LojaWebAssembly.Servicos.Contrato;
using System.Collections.Concurrent;
using System.Net.Http.Json;

namespace LojaWebAssembly.Servicos.Implementacao
{
    public class ProductoServico : IProductoServico
    {
        private readonly HttpClient _httpClient;

        public ProductoServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ResponseDTO<List<ProductoDTO>>> Catalogo(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Criar(ProductoDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Criar", dto);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(ProductoDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Producto/Editar", dto);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Listar(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Listar/{buscar}");
        }

        public async Task<ResponseDTO<ProductoDTO>> Obter(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Obter/{id}");
        }
    }
}
