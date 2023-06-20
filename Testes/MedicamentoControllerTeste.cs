using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjetoBulaFinal.Models;
using ProjetoBulaFinal.Repositorio.Interfaces;

namespace ProjetoBulaFinal.Testes
{
    [TestFixture]
    public class MedicamentoControllerTeste
    {
        private MedicamentoController _controller;
        private Mock<IServico<Medicamento>> _servicoMock;

        [SetUp]
        public void Setup()
        {
            _servicoMock = new Mock<IServico<Medicamento>>();
            _controller = new MedicamentoController(_servicoMock.Object);
        }

        [Test]
        public async Task Index_ReturnsOkResultWithMedicamentos()
        {
            // Arrange
            var medicamentos = new List<Medicamento>
            {
                new Medicamento { Id = 1, Nome = "Medicamento 1" },
                new Medicamento { Id = 2, Nome = "Medicamento 2" }
            };
            _servicoMock.Setup(s => s.TodosAsync()).ReturnsAsync(medicamentos);

            // Act
            var result = await _controller.Index();

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(medicamentos));
        }
    }
}
