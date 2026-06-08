using BL.Factories;
using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenlijstApp.Viewmodels.Base;

namespace TakenlijstApp.Viewmodels.Takenlijst
{
    public class TaakViewModel : ViewModel
    {
        public TaakViewModel(TaakService taakService, int id, string titel, string beschrijving, bool isGedaan)
        {
            _taakService = taakService;
            _isAanHetInitialiseeren = true;
            Id = id;
            Titel = titel;
            Beschrijving = beschrijving;
            IsGedaan = isGedaan;
            _isAanHetInitialiseeren = false;

        }

        private readonly TaakService _taakService;
        private bool _isAanHetInitialiseeren;
        public int Id { get; set; }
        public string Titel { get; set; }
        public string Beschrijving { get; set; }

        private bool _isGedaan;
        public bool IsGedaan
        {
            get
            {
                return _isGedaan;
            }
            set
            {
                _isGedaan = value;
                NotifyPropertyChanged();
                if(!_isAanHetInitialiseeren)
                {
                    TaakUpdaten();
                }

            }
        }

        private void TaakUpdaten()
        {
            Taak t = _taakService.HaalMetId(Id);
            _taakService.Update(TaakFactory.UpdateTaak(t, t.Titel, t.Beschrijving, _isGedaan, t.PersoonId));
        }


    }
}
