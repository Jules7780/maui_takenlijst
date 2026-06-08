using TakenlijstApp.Viewmodels;

namespace TakenlijstApp;

public partial class TaakDetailPagina : ContentPage
{
	public TaakDetailPagina(TaakDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}