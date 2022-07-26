using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WEB.Repositories.Interfaces;
using WEB.Models;

namespace WEB.Controllers
{
    public class ObraController : Controller
    {
        private readonly IObraRepository _obraRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public ObraController(IObraRepository ObraRepository, IUsuarioRepository UsuarioRepository)
        {
            _obraRepository = ObraRepository;
            _usuarioRepository = UsuarioRepository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Lista()
        {
            IEnumerable<Obra> obra = _obraRepository.ListaObra();
            return View("Lista", obra);
        }

        [HttpGet]
        [Authorize]
        public IActionResult NovaObra()
        {
            Obra obra = new Obra();
            ViewBag.Usuarios = _usuarioRepository.usuarios();
            return View("NovaObra", obra);
        }

        [HttpPost]
        [Authorize]
        public IActionResult NovaObra(Obra obra)
        {
            _obraRepository.NovaObra(obra);
            return RedirectToAction("Lista");   
        }

        [HttpGet]
        [Authorize]
        public IActionResult Editar(int id)
        {
            Obra obra = _obraRepository.ObraPorId(id);
            ViewBag.Usuarios = _usuarioRepository.usuarios();
            return View("Editar", obra);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Editar(Obra obra)
        {
            _obraRepository.ObraEditar(obra);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Avaliar(int id)
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.ObraId = id;  
            return View("Avaliar", avaliacao);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Avaliar(Avaliacao avaliacao)
        {
            _obraRepository.NovaAvaliacao(avaliacao);
            return RedirectToAction("Lista");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Avaliacao(int id)
        {
            Avaliacao avaliacao = _obraRepository.AvaliacaoId(id);
            return View("Avaliacao", avaliacao);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AvaliacaoEditar(Avaliacao avaliacao)
        {
            _obraRepository.AvaliacaoEditar(avaliacao);
            return RedirectToAction("Lista");
        }
    }
}
