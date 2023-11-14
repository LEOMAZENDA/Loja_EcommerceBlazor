using DTO;

namespace LojaWebAssembly.Servicos.Contrato
{
    public interface IVentaServico
    {
        Task<ResponseDTO<VentaDTO>> Registar(VentaDTO dto);
    }
}
