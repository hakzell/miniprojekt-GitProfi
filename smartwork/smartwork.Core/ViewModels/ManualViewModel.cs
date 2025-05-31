using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using smartwork.Core.Messages;
using smartwork.Data.Models;
using smartwork.Data.Services;
using System.Collections.ObjectModel;

namespace smartwork.ViewModels;

public partial class ManualViewModel : ObservableObject
{
    IRepository _repository;

    public ManualViewModel(IRepository repository)
    {
        _repository = repository;
    }

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))] // Sobald was geändert wird, wird SaveCommand aufgerufen, um die Ausführbarkeit zu prüfen
    private DateTime selectedDate = DateTime.Today;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private TimeSpan fromTime = TimeSpan.Zero;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private TimeSpan toTime = TimeSpan.Zero;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
    private string description = string.Empty;

    public ObservableCollection<Project> projects { get; } = new(); 

    public ManualViewModel()
    {
        FromTime = new TimeSpan(8, 0, 0);
        ToTime = new TimeSpan(17, 0, 0);
    }

    [RelayCommand]
    void Save()
    {
        if (ToTime <= FromTime)
        {
            // Hier kannst du Fehlermeldung anzeigen, z.B. mit DisplayAlert oder MessagingCenter
            return;
        }

        Project project = new Project(this.SelectedDate, this.FromTime, this.ToTime, this.Description);

        var result = _repository.Save(project);
        if (result)
        {
            WeakReferenceMessenger.Default.Send(new ProjectSavedMessage(project));

            this.SelectedDate = DateTime.Today;
            this.FromTime = new TimeSpan(8, 0, 0);
            this.ToTime = new TimeSpan(17, 0, 0);
            this.Description = string.Empty;

        }
    }
}