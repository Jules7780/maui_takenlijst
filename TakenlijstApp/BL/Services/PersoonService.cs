using BL.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class PersoonService
    {
        private readonly IPersoonRepo _repo;

        public PersoonService(IPersoonRepo repo)
        {
            _repo = repo;
        }

        public Persoon HaalMetId(int persoonId)
        {
            if (persoonId < 0)
            {
                throw new ArgumentException("id moet groter dan 0 zijn");
            }
            return _repo.HaalMetId(persoonId);
        }

        public List<Persoon> HaalAllePersonen()
        {
            return _repo.HaalAllePersonen();
        }

        public bool Exists(Persoon p)
        {
            ArgumentNullException.ThrowIfNull(p);
            return _repo.Exists(p);
        }

        public void Toevoegen(Persoon p)
        {
            ArgumentNullException.ThrowIfNull(p);
            _repo.Toevoegen(p);
        }

        public void Update(Persoon p)
        {
            ArgumentNullException.ThrowIfNull(p);
            _repo.Update(p);
        }

        public bool Verwijderen(Persoon p)
        {
            ArgumentNullException.ThrowIfNull(p);
            if (_repo.Exists(p))
                return _repo.Verwijderen(p);

            return false;
        }
    }
}
