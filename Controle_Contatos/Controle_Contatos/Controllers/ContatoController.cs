using controle_contatos.Repositorios.Interfaces;
using Controle_Contatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Controle_Contatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _ContatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _ContatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _ContatoRepositorio.RetornaContato();
            return View(contatos);
        }

        public IActionResult Alterar(int id)
        {
            ContatoModel contato = _ContatoRepositorio.retornaContatoId(id);
            return View(contato);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult ConfirmarExclusao(int id)
        {
            ContatoModel contato = _ContatoRepositorio.retornaContatoId(id);
            return View(contato);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContatoRepositorio.Criar(contato);
                    TempData["MensagemSucesso"] = "Seu contato foi cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, seu contato não foi cadastrado. detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ContatoRepositorio.AlterarContato(contato);
                    TempData["MensagemSucesso"] = "Seu contato foi alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, seu contato não foi alterado. detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Apagar(int id) {

            try
            {
                bool apagado = _ContatoRepositorio.RemoverContato(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Seu contato foi apagado com sucesso";
                    return RedirectToAction("Index");
                }

                return RedirectToAction("Index");

            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, seu contato não foi alterado. detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
            
        }
    }
}
