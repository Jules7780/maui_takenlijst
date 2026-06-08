using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.PersoonMessages
{
    public class PersoonUpdatedMessage
    {
        public PersoonUpdatedMessage(Persoon updatedPersoon)
        {
            UpdatedPersoon = updatedPersoon;
        }

        public Persoon UpdatedPersoon { get; init; }
    }
}
