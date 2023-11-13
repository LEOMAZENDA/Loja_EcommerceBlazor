using DTO;
using Microsoft.AspNetCore.Mvc;
using Servico.Contrato;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioServico _servico;

    public UsuarioController(IUsuarioServico servico)
    {
        _servico = servico;
    }

    [HttpGet("Listar/{rol:alpha}/{buscar:alpha?}")]
    public async Task<IActionResult> Listar(string rol, string buscar = "NA")
    {
        var response = new ResponseDTO<List<UsuarioDTO>>();
        try
        {
            if (buscar == "NA") buscar = "";

            response.EstaCorreto = true;
            response.Resultado = await _servico.Listar(rol, buscar);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }

    [HttpGet("Obter/{Id:int}")]
    public async Task<IActionResult> Obter(int Id)
    {
        var response = new ResponseDTO<UsuarioDTO>();
        try
        {
            response.EstaCorreto = true;
            response.Resultado = await _servico.Obter(Id);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost("Criar")]
    public async Task<IActionResult> Criar([FromBody] UsuarioDTO dto)
    {
        var response = new ResponseDTO<UsuarioDTO>();
        try
        {
            response.EstaCorreto = true;
            response.Resultado = await _servico.Criar(dto);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }

    [HttpPost("Autorizacao")]
    public async Task<IActionResult> Autorizacao([FromBody] LoginDTO dto)
    {
        var response = new ResponseDTO<SessaoIniciadaDTO>();
        try
        {
            response.EstaCorreto = true;
            response.Resultado = await _servico.Autorizacao(dto);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }

    [HttpPut("Editar")]
    public async Task<IActionResult> Editar([FromBody] UsuarioDTO dto)
    {
        var response = new ResponseDTO<bool>();
        try
        {
            response.EstaCorreto = true;
            response.Resultado = await _servico.Editar(dto);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }

    [HttpDelete("Eliminar/{Id:int}")]
    public async Task<IActionResult> Eliminar(int Id)
    {
        var response = new ResponseDTO<bool>();
        try
        {
            response.EstaCorreto = true;
            response.Resultado = await _servico.Eliminar(Id);
        }
        catch (Exception ex)
        {
            response.EstaCorreto = true;
            response.Mensagem = ex.Message;
        }
        return Ok(response);
    }
}
