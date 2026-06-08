using BL.DTos;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Mappers
{
    public static class PersoonMapper
    {
        public static PersoonDTO ConvertToPersoonDTO(Persoon p)
        {
            return new PersoonDTO(p.Id, $"{p.Voornaam} {p.Achternaam}");
        }
    }
}
