using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.PersoonMessages
{
    public class PersoonNieuwMessage
    {
        public PersoonNieuwMessage(Persoon nieuwPersoon)
        {
            NieuwPersoon = nieuwPersoon;
        }

        public Persoon NieuwPersoon { get; init; }
    }
}
