using FizzBuzz.Domain.FizzBuzzs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Domain.UnitTests
{
    internal class FizzBuzzMock
    {
        public static readonly RandomNumber? Start = new RandomNumber(1);
        public static readonly RandomNumber? End = new RandomNumber(100);
    }
}
