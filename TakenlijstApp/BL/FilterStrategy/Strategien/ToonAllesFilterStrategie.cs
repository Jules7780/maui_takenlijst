using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.FilterStrategy.Strategien
{
    public class ToonAllesFilterStrategie : IFilterStrategie
    {
        public List<Taak> Filter(List<Taak> taken)
        {
            return taken;
        }
    }
}
