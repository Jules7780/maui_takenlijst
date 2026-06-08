using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public static class TaakFactory
    {
        public static Taak MaakNieuweTaak(string titel, string beschrijving, bool isGedaan, int persoonId) { 
            return new Taak(titel, beschrijving, isGedaan, persoonId,DateTime.Now, DateTime.Now);
        }

        public static Taak UpdateTaak(Taak t, string titel, string beschrijving, bool isGedaan, int persoonId)
        {

            t.Titel = titel;
            t.Beschrijving = beschrijving;
            t.Afgewerkt = isGedaan;
            t.PersoonId = persoonId;
            t.GewijzigdDatum = DateTime.Now;



            return t;
        }
    }
}
