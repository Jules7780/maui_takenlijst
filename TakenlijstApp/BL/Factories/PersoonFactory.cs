using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Factories
{
    public static class PersoonFactory
    {
        public static Persoon MaakNieuwePersoon(string url, string voornaam, string achternaam, DateTime geboortedatum)
        {
            return new Persoon(voornaam, achternaam, geboortedatum, url, DateTime.Now, DateTime.Now);
        }

        public static Persoon UpdatePersoon(Persoon p, string url, string voornaam, string achternaam, DateTime geboortedatum)
        {
            return new Persoon(voornaam, achternaam, geboortedatum, url, p.CreatieDatum, DateTime.Now);
        }
    }
}
