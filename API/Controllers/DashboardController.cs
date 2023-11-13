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


    }
}
