using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Persoon
    {
        public Persoon(string voornaam, string achternaam, DateTime geboortedatum, string url, DateTime creatieDatum, DateTime gewijzigdDatum)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geboortedatum = geboortedatum;
            Url = url;
            CreatieDatum = creatieDatum;
            GewijzigdDatum = gewijzigdDatum;
        }

        public Persoon(int id, string voornaam, string achternaam, DateTime geboortedatum, string url, DateTime creatieDatum, DateTime gewijzigdDatum)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Geboortedatum = geboortedatum;
            Url = url;
            CreatieDatum = creatieDatum;
            GewijzigdDatum = gewijzigdDatum;
        }

        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public string Url { get; set; }
        public DateTime CreatieDatum { get; }
        public DateTime GewijzigdDatum { get; set; }



    }
}
