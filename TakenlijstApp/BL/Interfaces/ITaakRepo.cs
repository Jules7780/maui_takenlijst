using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface ITaakRepo
    {
        public Taak HaalMetId(int taakId);

        public List<Taak> HaalAlleTaken();


        public bool Exists(Taak t);


        public void Toevoegen(Taak t);


        public void Update(Taak t);


        public bool Verwijderen(Taak t);


    }
}
