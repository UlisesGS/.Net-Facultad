using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion;

public class ServicioAutorizacion : IServicioAutorizacion
{
    private readonly IUsuarioRepositorio _repositorioUsuario;
    public ServicioAutorizacion(IUsuarioRepositorio repoUsuario)
    {
        _repositorioUsuario = repoUsuario;
    }

    public bool PoseeElPermiso(int IdUsuario, EnumPermiso permiso)
    {
        
        var usuario = _repositorioUsuario.BuscarPorId(IdUsuario) ?? throw new EntidadNotFoundException("ERROR - El usuario no existe.");
        
        return usuario.Permisos.Contains(permiso);

    }
}
