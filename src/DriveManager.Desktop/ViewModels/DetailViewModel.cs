using System;
using System.Windows.Input;
using DriveManager.Desktop.ViewModels;

namespace DriveManager.Desktop.Views
{
    public class DetailViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public string Title { get; }
        public string Info1 { get; }
        public string Info2 { get; }
        public string Info3 { get; }
        public string Stat1 { get; }
        public string Stat2 { get; }
        public string Stat3 { get; }
        
        public ICommand BackCommand { get; }

        public DetailViewModel(MainViewModel mainViewModel, string itemName)
        {
            _mainViewModel = mainViewModel;
            Title = $"Details for {itemName}";
            
            var random = new Random();
            Info1 = $"Type: {(random.Next(2) == 0 ? "SSD" : "HDD")}";
            Info2 = $"Capacity: {random.Next(100, 2000)} GB";
            Info3 = $"File System: {(random.Next(2) == 0 ? "NTFS" : "exFAT")}";
            
            Stat1 = $"Used Space: {random.Next(20, 80)}%";
            Stat2 = $"Files: {random.Next(1000, 50000):N0}";
            Stat3 = $"Last Accessed: {DateTime.Now.AddDays(-random.Next(1, 30)):d}";
            
            BackCommand = new RelayCommand(() => _mainViewModel.NavigateToDriveMenu());
        }
    }
}