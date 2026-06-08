using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.TaakMessages
{
    public class TaakVerwijderMessage
    {
        public TaakVerwijderMessage(Taak verwijdertTaak)
        {
            VerwijdertTaak = verwijdertTaak;
        }

        public Taak VerwijdertTaak { get; init; }
    }
}
