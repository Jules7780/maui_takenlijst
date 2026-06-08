using BL.Messages.PersoonMessages;
using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TakenlijstApp.Services;
using TakenlijstApp.Viewmodels.Base;
using TakenlijstApp.Viewmodels.PersonenLijst;

namespace TakenlijstApp.Viewmodels
{
    public class PersonenLijstViewModel : ViewModel
    {
        

        public PersonenLijstViewModel(PersoonService service, NavigatieService navigatieService, MessageService messageService)
        {
            NieuwPersoonCommand = new Command(() => NieuwPersoon());
            _navigatieService = navigatieService;

            Personen = new ObservableCollection<PersoonViewModel>(service.HaalAllePersonen().Select(ConvertToViewModel));

            messageService.Register<PersoonUpdatedMessage>(this, (sender, message) =>
            {
                var persoonVM = Personen.FirstOrDefault(p => p.Id == message.UpdatedPersoon.Id);

                if (persoonVM != null)
                {
                    Personen.Remove( persoonVM );
                    Personen.Add(ConvertToViewModel(message.UpdatedPersoon));
                }
            });

            messageService.Register<PersoonNieuwMessage>(this, (sender, message) =>
            {
                    Personen.Add(ConvertToViewModel(message.NieuwPersoon));

            });

            messageService.Register<PersoonVerwijderMessage>(this, (sender, message) =>
            {
                var persoonVM = Personen.FirstOrDefault(p => p.Id == message.VerwijdertPersoon.Id);

                if (persoonVM != null)
                {
                    Personen.Remove(persoonVM);
                }
            });
        }

        private readonly NavigatieService _navigatieService;

        private ObservableCollection<PersoonViewModel> _personen;
        public ObservableCollection<PersoonViewModel> Personen
        {
            get { return _personen; }
            set
            {
                _personen = value;
                NotifyPropertyChanged();
            }
        }

        private PersoonViewModel? _geselecteerdePersoon;
        public PersoonViewModel? GeselecteerdePersoon
        {
            get => _geselecteerdePersoon;
            set
            {
                _geselecteerdePersoon = value;
                VeranderingGeselecteerdePersoon(value);
            }
        }

        public ICommand NieuwPersoonCommand { get; init; }

        private async Task NieuwPersoon()
        {
            await _navigatieService.GoToAsync(nameof(PersoonDetailPagina));
        }

        private PersoonViewModel ConvertToViewModel(Persoon p)
        {
            int leeftijd = DateTime.Now.Year - p.Geboortedatum.Year;
            
            
            return new PersoonViewModel(p.Id, p.Voornaam, p.Achternaam, leeftijd);
        }

        private async Task VeranderingGeselecteerdePersoon(PersoonViewModel? p)
        {
            if (p is null)
                return;

            var parameters = new Dictionary<string, object>
            {
                ["persoonId"] = p.Id
            };

            await _navigatieService.GoToAsync(nameof(PersoonDetailPagina), parameters);
        }
    }
}
