using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoComEFCore : ICategoriaDao
    {

        private readonly AppDbContext _context;

        public CategoriaDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public Categoria ConsultaCategoriaPorId(int id)
        {
            return _context.Categorias.Include(c => c.Leiloes).First(c => c.Id == id);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _context.Categorias.Include(c => c.Leiloes);
        }
    }
}
