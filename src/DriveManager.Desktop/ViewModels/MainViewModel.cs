using System.ComponentModel;
using System.Runtime.CompilerServices;
using DriveManager.Desktop.Views;

namespace DriveManager.Desktop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object? _currentView;

        public object? CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            CurrentView = new WelcomeView { DataContext = new WelcomeViewModel(this) };
        }

        public void NavigateToDriveMenu()
        {
            CurrentView = new DriveView { DataContext = new DriveViewModel(this) };
        }

        public void NavigateToDetail(string itemName)
        {
            CurrentView = new DetailView { DataContext = new DetailViewModel(this, itemName) };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}