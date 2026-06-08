using TakenlijstApp.Viewmodels;

namespace TakenlijstApp;

public partial class PersonenLijstPagina : ContentPage
{
	public PersonenLijstPagina(PersonenLijstViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}