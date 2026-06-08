using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTos
{
    public class PersoonDTO
    {
        public int Id { get; set; }
        public string VolledigeNaam { get; set; }

        public PersoonDTO(int id, string volledigeNaam)
        {
            Id = id;
            VolledigeNaam = volledigeNaam;
        }

        public override string? ToString()
        {
            return VolledigeNaam;
        }
    }
}
