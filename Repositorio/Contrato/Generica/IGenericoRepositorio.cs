using System.Linq.Expressions;

namespace Repositorio.Contrato.Generica;

public interface IGenericoRepositorio<TModel> where TModel : class
{
    IQueryable<TModel> Consultar(Expression<Func<TModel, bool>>? filtro = null);
    Task<TModel> Criar(TModel modelo);
    Task<bool> Editar(TModel modelo);
    Task<bool> Eliminar(TModel modelo);
}
