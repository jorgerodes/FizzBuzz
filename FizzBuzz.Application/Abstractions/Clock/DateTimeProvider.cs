using FizzBuzz.Application.Abstractions.Clock;

namespace FizzBuzz.Application.Abstractions.Clock;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime currentTime => DateTime.UtcNow;
}