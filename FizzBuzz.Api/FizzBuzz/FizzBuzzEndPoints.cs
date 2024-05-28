using FizzBuzz.Application.Abstractions.Clock;
using FizzBuzz.Application.FizzBuzz;
using FizzBuzz.Application.WriteFizzBuzzToFile;
using MediatR;

namespace FizzBuzz.Api.FizzBuzz
{
    public static class FizzBuzzEndPoints
    {
        public static IEndpointRouteBuilder MapFizzBuzzEndpoints(this IEndpointRouteBuilder builder)
        {

            builder.MapPost("/fizzbuzz", ExecuteFizzBuzzAsync);
            builder.MapPost("/fizzbuzz/download", DownloadFileFizzBuzzAsync);

            return builder;
        }

        public static async Task<IResult> ExecuteFizzBuzzAsync(
            ISender sender, 
            FizzBuzzRequest request,
            CancellationToken cancellationToken)
        {
            var command = new ExecuteFizzBuzz(request.start,request.end);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsFailure)
            {
                return Results.BadRequest(result.Error);
            }

            var values = string.Join(",", result.Value.Select(item => item.Value));

            return result.IsSuccess
                ? Results.Ok(values)
                : Results.NotFound(result.Error);

        }

        public static async Task<IResult> DownloadFileFizzBuzzAsync(
            ISender sender,
            IDateTimeProvider dateTimeProvider,
            FizzBuzzRequest request,
            CancellationToken cancellationToken)
        {
            var command = new WriteFizzBuzzToFile(request.start, request.end);

            var result = await sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                var fileName = "FizzBuzz_" + dateTimeProvider.currentTime.ToString("yyyy-MM-dd") + ".txt";
                return Results.File(result.Value, "application/octet-stream", fileName);
            }
            else
            {
                return Results.BadRequest(result.Error);
            }

        }
    }
}
