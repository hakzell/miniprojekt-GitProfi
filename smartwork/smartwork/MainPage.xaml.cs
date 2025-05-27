using smartwork.Core.ViewModels;

namespace smartwork
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.BindingContext = mainViewModel;
        }

        
    }

}
