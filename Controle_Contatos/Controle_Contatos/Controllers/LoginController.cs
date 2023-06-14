using controle_contatos.Data;
using Controle_Contatos.Models;
using Controle_Contatos.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Contatos.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Logar(LoginModel loginModel, [FromServices] IUsuarioRepositorio _usuarioRepositorio)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepositorio.RetornaUsuarioLogin(loginModel.Login);

                    if(usuario != null)
                    {
                        if(usuario.ValidaSenha(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha incorreta";
                    }

                    TempData["MensagemErro"] = "Usuário ou senha incorreto não encontrado";
                }

                return View("Index");
            }
            catch (System.Exception erro) 
            {
                TempData["MensagemErro"] = $"Ocorreu um erro: {erro.Message}";
                return View("Index");
            }
        }
    }
}
