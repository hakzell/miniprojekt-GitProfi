using smartwork.Core.ViewModels;

namespace smartwork.Pages;

public partial class ManualPage : ContentPage
{
	public ManualPage()
	{
		InitializeComponent();
		BindingContext = new ManualViewModel();
	}
}