using controle_contatos.Data;
using Controle_Contatos.Models;
using Controle_Contatos.Repositorio.Interfaces;

namespace Controle_Contatos.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly ContatoDbContext _context;

        public UsuarioRepositorio(ContatoDbContext context)
        {
            _context = context;
        }

        public UsuarioModel RetornaUsuario(int id)
        {
            UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuario == null) throw new Exception("Usuário não encontrado");

            return usuario;
        }

        public List<UsuarioModel> RetornaUsuarios()
        {
            List<UsuarioModel> usuarios = _context.Usuarios.ToList();
            return usuarios;

        }
        public UsuarioModel CadastrarUsuario(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public UsuarioModel AlterarUsuario(int id, UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = _context.Usuarios.FirstOrDefault(x => x.Id == id);

            if (usuarioDb == null) throw new Exception("Não encontramos o usuário");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Senha = usuario.Senha;
            usuarioDb.Tipo = usuario.Tipo;
            usuarioDb.DataAlteracao = DateTime.Now;

            _context.Usuarios.Update(usuarioDb);
            _context.SaveChanges();

            return usuarioDb;
        }

        public bool Deletar(int id)
        {
            UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x =>x.Id == id);

            if (usuario == null) throw new Exception("Usuário não encontrado");

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return true;
        }

        public UsuarioModel RetornaUsuarioLogin(string login)
        {
            UsuarioModel usuario = _context.Usuarios.FirstOrDefault(x => x.Login == login);
            return usuario;
        }
    }
}
