using TakenlijstApp.Viewmodels;

namespace TakenlijstApp;

public partial class TakenlijstPagina : ContentPage
{
	public TakenlijstPagina(TakenLijstViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}