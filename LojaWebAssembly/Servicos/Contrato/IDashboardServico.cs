using DTO;

namespace LojaWebAssembly.Servicos.Contrato
{
    public interface IDashboardServico
    {
        Task<ResponseDTO<DashBoardDTO>> Resume();
    }
}
