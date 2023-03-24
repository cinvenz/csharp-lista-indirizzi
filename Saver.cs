using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public static class Saver
    {
        public const string InputFile = "..\\..\\..\\addresses.csv";
        public const string OutputFile = "..\\..\\..\\output.txt";

        public static IEnumerable<Address> Read()
        {
            using var input = File.OpenText(InputFile);

            var addresses = new List<Address>();
            input.ReadLine();
            while (true)
            {
                string? line = input.ReadLine();

                if (line is null) return addresses;


                var chunks = line.Split(',')!;

                string name;
                string surname;
                string street;
                string city;
                string province;
                string zip;

                name = chunks[0];
                surname = chunks[1];
                street = chunks[2];
                city = chunks[3];
                province = chunks[4];
                zip = chunks[5];

                var address = new Address(name, surname, street, city, province, zip);
                addresses.Add(address);
            }
        }
        public static void Write(IEnumerable<Address> addresses)
        {
            using var output = File.CreateText(OutputFile);
            output.WriteLine("Name,Surname,Street,City,Province,ZIP:");

            foreach (var address in addresses)
            {
                output.WriteLine();
                output.WriteLine($"{address.Name}, {address.SecondName}, {address.Surname}, {address.Street}, {address.City}, {address.Province}, {address.Zip}");
                output.WriteLine();
            }
        }
    }
}
