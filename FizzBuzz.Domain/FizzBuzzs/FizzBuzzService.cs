using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Domain.FizzBuzzs
{
    public class FizzBuzzService
    {
        public List<FizzBuzzItem> Execute(int start, int end)
        {
            List<FizzBuzzItem> result = new List<FizzBuzzItem>();

            for (int i = start; i <= end; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    result.Add(new FizzBuzzItem("FizzBuzz"));
                }
                else if (i % 3 == 0)
                {
                    result.Add(new FizzBuzzItem("Fizz"));
                }
                else if (i % 5 == 0)
                {
                    result.Add(new FizzBuzzItem("Buzz"));
                }
                else
                {
                    result.Add(new FizzBuzzItem(i.ToString()));
                }
            }
            return result;
        }

        public async Task<byte[]> WriteToFileAsync(int start, int end)
        {
            var fizzBuzzItems = Execute(start, end);
            var lines = fizzBuzzItems.Select(item => item.Value).ToList();
            var content = string.Join(" ", lines);

            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
            await writer.WriteAsync(content);
            await writer.FlushAsync();
            memoryStream.Position = 0;

            return memoryStream.ToArray();
        }
    }
}
