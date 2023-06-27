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
    public class BalanceControllerTests
    {
        private readonly Mock<ILogger<BalanceController>> _logger;
        private readonly Mock<IMediator> _mediator;
        private readonly BalanceController _controller;
        public BalanceControllerTests()
        {
            _logger = new Mock<ILogger<BalanceController>>();
            _mediator = new Mock<IMediator>();
            _controller = new BalanceController(_logger.Object, _mediator.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ReturnOk()
        {
            PatrimonioCommand commando = new PatrimonioCommand();
            var retorno = (StatusCodeResult)await _controller.PostSaldoAsync(commando, It.IsAny<CancellationToken>()).ConfigureAwait(true);
            //retorno.Should().Be(HttpStatusCode.OK);
            //Assert.IsType<BadRequestObjectResult>(result);
            retorno.Should().NotBeNull();
            retorno.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
        //Retorno 412 Se tiver problema no command
        //Retorno NotFound Se não achar o cliente
    }
}