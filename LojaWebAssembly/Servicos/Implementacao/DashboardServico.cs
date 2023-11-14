using DTO;
using LojaWebAssembly.Servicos.Contrato;
using System.Net.Http.Json;

namespace LojaWebAssembly.Servicos.Implementacao
{
    public class DashboardServico : IDashboardServico
    {
        private readonly HttpClient _httpClient;

        public DashboardServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ResponseDTO<DashBoardDTO>> Resume()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashBoardDTO>>($"Dashboard/Resume");
        }


    }
}
