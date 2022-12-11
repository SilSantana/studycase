using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Categoria> BuscarCategorias();

        IEnumerable<Categoria> BuscarCategoriasPorLeilao();

        Categoria BuscarPorId(int id);

    }
}
