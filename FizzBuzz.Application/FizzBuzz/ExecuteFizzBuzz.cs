using FizzBuzz.Application.Abstractions.Messaging;
using FizzBuzz.Domain.FizzBuzzs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Application.FizzBuzz
{
    public sealed record ExecuteFizzBuzz(int Start, int End): ICommand<List<FizzBuzzItem>>;
}
