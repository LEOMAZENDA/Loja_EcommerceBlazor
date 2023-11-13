using System.Net.Http.Json;
using DTO;
using LojaWebAssembly.Servicos.Contrato;

namespace LojaWebAssembly.Servicos.Implementacao;

public class UsuarioServico : IUsuarioServico
{
    private readonly HttpClient _httpClient;

    public UsuarioServico(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ResponseDTO<SessaoIniciadaDTO>> Autorizacao(LoginDTO dto)
    {
        var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacao", dto);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SessaoIniciadaDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<UsuarioDTO>> Criar(UsuarioDTO dto)
    {
        var response = await _httpClient.PostAsJsonAsync("Usuario/Criar", dto);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Editar(UsuarioDTO dto)
    {
        var response = await _httpClient.PutAsJsonAsync("Usuario/Editar", dto);
        var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
        return result!;
    }

    public async Task<ResponseDTO<bool>> Eliminar(int id)
    {
        return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
    }

    public async Task<ResponseDTO<List<UsuarioDTO>>> Listar(string rol, string buscar)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Listar/{rol}/{buscar}");
    }

    public async Task<ResponseDTO<UsuarioDTO>> Obter(int id)
    {
        return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obter/{id}");
    }
}
