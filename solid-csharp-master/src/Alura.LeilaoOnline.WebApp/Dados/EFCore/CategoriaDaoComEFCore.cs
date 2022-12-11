using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoComEFCore : ICategoriaDao
    {

        AppDbContext _context;

        public CategoriaDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> BuscarCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Categoria> BuscarCategoriasPorLeilao()
        {
            return _context.Categorias
                   .Include(c => c.Leiloes).ToList();
        }

        public Categoria BuscarPorId(int id)
        {
            return _context.Categorias.Find(id);
        }
    }
}
