using CentroEventos.Aplicacion.Enums;
using CentroEventos.Aplicacion.Excepciones;
using CentroEventos.Aplicacion.Interfaces;

namespace CentroEventos.Aplicacion
{
    public class UsuarioListarUseCase(IUsuarioRepositorio repoUsuario, IServicioAutorizacion servicioAutorizacion)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        private readonly IServicioAutorizacion _servicioAutorizacion = servicioAutorizacion;
        public List<Usuario> Ejecutar(int idUsuario)
        {
            if(!_servicioAutorizacion.PoseeElPermiso(idUsuario, EnumPermiso.UsuarioListar))
            {
                throw new FalloAutorizacionException("ERROR - No estas autorizado.");
            }

            return _repositorioUsuario.Listar();
        }
    }
}
