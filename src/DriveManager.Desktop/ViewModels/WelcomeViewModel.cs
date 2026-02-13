using System.Windows.Input;
using Avalonia.Input;

namespace DriveManager.Desktop.ViewModels
{
    public class WelcomeViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public ICommand ContinueCommand { get; }

        public WelcomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            ContinueCommand = new RelayCommand(() => _mainViewModel.NavigateToDriveMenu());
        }
    }
}