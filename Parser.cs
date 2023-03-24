using csharp_lista_indirizzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Parser
{
    public const string InputFile = "..\\..\\..\\addresses.csv";
    public const string OutputFile = "..\\..\\..\\addresses.txt";

    public static IEnumerable<Indirizzo> Read()
    {
        using var address = File.OpenText(InputFile);
        var indirizzi = new List<Indirizzo>();

        address.ReadLine();
        while (true)
        {
            string? line = address.ReadLine();
            if (line is null) return indirizzi;

            var chunks = line.Split(',')!;
            var nome = chunks[0];
            var cognome = chunks[1];
            var indirizzo = chunks[2];
            var citta = chunks[3];
            var provincia = chunks[4];
            var cap = chunks[5];

            var credenziali = new Indirizzo(nome, cognome, indirizzo, citta, provincia, cap);
            indirizzi.Add(credenziali);
        }

    }

    public static void Write(IEnumerable<Indirizzo> indirizzi)
    {
        using var output = File.CreateText(OutputFile);
        output.WriteLine("Lista indirizzi:");

        foreach (var indirizzo in indirizzi)
        {
            output.WriteLine();
            output.WriteLine("------ Libro ------");
            output.WriteLine($"nome: {indirizzo.nome}");
            output.WriteLine($"cognome: {indirizzo.cognome}");
            output.WriteLine($"indirizzo:   {indirizzo.indirizzo}");
            output.WriteLine($"citta:   {indirizzo.citta}");
            output.WriteLine($"provincia:   {indirizzo.provincia}");
            output.WriteLine($"cap:   {indirizzo.cap}");
            output.WriteLine("-------------------");
        }
    }


}
