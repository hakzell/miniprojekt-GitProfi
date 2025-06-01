namespace smartwork
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF1cWWhOYVJpR2Nbek5zflZBallQVBYiSV9jS3tTcEViWHpdeXBSR2VeU090Vg==");
            MainPage = new AppShell();
        }
    }
}
