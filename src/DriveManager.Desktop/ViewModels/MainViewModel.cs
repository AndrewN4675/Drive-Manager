namespace DriveManager.Desktop.ViewModels;

using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using ReactiveUI;

public class MainWindowViewModel : ReactiveObject
{
    private object _currentView;
    
    public object CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }

    public MainWindowViewModel()
    {
        // Start with main view
        var mainVM = new MainViewModel();
        mainVM.DriveSelected += OnDriveSelected;
        CurrentView = mainVM;
    }

    private void OnDriveSelected(Models.DriveInfo drive)
    {
        var detailVM = new DriveDetailViewModel(drive);
        detailVM.BackRequested += OnBackRequested;
        CurrentView = detailVM;
    }

    private void OnBackRequested()
    {
        var mainVM = new MainViewModel();
        mainVM.DriveSelected += OnDriveSelected;
        CurrentView = mainVM;
    }
}