using TakenlijstApp.Viewmodels;

namespace TakenlijstApp;

public partial class PersoonDetailPagina : ContentPage
{
	public PersoonDetailPagina(PersoonDetailViewModel vm)
	{
        InitializeComponent();
		BindingContext = vm;
	}
}