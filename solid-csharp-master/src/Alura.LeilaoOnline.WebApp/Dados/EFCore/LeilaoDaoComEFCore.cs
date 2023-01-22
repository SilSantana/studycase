using Alura.LeilaoOnline.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoComEFCore : ILeilaoDao
    {
        private readonly AppDbContext _context;

        public LeilaoDaoComEFCore()
        {
            _context = new AppDbContext();
        }

        public void Alterar(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public Leilao BuscarPorId(int id)
        {
            return _context.Leiloes.Find(id);
        }     

        public IEnumerable<Leilao> BuscarTodos()
        {
          return _context.Leiloes.Include(l => l.Categoria);
        }

        public void Excluir(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

        public void Incluir(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }
    }
}
