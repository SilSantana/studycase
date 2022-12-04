using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.AspNetCore.Routing;
using Alura.LeilaoOnline.WebApp.Dados;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        ILeilaoDao _leilaoDao;

        public HomeController(ILeilaoDao leilaoDao)
        {
            _leilaoDao = leilaoDao;
        }

        public IActionResult Index()
        {
            var categorias = _leilaoDao.BuscarCategoriasPorLeilao()
                .Select(c => new CategoriaComInfoLeilao
                {
                    Id = c.Id,
                    Descricao = c.Descricao,
                    Imagem = c.Imagem,
                    EmRascunho = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = c.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Finalizado).Count(),
                });
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
            var categ = _leilaoDao.BuscarCategoriasPorLeilao().First(c => c.Id == categoria);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo;
            var termoNormalized = termo.ToUpper();
            var leiloes = _leilaoDao.BuscarLeiloes()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termoNormalized) ||
                    c.Descricao.ToUpper().Contains(termoNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termoNormalized));
            return View(leiloes);
        }
    }
}
