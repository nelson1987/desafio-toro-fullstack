using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using ToroChallenge.Api.Controllers;
using ToroChallenge.Application.UseCases.Patrimonios;

namespace ToroChallenge.UnitTests
{
    public class SaldoConstollerTests
    {
        private readonly Mock<ILogger<SaldoController>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly SaldoController _controller;
        public SaldoConstollerTests()
        {
            _logger = new Mock<ILogger<SaldoController>>();
            _mediator = new Mock<IMediator>();
            _controller = new SaldoController(_logger.Object, _mediator.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ReturnOk()
        {
            PatrimonioCommand commando = new PatrimonioCommand();
            ObjectResult retorno = (ObjectResult)await _controller.Post(commando, It.IsAny<CancellationToken>());
            //retorno.Should().Be(HttpStatusCode.OK);
            retorno.Should().NotBeNull();
        }
    }
}