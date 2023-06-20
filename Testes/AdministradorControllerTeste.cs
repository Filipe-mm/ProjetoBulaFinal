using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjetoBulaFinal.DTOs;
using ProjetoBulaFinal.Models;
using ProjetoBulaFinal.Repositorio.Interfaces;

namespace ProjetoBulaFinal.Testes
{
    [TestFixture]
    public class AdministradorControllerTeste
    {
        private AdministradorController _controller;
        private Mock<IServicoAdm<Administrador>> _servicoMock;

        [SetUp]
        public void Setup()
        {
            _servicoMock = new Mock<IServicoAdm<Administrador>>();
            _controller = new AdministradorController(_servicoMock.Object);
        }

        [Test]
        public async Task Login_WithEmptyEmailOrSenha_ReturnsBadRequestResult()
        {
            // Arrange
            var administradorDTO = new AdministradorDTO { Email = "", Senha = "" };

            // Act
            var result = await _controller.Login(administradorDTO);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(400));
        }
    }
}
