using DTO;
using LojaWebAssembly.Servicos.Contrato;
using System.Net.Http.Json;

namespace LojaWebAssembly.Servicos.Implementacao
{
    public class CategoriaService : ICategoriaService
    {
        private readonly HttpClient _httpClient;

        public CategoriaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Criar(CategoriaDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Criar", dto);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Editar(CategoriaDTO dto)
        {
            var response = await _httpClient.PutAsJsonAsync("Categoria/Editar", dto);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Eliminar(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        } 

        public async Task<ResponseDTO<List<CategoriaDTO>>> Listar(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Listar/{buscar}");
        }

        public async Task<ResponseDTO<CategoriaDTO>> Obter(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obter/{id}");
        }
    }
}
