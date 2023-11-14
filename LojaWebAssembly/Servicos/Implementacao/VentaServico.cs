using DTO;
using LojaWebAssembly.Servicos.Contrato;
using System.Net.Http.Json;

namespace LojaWebAssembly.Servicos.Implementacao
{
    public class VentaServico : IVentaServico
    {
        private readonly HttpClient _httpClient;

        public VentaServico(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Registar(VentaDTO dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Registar", dto);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;
        }
    }
}
