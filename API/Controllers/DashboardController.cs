using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servico.Contrato;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashdoardServico _servico;
        public DashboardController(IDashdoardServico servico)
        {
            _servico = servico;
        }

        [HttpGet("Resume")]
        public IActionResult Resume()
        {
            var response = new ResponseDTO<DashBoardDTO>();

            try
            {
                response.EstaCorreto = true;
                response.Resultado = _servico.Resume();
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
