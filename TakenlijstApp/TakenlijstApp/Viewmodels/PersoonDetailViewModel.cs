using BL.Factories;
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
    public class PersoonDetailViewModel : ViewModel, IQueryAttributable
    {
        private readonly PersoonService _service;
        private readonly NavigatieService _navigatieService;

        private Persoon? _persoon;

        public PersoonDetailViewModel(PersoonService service, NavigatieService navigatieService)
        {
            _service = service;
            _navigatieService = navigatieService;
            AnnulerenCommand = new Command(async () => await Annuleren());
            BewarenCommand = new Command(async () => await Bewaren());
            VerwijderCommand = new Command(async () => await Verwijder());


        }
        private int _id;
        public int Id
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

        private string _url;
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
                NotifyPropertyChanged();
            }
        }

        private string _voornaam;
        public string Voornaam
        {
            get
            {
                return _voornaam;
            }
            set
            {
                _voornaam = value;
                NotifyPropertyChanged();
            }
        }

        private string _achternaam;
        public string Achternaam
        {
            get
            {
                return _achternaam;
            }
            set
            {
                _achternaam = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _geboortedatum;
        public DateTime Geboortedatum
        {
            get
            {
                return _geboortedatum;
            }
            set
            {
                _geboortedatum = value;
                NotifyPropertyChanged();
            }
        }

        public Persoon persoon { get; set; }

        public ICommand AnnulerenCommand {  get; init; }
        public ICommand BewarenCommand { get; init; }
        public ICommand VerwijderCommand { get; init; }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("persoonId", out var oPersoonId) && oPersoonId is int persoonId)
            {
                Persoon p = _service.HaalMetId(persoonId);
                _persoon = p;
                Id = p.Id;
                Url = p.Url;
                Voornaam = p.Voornaam;
                Achternaam = p.Achternaam;
                Geboortedatum = p.Geboortedatum;

            }
        }

        private async Task Annuleren()
        {
            _navigatieService.GoBackAsync();
        }
        private async Task Bewaren()
        {
            //velden checken
            
            if (_persoon == null)
            {
                _service.Toevoegen(PersoonFactory.MaakNieuwePersoon(Url, Voornaam, Achternaam, Geboortedatum));
            } else
            {
                _service.Update(PersoonFactory.UpdatePersoon(_persoon, Url, Voornaam, Achternaam, Geboortedatum));
            }

            _navigatieService.GoBackAsync();
        }

        private async Task Verwijder()
        {
            if(_persoon != null)
            {
                _service.Verwijderen(_persoon);
            }

            _navigatieService.GoBackAsync();
        }
    }
}
