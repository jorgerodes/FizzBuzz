using FizzBuzz.Application.FizzBuzz;
using FizzBuzz.Domain.FizzBuzzs;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;
using Xunit;

namespace FizzBuzz.Application.UnitTests
{
    public class FizzBuzzTests
    {
        private readonly ExecuteFizzBuzzHandler _handlerMock;

        private readonly FizzBuzzService _serviceMock;
        private readonly ILogger<ExecuteFizzBuzzHandler> _loggerMock;

        

        public FizzBuzzTests()
        {
            _serviceMock = Substitute.For<FizzBuzzService>();
            _loggerMock = NullLogger<ExecuteFizzBuzzHandler>.Instance;

            _handlerMock = new ExecuteFizzBuzzHandler(_serviceMock, _loggerMock);
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenEndgreatherThanStart()
        {
            //Arrange
            ExecuteFizzBuzz command = new(10, 5);

            //Act
            var resultado = await _handlerMock.Handle(command, default);

            //Assert
            resultado.Error.Should().Be(FizzBuzzErrors.EndGreaterThanStart);
        }


        [Fact]
        public async Task Handle_Should_ReturnSuccess()
        {
            //Arrange
            ExecuteFizzBuzz command = new(1, 50);

            //Act
            var resultado = await _handlerMock.Handle(command, default);

            //Assert
            resultado.IsSuccess.Should().BeTrue();
        }

    }

}
