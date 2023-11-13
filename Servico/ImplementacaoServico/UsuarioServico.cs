using AutoMapper;
using DTO;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Repositorio.Contrato.Generica;
using Servico.Contrato;

namespace Servico.ImplementacaoServico;

public class UsuarioServico : IUsuarioServico
{
    private readonly IGenericoRepositorio<Usuario> _repositorio;
    private readonly IMapper _mapper ;

    public UsuarioServico(IGenericoRepositorio<Usuario> repositorio, IMapper mapper)
    {
        _repositorio = repositorio;
        _mapper = mapper;
    }

    public async Task<SessaoIniciadaDTO> Autorizacao(LoginDTO modelo)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.Correo == modelo.Correo && p.Clave == modelo.Clave);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo == null)
                return _mapper.Map<SessaoIniciadaDTO>(fromDbModelo);
            else
                throw new TaskCanceledException("Usuario não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<UsuarioDTO> Criar(UsuarioDTO modelo)
    {   
        try
        {
            var dbModelo = _mapper.Map<Usuario>(modelo);
            var rspModelo = await _repositorio.Criar(dbModelo);

            if (rspModelo.IdUsuario != 0)
                return _mapper.Map <UsuarioDTO>(rspModelo);
            else
                throw new TaskCanceledException("Não foi possível criar o registo");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<bool> Editar(UsuarioDTO modelo)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdUsuario == modelo.IdUsuario);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if(fromDbModelo != null)
            {
                fromDbModelo.NombreCompleto = modelo.NombreCompleto;
                fromDbModelo.Correo = modelo.Correo;
                fromDbModelo.Clave = modelo.Clave;
                var resultado = await _repositorio.Editar(fromDbModelo);

                if (!resultado)
                      throw new TaskCanceledException("Não foi possível editar o registo");
                return resultado;
;           }
            else
            {
                throw new TaskCanceledException("Usuario não encontrado");
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
            var consulta = _repositorio.Consultar(p => p.IdUsuario == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                var resultado = await _repositorio.Eliminar(fromDbModelo);
                if (!resultado)
                    throw new TaskCanceledException("Não foi possível eliminar o registo");
                return resultado;;
            }else
                throw new TaskCanceledException("Usuario não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public Task<List<UsuarioDTO>> Listar(string rol, string buscar)
    {
        try
        {

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public Task<UsuarioDTO> Obter(int id)
    {
        try
        {

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
