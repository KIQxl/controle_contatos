
using Controle_Contatos.Models;

namespace controle_contatos.Repositorios.Interfaces
{
    public interface IContatoRepositorio
    {

        ContatoModel retornaContatoId(int id);
        List<ContatoModel> RetornaContato();
        ContatoModel Criar(ContatoModel contato);

        ContatoModel AlterarContato(ContatoModel contato);

        bool RemoverContato(int id);
    }
}
