using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servico.Contrato;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoServico _servico;

        public ProductoController(IProductoServico servico)
        {
            _servico = servico;
        }

        [HttpGet("Listar/{buscar:alpha?}")]
        public async Task<IActionResult> Listar(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();
            try
            {
                if (buscar == "NA") buscar = "";

                response.EstaCorreto = true;
                response.Resultado = await _servico.Listar(buscar);
            }
            catch (Exception ex)
            {
                response.EstaCorreto = true;
                response.Mensagem = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Catalogo/{categoria:alpha?}/{buscar:alpha?}")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();
            try
            {
                if (categoria.ToLower() == "NA") buscar = "";
                if (buscar == "NA") buscar = "";

                response.EstaCorreto = true;
                response.Resultado = await _servico.Catalogo(categoria, buscar);
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
            var response = new ResponseDTO<ProductoDTO>();
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
        public async Task<IActionResult> Criar([FromBody] ProductoDTO dto)
        {
            var response = new ResponseDTO<ProductoDTO>();
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

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO dto)
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
}
