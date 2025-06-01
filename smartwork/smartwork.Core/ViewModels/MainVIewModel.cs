using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using smartwork.Core.Messages;
using smartwork.Data.Models;
using smartwork.Data.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace smartwork.ViewModels;

public partial class MainViewModel : ObservableObject
{
    IRepository _repository;

    private bool IsLoaded = false;

    [ObservableProperty]
    public Project? _selectedProject = null;

    [ObservableProperty]
    private bool _showDetails = false;

    public MainViewModel(IRepository repository)
    {
        _repository = repository;

        WeakReferenceMessenger.Default.Register<ProjectSavedMessage>(this, (r, m) =>
        {
            System.Diagnostics.Debug.WriteLine(r);
            System.Diagnostics.Debug.WriteLine(m.Value);

            _projects.Add(m.Value);

           


        });
    }
    [ObservableProperty]
    ObservableCollection<Project> _projects = new ObservableCollection<Project>();

    [RelayCommand]
    void Load()
    {
        if (!this.IsLoaded)
        {
            var projects = _repository.Get();

            foreach (var project in projects)
            {
                System.Diagnostics.Debug.WriteLine(project);
                Projects.Add(project);
            }

            this.IsLoaded = !this.IsLoaded;
        }
    }

    [RelayCommand]
    void Show()
    {
        this._showDetails = _selectedProject != null;
    }

    }