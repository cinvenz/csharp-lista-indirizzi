using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public static class Parser
    {
        public const string InputFile = "..\\..\\..\\addresses.csv";
        public const string OutputFile = "..\\..\\..\\output.txt";

        public static IEnumerable<Address> Read()
        {
            using var input = File.OpenText(InputFile);
            var addresses = new List<Address>();

            input.ReadLine();

            Console.WriteLine("------");

            while (true)
            {
                string? line = input.ReadLine();
                if (line is null)
                {
                    Console.WriteLine("Complete");
                    return addresses;
                }

                var chunks = line.Split(',')!;

                if (chunks.Length is 6)
                {
                    var name = chunks[0];
                    var surname = chunks[1];
                    var street = chunks[2];
                    var city = chunks[3];
                    var province = chunks[4];
                    var zip = chunks[5];

                    var address = new Address(name, surname, street, city, province, zip);
                    addresses.Add(address);

                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }

        public static void Write(IEnumerable<Address> addresses)
        {
            using var output = File.CreateText(OutputFile);
            output.WriteLine("Name,Surname,Street,City,Province,ZIP:");

            foreach (var address in addresses)
            {
                output.WriteLine();
                output.WriteLine($"{address.Name}, {address.Surname}, {address.Street}, {address.City}, {address.Province}, {address.Zip}");
                output.WriteLine();
            }
        }
    }
}
