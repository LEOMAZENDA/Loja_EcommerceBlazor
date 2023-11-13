using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.Contrato.Generica;
using Servico.Contrato;

namespace Servico.ImplementacaoServico;

public class ProductoServico : IProductoServico
{
    private readonly IGenericoRepositorio<Producto> _repositorio;
    private readonly IMapper _mapper;

    public ProductoServico(IGenericoRepositorio<Producto> repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<List<ProductoDTO>> Catalogo(string categoria, string buscar)
    {
        try
        {
            var consulta = _repositorio.Consultar(p =>
            p.Nombre.ToLower().Contains(buscar.ToLower()) &&
            p.IdCategoriaNavigation.Nombre.ToLower().Contains(categoria.ToLower())
            );

            List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<ProductoDTO> Criar(ProductoDTO dto)
    {
        try
        {
            var dbModelo = _mapper.Map<Producto>(dto);
            var rspModelo = await _repositorio.Criar(dbModelo);

            if (rspModelo.IdProducto != 0)
                return _mapper.Map<ProductoDTO>(rspModelo);
            else
                throw new TaskCanceledException("Não foi possível criar o registo");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<bool> Editar(ProductoDTO dto)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdProducto == dto.IdProducto);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                fromDbModelo.Nombre = dto.Nombre;
                fromDbModelo.Descripcion = dto.Descripcion;
                fromDbModelo.IdCategoria = dto.IdCategoria;
                fromDbModelo.Precio = dto.Precio;
                fromDbModelo.PrecioOferta = dto.PrecioOferta;
                fromDbModelo.Cantidad = dto.Cantidad;
                fromDbModelo.Imagen = dto.Imagen
                    ;
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
            var consulta = _repositorio.Consultar(p => p.IdProducto == id);
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

    public async Task<List<ProductoDTO>> Listar(string buscar)
    {
        try
        {
            var consulta = _repositorio.Consultar(p =>
            p.Nombre.ToLower().Contains(buscar.ToLower())
            );

            consulta = consulta.Include(c => c.IdCategoriaNavigation);

            List<ProductoDTO> lista = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<ProductoDTO> Obter(int id)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdProducto == id);
            consulta = consulta.Include(c => c.IdCategoriaNavigation);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
                return _mapper.Map<ProductoDTO>(fromDbModelo);
            else
                throw new TaskCanceledException("Registo não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
