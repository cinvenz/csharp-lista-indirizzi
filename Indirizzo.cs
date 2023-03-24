using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lista_indirizzi
{
    public class Indirizzo
    {
        public string nome { get; init; }
        public string cognome { get; init; }
        public string indirizzo { get; init; }
        public string citta { get; init; }
        public string provincia { get; init; }
        public string cap { get; init; }

        public Indirizzo(string nome, string cognome, string indirizzo, string citta, string provincia, string cap)
        {
            nome = nome;
            cognome = cognome;
            indirizzo = indirizzo;
            citta = citta;
            provincia = provincia;
            cap = cap;
        }
    }
}
