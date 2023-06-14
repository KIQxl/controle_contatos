using Controle_Contatos.Models;
using Controle_Contatos.Repositorio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Contatos.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.RetornaUsuarios();
            return View(usuarios);
        }

        public IActionResult Alterar(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.RetornaUsuario(id);
            return View(usuario);
        }

        public IActionResult CadastroUsuario()
        {   
            return View();
        }

        public IActionResult RetornaUsuario(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.RetornaUsuario(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult CadastroUsuario(UsuarioModel usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {

					_usuarioRepositorio.CadastrarUsuario(usuario);
					TempData["MensagemSucesso"] = "Seu usuário foi cadastrado com sucesso";
					return RedirectToAction("Index");
				}

				return RedirectToAction("Index");
			}
            catch (System.Exception erro)
            {
				TempData["MensagemErro"] = $"Ops, seu usuário não foi cadastrado. detalhe do erro: {erro.Message}";
				return RedirectToAction("Index");
			}
                        
        }

        [HttpPost]
        public IActionResult Alterar(int id, UsuarioModel usuario)
        {
            try
            {
				if (ModelState.IsValid)
				{
					_usuarioRepositorio.AlterarUsuario(id, usuario);
					TempData["MensagemSucesso"] = "Seu usuário foi alterado com sucesso";

					return RedirectToAction("Index");
				}

				return RedirectToAction("Index");
			}
            catch(System.Exception erro)
            {
				TempData["MensagemErro"] = $"Ops, seu usuário não foi alterado. detalhe do erro: {erro.Message}";
				return RedirectToAction("Index");
			}
        }

        public IActionResult ConfirmarExclusao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.RetornaUsuario(id);
            return View(usuario);
        }


        public IActionResult Deletar(int id)
        {
            try
            {
				bool apagado = _usuarioRepositorio.Deletar(id);
				if (apagado)
				{
					TempData["MensagemSucesso"] = "Seu usuário foi apagado com sucesso";
					return RedirectToAction("Index");
				}

				return RedirectToAction("Index");
			}
            catch(System.Exception erro)
            {
				TempData["MensagemErro"] = $"Ops, seu usuário não foi apagado. detalhe do erro: {erro.Message}";
				return RedirectToAction("Index");
			}
		}
    }
}
