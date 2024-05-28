using Xunit;
using FizzBuzz.Domain.FizzBuzzs;
using FluentAssertions;
namespace FizzBuzz.Domain.UnitTests
{
    public class FizzBuzzTests
    {
        [Fact]
        public void Create_Should_SetPropertyValues()
        {
            //Arrange - > creación mock en otro archivo

            //Act

            var fb = FizzBuzz.Domain.FizzBuzzs.FizzBuzz.Create(FizzBuzzMock.Start!, FizzBuzzMock.End!);


            //Assert

            fb.Start.Should().Be(FizzBuzzMock.Start);
            fb.End.Should().Be(FizzBuzzMock.End);
        }

    }
}
