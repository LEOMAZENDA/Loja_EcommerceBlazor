using AutoMapper;
using DTO;
using Modelo;
using Repositorio.Contrato;
using Repositorio.Contrato.Generica;
using Servico.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.ImplementacaoServico
{
    public class DashdoardServico : IDashdoardServico
    {
        private readonly IVentaRepositorio _ventaRepositorio;
        private readonly IGenericoRepositorio<Usuario> _usuarioRepositorio;
        private readonly IGenericoRepositorio<Producto> _productoRepositorio;

        public DashdoardServico(IVentaRepositorio ventaRepositorio, 
            IGenericoRepositorio<Usuario> usuarioRepositorio, 
            IGenericoRepositorio<Producto> productoRepositorio)
        {
            _ventaRepositorio = ventaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
            _productoRepositorio = productoRepositorio;
        }

        private string Ingressos()
        {
            var consulta = _ventaRepositorio.Consultar();
            decimal? ingressos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingressos);
        }

        private int Ventas()
        {
            var consulta = _ventaRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        private int Clientes()
        {
            var consulta = _usuarioRepositorio.Consultar(u => u.Rol.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        private int Produtos()
        {
            var consulta = _productoRepositorio.Consultar();
            int total = consulta.Count();
            return total;
        }

        public DashBoardDTO Resume()
        {
            try
            {
                DashBoardDTO dto = new DashBoardDTO()
                {
                    TotalIngressos = Ingressos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    ToralProductoos = Produtos(),
                };

                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
