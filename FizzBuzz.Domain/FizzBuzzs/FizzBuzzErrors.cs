using FizzBuzz.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Domain.FizzBuzzs
{
    public static class FizzBuzzErrors
    {

        public static Error Error = new Error(
            "FizzBuzzErrors.Error",
            "Ha ocurrido un error"
        );


        public static Error Zero = new Error(
            "FizzBuzzErrors.Zero",
            "Los números deben ser enteros positivos"
        );
        public static Error EndGreaterThanStart  = new Error(
            "FizzBuzzErrors.EndGreaterThanStart",
            "Inicio no puede ser menor que final"
        );
    }
}
