using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Domain.FizzBuzzs
{
    public sealed class FizzBuzz
    {
        public RandomNumber? Start { get; private set; }
        public RandomNumber? End { get; private set; }

        //constructor privado y creación de objeto mediante objeto estático
        //(no lo estoy utilizando en el proyecto; es sólo para demostración de buena práctica)
        private FizzBuzz(RandomNumber start, RandomNumber end) 
        {
            Start = start;
            End = end;
        }

        public  static List<FizzBuzzItem> Resolve(FizzBuzzService service, RandomNumber start, RandomNumber end)
        {
            return service.Execute(start.Value, end.Value);
        }

        public static FizzBuzz Create(
            RandomNumber start,
            RandomNumber end
            )
        {
            var fizzbuzz = new FizzBuzz(start, end);
            return fizzbuzz;
        }

    }
}
