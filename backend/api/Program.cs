using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TODO: Uncomment this once there's a need for a WebAPI
            // CreateWebHostBuilder(args).Build().Run();
            Console.WriteLine("What number would you like me to count to?");
            Console.Write("[0-100]:");
            var input = Console.ReadLine();
            uint number;
            if (!uint.TryParse(input, out number) || number > 100)
            {
                Console.WriteLine("'{0}' is not a valid number. Bye!", input);
                return;
            }

            var output = FizzBuzzPinkFlamingo.GenerateSequence(number);
            foreach (var line in output)
            {
                Console.WriteLine(line);
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
