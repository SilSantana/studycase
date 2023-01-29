using Xunit;
using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Controllers;
using Alura.LeilaoOnline.WebApp.Services.Interfaces;
using Moq;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.Testes
{

    public class LeilaoControllerRemove
    {
        private readonly Mock<IAdminService> _adminServiceMoq;

        public LeilaoControllerRemove()
        {
            _adminServiceMoq = new Mock<IAdminService>();   
        }


        [Fact]
        public void DadoLeilaoInexistenteEntaoRetorna404()
        {
            // arrange
            var idLeilaoInexistente = 11232; 
            var actionResultEsperado = typeof(NotFoundResult);
             _adminServiceMoq.Setup(x => x.RemoveLeilao(new Leilao()));
            var controller = new LeilaoController(_adminServiceMoq.Object);

            // act
            var result = controller.Remove(idLeilaoInexistente);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmPregaoEntaoRetorna404()
        {
            // arrange
            var idLeilaoEmPregao = 11232; 
            var actionResultEsperado = typeof(NotFoundResult);
            _adminServiceMoq.Setup(x => x.ConsultaLeilaoPorId(idLeilaoEmPregao));
            var controller = new LeilaoController(_adminServiceMoq.Object);

            // act
            var result = controller.Remove(idLeilaoEmPregao);
          

            // assert
            Assert.IsType(actionResultEsperado, result);
        }

        [Fact]
        public void DadoLeilaoEmRascunhoEntaoExcluiORegistro()
        {
            // arrange
            var idLeilaoEmRascunho = 11232; 
            var actionResultEsperado = typeof(NoContentResult);
            _adminServiceMoq.Setup(x => x.ConsultaLeilaoPorId(idLeilaoEmRascunho)).Returns(new Leilao());
            _adminServiceMoq.Setup(x => x.RemoveLeilao(new Leilao()));
            var controller = new LeilaoController(_adminServiceMoq.Object);

            // act
            var result = controller.Remove(idLeilaoEmRascunho);

            // assert
            Assert.IsType(actionResultEsperado, result);
        }
    }
}
