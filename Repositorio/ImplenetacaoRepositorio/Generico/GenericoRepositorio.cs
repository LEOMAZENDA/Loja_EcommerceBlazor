using Repositorio.Contrato.Generica;
using Repositorio.DBContext;
using System.Linq.Expressions;

namespace Repositorio.ImplenetacaoRepositorio.Generico;

public class GenericoRepositorio<TModelo> : IGenericoRepositorio<TModelo> where TModelo : class
{
    private readonly DbecommerceContext _dbContext;

    public GenericoRepositorio(DbecommerceContext bdContext)
    {
        _dbContext = bdContext;
    }

    public IQueryable<TModelo> Consultar(Expression<Func<TModelo, bool>>? filtro = null)
    {
        IQueryable<TModelo> consulta = filtro == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(filtro);
        return consulta;
    }

    public async Task<TModelo> Criar(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Editar(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Update(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> Eliminar(TModelo modelo)
    {
        try
        {
            _dbContext.Set<TModelo>().Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
}

