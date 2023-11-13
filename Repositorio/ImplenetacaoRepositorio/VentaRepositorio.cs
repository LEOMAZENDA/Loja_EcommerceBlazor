using Modelo;
using Repositorio.Contrato;
using Repositorio.DBContext;
using Repositorio.ImplenetacaoRepositorio.Generico;

namespace Repositorio.ImplenetacaoRepositorio;

public class VentaRepositorio : GenericoRepositorio<Venta>, IVentaRepositorio
{
    private readonly DbecommerceContext _dbContext;

    public VentaRepositorio(DbecommerceContext bdContext) : base(bdContext)
    {
        _dbContext = bdContext;
    }

    public async Task<Venta> Registar(Venta modelo)
    {
        Venta ventaGenerada = new Venta();

        using (var transacion = _dbContext.Database.BeginTransaction())
        {
            try
            {
                foreach (DetalleVenta dv in modelo.DetalleVenta )
                {
                    Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                    producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                    _dbContext.Productos.Update(producto_encontrado);
                }
                await _dbContext.SaveChangesAsync();

                await _dbContext.Venta.AddAsync(modelo);
                await _dbContext.SaveChangesAsync();
                ventaGenerada = modelo;
                transacion.Commit();
            }
            catch (Exception)
            {
                transacion.Rollback();
                throw;
            }
        }
        return ventaGenerada;
    }
}
