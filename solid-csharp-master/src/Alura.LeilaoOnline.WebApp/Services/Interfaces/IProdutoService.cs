using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Interfaces
{
    public interface IProdutoService
    {

        IEnumerable<Leilao> PesquisaLeiloesEmPregaoPorTermo(string termo);

        IEnumerable<CategoriaComInfoLeilao> ConsultaCategoriasComTotalDeLeiloesEmPregao();

        Categoria ConsultaCategoriaPorIdComLeiloesEmPregao(int id);


    }
}
