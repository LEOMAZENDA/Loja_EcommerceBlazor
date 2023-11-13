using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servico.Contrato;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeltaController : ControllerBase
    {
        private readonly IVentaServico _servico;

        public VeltaController(IVentaServico servico)
        {
            _servico = servico;
        }


        [HttpPost("Registar")]
        public async Task<IActionResult> Registar([FromBody] VentaDTO dto)
        {
            var response = new ResponseDTO<VentaDTO>();
            try
            {
                response.EstaCorreto = true;
                response.Resultado = await _servico.Registar(dto);
            }
            catch (Exception ex)
            {
                response.EstaCorreto = true;
                response.Mensagem = ex.Message;
            }
            return Ok(response);
        }
    }
}
