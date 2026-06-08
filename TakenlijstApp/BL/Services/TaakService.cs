using BL.Interfaces;
using BL.Messages.PersoonMessages;
using BL.Messages.TaakMessages;
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
        private readonly MessageService _messageService;

        public TaakService(ITaakRepo repo, MessageService messageService)
        {
            _repo = repo;
            _messageService = messageService;
        }

        public Taak HaalMetId(int taakId)
        {
            if (taakId < 0)
            {
                throw new ArgumentException("id moet groter dan 0 zijn");
            }
            return _repo.HaalMetId(taakId);
        }

        public List<Taak> HaalAlleTaken()
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
            _messageService.Send(new TaakNieuwMessage(t));
        }

        public void Update(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            _repo.Update(t);
            _messageService.Send(new TaakUpdatedMessage(t));
        }

        public void UpdateIsGedaan(int taakId, bool IsGedaan)
        {
            Taak t = HaalMetId(taakId);
            t.Afgewerkt = IsGedaan;
            t.GewijzigdDatum = DateTime.Now;
            _repo.Update(t);
        }

        public bool Verwijderen(Taak t)
        {
            ArgumentNullException.ThrowIfNull(t);
            if (_repo.Exists(t))
            {
                _messageService.Send(new TaakVerwijderMessage(t));
                return _repo.Verwijderen(t);
            }

            return false;
        }

    }
}
