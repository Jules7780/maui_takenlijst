using BL.DTos;
using BL.Factories;
using BL.Mappers;
using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TakenlijstApp.Services;
using TakenlijstApp.Viewmodels.Base;

namespace TakenlijstApp.Viewmodels
{
    public class TaakDetailViewModel : ViewModel, IQueryAttributable
    {
        private readonly PersoonService _persoonService;
        private readonly NavigatieService _navigatieService;
        private readonly TaakService _taakService;

        private Taak? _taak;

        public TaakDetailViewModel(PersoonService service, NavigatieService navigatieService, TaakService taakService)
        {
            _persoonService = service;
            _navigatieService = navigatieService;
            _taakService = taakService;
            AnnulerenCommand = new Command(async () => await Annuleren());
            BewarenCommand = new Command(async () => await Bewaren());

            Personen = _persoonService.HaalAllePersonen().Select(p => PersoonMapper.ConvertToPersoonDTO(p)).ToList();


        }
        private int? _id;
        public int? Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyPropertyChanged();
            }
        }

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

        private PersoonDTO _assigneerdePersoon;
        public PersoonDTO AssigneerdePersoon
        {
            get
            {
                return _assigneerdePersoon;
            }
            set
            {
                _assigneerdePersoon = value;
                NotifyPropertyChanged();
            }
        }

        private List<PersoonDTO> _personen;
        public List<PersoonDTO> Personen
        {
            get
            {
                return _personen;
            }
            set
            {
                _personen = value;
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
            }
        }

        public ICommand AnnulerenCommand { get; init; }
        public ICommand BewarenCommand { get; init; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("taakId", out var oTaakId) && oTaakId is int taakId)
            {
                Taak t = _taakService.HaalMetId(taakId);
                _taak = t;
                Id = t.Id;
                Titel = t.Titel;
                Beschrijving = t.Beschrijving;
                AssigneerdePersoon = PersoonMapper.ConvertToPersoonDTO(_persoonService.HaalMetId(t.PersoonId));
                IsGedaan = t.Afgewerkt;

            }
        }

        private async Task Annuleren()
        {
            _navigatieService.GoBackAsync();
        }
        private async Task Bewaren()
        {
            List<string> foutmeldingen = new List<string>();
            
            if (String.IsNullOrEmpty(Titel))
            {
                foutmeldingen.Add("Titel is verplicht");
            }

            if(AssigneerdePersoon == null)
            {
                foutmeldingen.Add("Een persoon kiezen is verplicht");
            }



            if (foutmeldingen.Count > 0)
            {
                await Application.Current.MainPage.DisplayAlert("Velden niet OK", String.Join(';', foutmeldingen), "OK");
                return;
            }




            if (_taak == null)
            {
                _taakService.Toevoegen(TaakFactory.MaakNieuweTaak(Titel, Beschrijving, IsGedaan, AssigneerdePersoon.Id));
            }
            else
            {
                _taakService.Update(TaakFactory.UpdateTaak(_taak, Titel, Beschrijving, IsGedaan, AssigneerdePersoon.Id));
            }

            _navigatieService.GoBackAsync();
        }

    }
}
