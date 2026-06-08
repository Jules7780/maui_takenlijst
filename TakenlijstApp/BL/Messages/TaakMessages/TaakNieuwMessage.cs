using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.TaakMessages
{
    public class TaakNieuwMessage
    {
        public TaakNieuwMessage(Taak nieuwTaak)
        {
            NieuweTaak = nieuwTaak;
        }

        public Taak NieuweTaak { get; init; }
    }
}
