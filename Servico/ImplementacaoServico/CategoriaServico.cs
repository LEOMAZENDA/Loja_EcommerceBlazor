using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.Contrato.Generica;
using Servico.Contrato;

namespace Servico.ImplementacaoServico;

public class CategoriaServico : ICategoriaServico
{
    private readonly IGenericoRepositorio<Categoria> _repositorio;
    private readonly IMapper _mapper;

    public CategoriaServico(IGenericoRepositorio<Categoria> repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<CategoriaDTO> Criar(CategoriaDTO dto)
    {
        try
        {
            var dbModelo = _mapper.Map<Categoria>(dto);
            var rspModelo = await _repositorio.Criar(dbModelo);

            if (rspModelo.IdCategoria != 0)
                return _mapper.Map<CategoriaDTO>(rspModelo);
            else
                throw new TaskCanceledException("Não foi possível criar o registo");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<bool> Editar(CategoriaDTO dto)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdCategoria == dto.IdCategoria);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                fromDbModelo.Nombre = dto.Nombre;
                var resultado = await _repositorio.Editar(fromDbModelo);

                if (!resultado)
                    throw new TaskCanceledException("Não foi possível editar o registo");
                return resultado;
                ;
            }
            else
            {
                throw new TaskCanceledException("Registo não encontrado");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    public async Task<bool> Eliminar(int id)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdCategoria == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                var resultado = await _repositorio.Eliminar(fromDbModelo);
                if (!resultado)
                    throw new TaskCanceledException("Não foi possível eliminar o registo");
                return resultado; ;
            }
            else
                throw new TaskCanceledException("Registo não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<List<CategoriaDTO>> Listar(string buscar)
    {
        try
        {
            var consulta = _repositorio.Consultar(p =>
            p.Nombre!.ToLower().Contains(buscar.ToLower())
            );
            
            List<CategoriaDTO> lista = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<CategoriaDTO> Obter(int id)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdCategoria == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
                return _mapper.Map<CategoriaDTO>(fromDbModelo);
            else
                throw new TaskCanceledException("Registo não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
