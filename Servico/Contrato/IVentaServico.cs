using DTO;

namespace Servico.Contrato;

public interface IVentaServico
{   
    Task<VentaDTO> Registar(VentaDTO dto);
}
