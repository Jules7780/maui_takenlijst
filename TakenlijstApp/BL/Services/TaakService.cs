using BL.Interfaces;
using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class TaakService
    {
        private readonly ITaakRepo _repo;

        public Taak HaalMetId(int taakId)
        {
            if (taakId < 0)
            {
                throw new ArgumentException("id moet groter dan 0 zijn");
            }
            return _repo.HaalMetId(taakId);
        }

        public List<Taak> HaalAllePersonen()
        {
            return _repo.HaalAlleTaken();
        }

        public bool Exists(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            return _repo.Exists(t);
        }

        public void Toevoegen(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            _repo.Toevoegen(t);
        }

        public void Update(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            _repo.Update(t);
        }

        public bool Verwijderen(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            if (_repo.Exists(t))
                return _repo.Verwijderen(t);

            return false;
        }

    }
}
