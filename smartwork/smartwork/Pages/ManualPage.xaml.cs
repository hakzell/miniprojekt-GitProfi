using smartwork.ViewModels;
using smartwork.Data.Services;
using smartwork.ViewModels;

namespace smartwork.Pages;

public partial class ManualPage : ContentPage
{
	public ManualPage(ManualViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
    }
}