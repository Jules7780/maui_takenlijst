using BL.Messages.PersoonMessages;
using BL.Messages.TaakMessages;
using BL.Models;
using BL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TakenlijstApp.Services;
using TakenlijstApp.Viewmodels.Base;
using TakenlijstApp.Viewmodels.Takenlijst;

namespace TakenlijstApp.Viewmodels
{
    public class TakenLijstViewModel : ViewModel
    {
        public TakenLijstViewModel(TaakService taakService, NavigatieService navigatieService, MessageService messageService)
        {
            NieuwTaakCommand = new Command(() => NieuwTaak());
            PersonenCommand = new Command(() => GaNaarPersonen());

            
            _navigatieService = navigatieService;
            _taakService = taakService;

            Taken = new ObservableCollection<TaakViewModel>(taakService.HaalAlleTaken().Select(ConvertToViewModel));

            messageService.Register<TaakUpdatedMessage>(this, (sender, message) =>
            {
                var taakVM = Taken.FirstOrDefault(t => t.Id == message.UpdatedTaak.Id);


                if (taakVM != null)
                {
                    taakVM.Titel = message.UpdatedTaak.Titel;
                    taakVM.Beschrijving = message.UpdatedTaak.Beschrijving;
                    taakVM.IsGedaan = message.UpdatedTaak.Afgewerkt;
                }
            });

            messageService.Register<TaakNieuwMessage>(this, (sender, message) =>
            {
                Taken.Add(ConvertToViewModel(message.NieuweTaak));

            });

            messageService.Register<TaakVerwijderMessage>(this, (sender, message) =>
            {
                var taakVM = Taken.FirstOrDefault(t => t.Id == message.VerwijdertTaak.Id);

                if (taakVM != null)
                {
                    Taken.Remove(taakVM);
                }
            });
        }

        private readonly NavigatieService _navigatieService;
        private readonly TaakService _taakService;

        private ObservableCollection<TaakViewModel> _taken;
        public ObservableCollection<TaakViewModel> Taken
        {
            get { return _taken; }
            set
            {
                _taken = value;
                NotifyPropertyChanged();
            }
        }

        private TaakViewModel? _geselecteerdeTaak;
        public TaakViewModel? GeselecteerdeTaak
        {
            get => _geselecteerdeTaak;
            set
            {
                _geselecteerdeTaak = value;
                VeranderingGeselecteerdeTaak(value);
            }
        }

        public ICommand NieuwTaakCommand { get; init; }
        public ICommand PersonenCommand { get; init; }

        private async Task NieuwTaak()
        {
            await _navigatieService.GoToAsync(nameof(TaakDetailPagina));
        }

        private async Task GaNaarPersonen()
        {
            await _navigatieService.GoToAsync(nameof(PersonenLijstPagina));
        }

        private TaakViewModel ConvertToViewModel(Taak t)
        {
            return new TaakViewModel(_taakService, t.Id, t.Titel, t.Beschrijving, t.Afgewerkt);
        }

        private async Task VeranderingGeselecteerdeTaak(TaakViewModel? t)
        {
            if (t is null)
                return;

            var parameters = new Dictionary<string, object>
            {
                ["taakId"] = t.Id
            };

            await _navigatieService.GoToAsync(nameof(TaakDetailPagina), parameters);
        }
    }
}
