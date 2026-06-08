using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakenlijstApp.Viewmodels.Base;

namespace TakenlijstApp.Viewmodels.PersonenLijst
{
    public class PersoonViewModel : ViewModel
    {
        public PersoonViewModel(int id, string voornaam, string achternaam, int leeftijd)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Leeftijd = leeftijd;
        }

        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public int Leeftijd {  get; set; }

    }
}
