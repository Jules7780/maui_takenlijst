using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Messages.TaakMessages
{
    public class TaakUpdatedMessage
    {
        public TaakUpdatedMessage(Taak updatedTaak)
        {
            UpdatedTaak = updatedTaak;
        }

        public Taak UpdatedTaak { get; init; }
    }
}
