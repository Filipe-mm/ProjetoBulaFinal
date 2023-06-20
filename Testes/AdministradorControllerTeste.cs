using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProjetoBulaFinal.Controllers;
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

        [Test]
        public async Task Login_WithInvalidEmailOrSenha_ReturnsNotFoundResult()
        {
            // Arrange
            var administradorDTO = new AdministradorDTO { Email = "admin@example.com", Senha = "password" };
            _servicoMock.Setup(s => s.Login(administradorDTO.Email, administradorDTO.Senha)).ReturnsAsync((Administrador)null);

            // Act
            var result = await _controller.Login(administradorDTO);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(404));
        }

        [Test]
        public async Task Login_WithValidEmailAndSenha_ReturnsOkResultWithAdministradorLogado()
        {
            // Arrange
            var administradorDTO = new AdministradorDTO { Email = "admin@example.com", Senha = "password" };
            var administrador = new Administrador { Email = "admin@example.com", Senha = "password" };
            _servicoMock.Setup(s => s.Login(administradorDTO.Email, administradorDTO.Senha)).ReturnsAsync(administrador);

            // Act
            var result = await _controller.Login(administradorDTO);

            // Assert
            Assert.That(result, Is.TypeOf<StatusCodeResult>());
            var statusCodeResult = (StatusCodeResult)result;
            Assert.That(statusCodeResult.StatusCode, Is.EqualTo(200));
            _servicoMock.Verify(s => s.Login(administradorDTO.Email, administradorDTO.Senha), Times.Once);
        }
    }
}
