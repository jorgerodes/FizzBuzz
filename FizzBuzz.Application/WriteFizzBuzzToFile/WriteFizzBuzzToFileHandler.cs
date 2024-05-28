using FizzBuzz.Application.Abstractions.Messaging;
using FizzBuzz.Domain.Abstractions;
using FizzBuzz.Domain.FizzBuzzs;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FizzBuzz.Application.WriteFizzBuzzToFile
{
    internal class WriteFizzBuzzToFileHandler : ICommandHandler<WriteFizzBuzzToFile, byte[]>
    {
        private readonly FizzBuzzService _service;
        private readonly ILogger<WriteFizzBuzzToFileHandler> _logger;


        public WriteFizzBuzzToFileHandler(FizzBuzzService service, ILogger<WriteFizzBuzzToFileHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<Result<byte[]>> Handle(WriteFizzBuzzToFile request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _service.WriteToFileAsync(request.Start, request.End);
                return Result<byte[]>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ocurrió una excepción: " + ex.Message);
                return Result.Failure<byte[]>(FizzBuzzErrors.Error);
            }



        }
    }
}
