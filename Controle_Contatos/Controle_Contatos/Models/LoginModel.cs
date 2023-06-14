using System.ComponentModel.DataAnnotations;

namespace Controle_Contatos.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Informe o Login")]
		public string Login { get; set; }

        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
	}
}
