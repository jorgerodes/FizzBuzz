using System.Security.Cryptography.X509Certificates;
using FizzBuzz.Application.FizzBuzz;
using FluentValidation;

namespace FizzBuzz.Application.FizzBuzz;

public class ExecuteFizzBuzzValidator : AbstractValidator<ExecuteFizzBuzz>
{
    public ExecuteFizzBuzzValidator()
    {
        RuleFor(c => c.Start)
            .NotEmpty().WithMessage("Start is required.");


        RuleFor(c => c.End)
            .NotEmpty().WithMessage("End is required.");
            
          
    }

}
