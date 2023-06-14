using System.ComponentModel.DataAnnotations;

namespace Controle_Contatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O celular é obrigatório")]
        [Phone(ErrorMessage = "O numero informado não é válido")]
        public string Celular { get; set; }
    }
}
