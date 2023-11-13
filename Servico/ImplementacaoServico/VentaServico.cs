using AutoMapper;
using DTO;
using Modelo;
using Repositorio.Contrato;
using Servico.Contrato;

namespace Servico.ImplementacaoServico;

public class VentaServico : IVentaServico
{
    private readonly IVentaRepositorio _repositorio;
    private readonly IMapper _mapper;

    public VentaServico(IVentaRepositorio repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<VentaDTO> Registar(VentaDTO dto)
    {
        try
        {
            var dbModelo = _mapper.Map<Venta>(dto);
            var rspMVendaEfectuada = await _repositorio.Registar(dbModelo);

            if (rspMVendaEfectuada.IdVenta == 0)
                throw new TaskCanceledException("Não foi possível registar a venda");
            return _mapper.Map<VentaDTO>(rspMVendaEfectuada);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
