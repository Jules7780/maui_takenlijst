using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Taak
    {
        public Taak(string titel, string beschrijving, bool afgewerkt, int persoonId, DateTime creatieDatum, DateTime gewijzigdDatum)
        {
            Titel = titel;
            Beschrijving = beschrijving;
            Afgewerkt = afgewerkt;
            PersoonId = persoonId;
            CreatieDatum = creatieDatum;
            GewijzigdDatum = gewijzigdDatum;
        }

        public Taak(int id, string titel, string beschrijving, bool afgewerkt, int persoonId, DateTime creatieDatum, DateTime gewijzigdDatum)
        {
            Id = id;
            Titel = titel;
            Beschrijving = beschrijving;
            Afgewerkt = afgewerkt;
            PersoonId = persoonId;
            CreatieDatum = creatieDatum;
            GewijzigdDatum = gewijzigdDatum;
        }

        public int Id { get; set; }
        public string Titel {  get; set; }
        public string Beschrijving { get; set; }
        public bool Afgewerkt { get; set; }
        public int PersoonId { get; set; }
        public DateTime CreatieDatum { get; }
        public DateTime GewijzigdDatum { get; set; }
    }
}
