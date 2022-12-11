using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        ILeilaoDao _leilaoDao;
        ICategoriaDao _categoriaDao;
        IProdutoService _produtoService;

        public HomeController(ILeilaoDao leilaoDao, ICategoriaDao categoriaDao, IProdutoService produtoService)
        {
            _leilaoDao = leilaoDao;
            _categoriaDao = categoriaDao;
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
            var termoNormalized = termo.ToUpper();
            var leiloes = _produtoService.PesquisaLeiloesEmPregaoPorTermo(termoNormalized);

            return View(leiloes);
        }
    }
}
