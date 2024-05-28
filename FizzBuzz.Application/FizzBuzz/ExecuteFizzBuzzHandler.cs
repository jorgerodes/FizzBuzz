using FizzBuzz.Application.Abstractions.Messaging;
using FizzBuzz.Domain.Abstractions;
using FizzBuzz.Domain.FizzBuzzs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Application.FizzBuzz
{
    internal sealed class ExecuteFizzBuzzHandler : ICommandHandler<ExecuteFizzBuzz, List<FizzBuzzItem>>
    {
        private readonly FizzBuzzService _service;
        private readonly ILogger<ExecuteFizzBuzzHandler> _logger;

        public ExecuteFizzBuzzHandler(
            FizzBuzzService service, 
            ILogger<ExecuteFizzBuzzHandler> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<Result<List<FizzBuzzItem>>> Handle(ExecuteFizzBuzz request, CancellationToken cancellationToken)
        {
            try
            {
                //error si start es menor o igual que end
                if (request.Start > request.End )
                {
                    return Result.Failure<List<FizzBuzzItem>>(FizzBuzzErrors.EndGreaterThanStart);
                }


                var result = _service.Execute(request.Start, request.End);
                return await Task.FromResult(result);

            }

            catch (Exception ex)
            {
                _logger.LogError("Ocurrió una excepción: " + ex.Message);
                return Result.Failure<List<FizzBuzzItem>> (FizzBuzzErrors.Error);
            }

           
        }
    }
}
