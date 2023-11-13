using Modelo;
using Repositorio.Contrato.Generica;

namespace Repositorio.Contrato;

public interface IVentaRepositorio : IGenericoRepositorio<Venta>
{
    Task<Venta> Registar(Venta modelo);
}
