using Controle_Contatos.Models;

namespace Controle_Contatos.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {

        public UsuarioModel RetornaUsuarioLogin(string login);
        public List<UsuarioModel> RetornaUsuarios();
        public UsuarioModel RetornaUsuario(int id);
        public UsuarioModel CadastrarUsuario(UsuarioModel usuario);
        public UsuarioModel AlterarUsuario(int id, UsuarioModel usuario);
        public bool Deletar(int id);
    }
}
