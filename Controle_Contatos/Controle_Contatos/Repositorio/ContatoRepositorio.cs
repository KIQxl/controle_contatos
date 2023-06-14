

using controle_contatos.Data;
using Controle_Contatos.Models;
using controle_contatos.Repositorios.Interfaces;

namespace controle_contatos.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ContatoDbContext _context;



        public ContatoRepositorio(ContatoDbContext context)
        {
            this._context = context;
        }

        public ContatoModel retornaContatoId(int id)
        {
            ContatoModel contato = _context.Contatos.FirstOrDefault(x => x.Id == id);
            return contato;
        }

        public List<ContatoModel> RetornaContato()
        {
            return _context.Contatos.ToList();
        }
        public ContatoModel Criar(ContatoModel contato)
        {
            _context.Contatos.Add(contato);
            _context.SaveChanges();

            return contato;
        }

        public ContatoModel AlterarContato(ContatoModel contato)
        {
            ContatoModel contatoDb = retornaContatoId(contato.Id);
            if (contatoDb == null) throw new Exception("Contato não encontrado");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _context.Contatos.Update(contatoDb);
            _context.SaveChanges();

            return contatoDb;
        }

        public bool RemoverContato(int id)
        {
            ContatoModel contatoDb = _context.Contatos.FirstOrDefault(x => x.Id == id);
            if (contatoDb == null) throw new Exception("Contato Não encontrado");

            _context.Remove(contatoDb);
            _context.SaveChanges();

            return true;

        }
    }
}

