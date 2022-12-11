using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
       
        IEnumerable<Leilao> BuscarLeiloes();

        Leilao BuscarPorId(int id);

        void Remover(Leilao leilao);

        void Atualizar(Leilao leilao);

        void Adicionar(Leilao leilao);

    }
}
