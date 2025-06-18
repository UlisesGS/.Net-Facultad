
namespace CentroEventos.Aplicacion
{
    public class UsuarioListarUseCase(IUsuarioRepositorio repoUsuario)
    {
        private readonly IUsuarioRepositorio _repositorioUsuario = repoUsuario;
        public List<Usuario> Ejecutar()
        {
            
            return _repositorioUsuario.Listar();
        }
    }
}
