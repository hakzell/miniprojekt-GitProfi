using smartwork.Core.ViewModels;

namespace smartwork.Pages;

public partial class ExportPage : ContentPage
{
	public ExportPage()
	{
		InitializeComponent();
        BindingContext = new ExportViewModel();
    }
}