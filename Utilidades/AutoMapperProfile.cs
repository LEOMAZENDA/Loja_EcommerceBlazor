using AutoMapper;
using DTO;
using Modelo;

namespace Utilidades;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        CreateMap<Usuario, LoginDTO>().ReverseMap();
        CreateMap<Usuario, SessaoIniciadaDTO>().ReverseMap();

        CreateMap<Categoria, CategoriaDTO>().ReverseMap();

        CreateMap<Producto, ProductoDTO>();
        CreateMap<ProductoDTO, Producto>().ForMember(destino =>
            destino.IdCategoriaNavigation,
            opt => opt.Ignore()
        );

        CreateMap<Venta, VentaDTO>().ReverseMap();
        CreateMap<DetalleVenta, DetalleVentaDTO>().ReverseMap();
    }
}
