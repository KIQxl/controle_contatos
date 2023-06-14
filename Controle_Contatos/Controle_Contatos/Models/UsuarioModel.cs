using Controle_Contatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Controle_Contatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Esse campo é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public EnumTipo Tipo { get; set; }
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }

        public bool ValidaSenha(string senha)
        {
            return this.Senha == senha;
        }
    }
}
