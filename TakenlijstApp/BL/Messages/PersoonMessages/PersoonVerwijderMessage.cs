using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.PersoonMessages
{
    public class PersoonVerwijderMessage
    {

        public PersoonVerwijderMessage(Persoon verwijdertPersoon)
        {
            VerwijdertPersoon = verwijdertPersoon;
        }

        public Persoon VerwijdertPersoon { get; init; }
        
    }
}
