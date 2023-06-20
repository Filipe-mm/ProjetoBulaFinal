using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjetoBulaFinal.DTOs;
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

        [Test]
        public async Task Details_WithValidId_ReturnsOkResultWithMedicamento()
        {
            // Arrange
            var medicamentos = new List<Medicamento>
            {
                new Medicamento { Id = 1, Nome = "Medicamento 1" },
                new Medicamento { Id = 2, Nome = "Medicamento 2" }
            };
            _servicoMock.Setup(s => s.TodosAsync()).ReturnsAsync(medicamentos);

            // Act
            var result = await _controller.Details(2);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(medicamentos[1]));
        }

        [Test]
        public async Task Create_WithValidMedicamentoDTO_ReturnsCreatedResultWithMedicamento()
        {
            // Arrange
            var medicamentoDTO = new MedicamentoDTO { Nome = "Medicamento 1" };
            var medicamento = new Medicamento { Id = 1, Nome = "Medicamento 1" };
            _servicoMock.Setup(s => s.IncluirAsync(It.IsAny<Medicamento>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Create(medicamentoDTO);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(201));
            _servicoMock.Verify(s => s.IncluirAsync(It.IsAny<Medicamento>()), Times.Once);
        }

        [Test]
        public async Task Update_WithMatchingId_ReturnsOkResultWithUpdatedMedicamento()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, Nome = "Medicamento 1" };
            _servicoMock.Setup(s => s.AtualizarAsync(It.IsAny<Medicamento>())).ReturnsAsync(medicamento);

            // Act
            var result = await _controller.Update(1, medicamento);

            // Assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            var okResult = (OkObjectResult)result;
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
            Assert.That(okResult.Value, Is.EqualTo(medicamento));
            _servicoMock.Verify(s => s.AtualizarAsync(It.IsAny<Medicamento>()), Times.Once);
        }

        [Test]
        public async Task Update_WithMismatchingId_ReturnsBadRequestResult()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, Nome = "Medicamento 1" };

            // Act
            var result = await _controller.Update(2, medicamento);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task Delete_WithExistingId_ReturnsNoContentResult()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, Nome = "Medicamento 1" };
            _servicoMock.Setup(s => s.TodosAsync()).ReturnsAsync(new List<Medicamento> { medicamento });
            _servicoMock.Setup(s => s.ApagarAsync(It.IsAny<Medicamento>())).Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Delete(1);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(204));
            _servicoMock.Verify(s => s.ApagarAsync(It.IsAny<Medicamento>()), Times.Once);
        }
    }
}
