using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interfaces
{
    public interface IPersoonRepo
    {
        public Persoon HaalMetId(int persoonId);


        public List<Persoon> HaalAllePersonen();


        public bool Exists(Persoon p);


        public void Toevoegen(Persoon p);


        public void Update(Persoon p);


        public bool Verwijderen(Persoon p);

    }
}
