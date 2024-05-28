using FizzBuzz.Application.Abstractions.Messaging;
using FizzBuzz.Domain.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Application.WriteFizzBuzzToFile
{
    public sealed record WriteFizzBuzzToFile(int Start, int End) : ICommand<byte[]>;
}
