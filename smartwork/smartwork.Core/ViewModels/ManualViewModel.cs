using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using smartwork.Data.Models;

namespace smartwork.ViewModels;

public partial class ManualViewModel : ObservableObject
{
    [ObservableProperty]
    private DateTime selectedDate = DateTime.Today;

    [ObservableProperty]
    private TimeSpan fromTime = TimeSpan.Zero;

    [ObservableProperty]
    private TimeSpan toTime = TimeSpan.Zero;

    [ObservableProperty]
    private string description = string.Empty;

    public ObservableCollection<Project> Entries { get; } = new();

    public ManualViewModel()
    {
        FromTime = new TimeSpan(8, 0, 0);
        ToTime = new TimeSpan(17, 0, 0);
    }

    [RelayCommand]
    private void SaveLocal()
    {
        if (ToTime <= FromTime)
        {
            // Hier kannst du Fehlermeldung anzeigen, z.B. mit DisplayAlert oder MessagingCenter
            return;
        }

        var entry = new Project(SelectedDate, FromTime, ToTime, description);
        Entries.Add(entry);

        // Eingabefelder zurücksetzen (optional)
        SelectedDate = DateTime.Today;
        FromTime = TimeSpan.Zero;
        ToTime = TimeSpan.Zero;
    }
}