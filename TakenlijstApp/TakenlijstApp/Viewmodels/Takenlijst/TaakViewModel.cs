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
        private bool _isAanHetInitialiseeren = true;
        public int Id { get; set; }
        private string _titel;
        public string Titel
        {
            get
            {
                return _titel;
            }
            set
            {
                _titel = value;
                NotifyPropertyChanged();
            }
        }

        private string _beschrijving;
        public string Beschrijving
        {
            get
            {
                return _beschrijving;
            }
            set
            {
                _beschrijving = value;
                NotifyPropertyChanged();
            }
        }

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
            _taakService.UpdateIsGedaan(Id, IsGedaan);
        }


    }
}
