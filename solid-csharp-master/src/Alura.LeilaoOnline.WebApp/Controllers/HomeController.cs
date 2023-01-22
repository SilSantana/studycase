using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdutoService _produtoService;

        public HomeController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        public IActionResult Index()
        {
            var categorias = _produtoService.ConsultaCategoriasComTotalDeLeiloesEmPregao();
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoria)
        {
            var categ = _produtoService.ConsultaCategoriaPorIdComLeiloesEmPregao(categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _produtoService.PesquisaLeiloesEmPregaoPorTermo(termo);
            return View(leiloes);
        }
    }
}
