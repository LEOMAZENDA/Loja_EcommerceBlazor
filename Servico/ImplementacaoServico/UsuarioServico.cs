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

    public async Task<SessaoIniciadaDTO> Autorizacao(LoginDTO dto)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.Correo == dto.Correo && p.Clave == dto.Clave);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo == null)
                return _mapper.Map<SessaoIniciadaDTO>(fromDbModelo);
            else
                throw new TaskCanceledException("Senha ou email iválida");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<UsuarioDTO> Criar(UsuarioDTO dto)
    {   
        try
        {
            var dbModelo = _mapper.Map<Usuario>(dto);
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

    public async Task<bool> Editar(UsuarioDTO dto)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdUsuario == dto.IdUsuario);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if(fromDbModelo != null)
            {
                fromDbModelo.NombreCompleto = dto.NombreCompleto;
                fromDbModelo.Correo = dto.Correo;
                fromDbModelo.Clave = dto.Clave;
                var resultado = await _repositorio.Editar(fromDbModelo);

                if (!resultado)
                      throw new TaskCanceledException("Não foi possível editar o registo");
                return resultado;
;           }
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
            var consulta = _repositorio.Consultar(p => p.IdUsuario == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
            {
                var resultado = await _repositorio.Eliminar(fromDbModelo);
                if (!resultado)
                    throw new TaskCanceledException("Não foi possível eliminar o registo");
                return resultado;;
            }else
                throw new TaskCanceledException("Registo não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<List<UsuarioDTO>> Listar(string rol, string buscar)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => 
            p.Rol == rol && string.Concat(p.NombreCompleto.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower())
            );

            List<UsuarioDTO> lista = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
            return lista;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    public async Task<UsuarioDTO> Obter(int id)
    {
        try
        {
            var consulta = _repositorio.Consultar(p => p.IdUsuario == id);
            var fromDbModelo = await consulta.FirstOrDefaultAsync();

            if (fromDbModelo != null)
                return _mapper.Map<UsuarioDTO>(fromDbModelo);         
            else
                throw new TaskCanceledException("Registo não encontrado");
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
