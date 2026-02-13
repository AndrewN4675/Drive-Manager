using System;
using System.Collections.Generic;
using System.Windows.Input;
using DriveManager.Desktop.ViewModels;

namespace DriveManager.Desktop.Views
{
    public class DriveItem
    {
        public string Name { get; set; } = "";
        public double Weight { get; set; }
    }

    public class ChartSegment
    {
        public string Label { get; set; } = "";
        public string Color { get; set; } = "";
    }

    public class DriveViewModel
    {
        private readonly MainViewModel _mainViewModel;

        public List<DriveItem> Items { get; }
        public List<ChartSegment> ChartSegments { get; }
        public ICommand SelectItemCommand { get; }

        public DriveViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            Items = GenerateItems();
            ChartSegments = GenerateChartData();
            SelectItemCommand = new RelayCommand<string>(itemName => 
            {
                if (itemName != null)
                    _mainViewModel.NavigateToDetail(itemName);
            });
        }

        private List<DriveItem> GenerateItems()
        {
            var random = new Random();
            return new List<DriveItem>
            {
                new DriveItem { Name = "C: System Drive", Weight = random.NextDouble() * 100 },
                new DriveItem { Name = "D: Data Drive", Weight = random.NextDouble() * 100 },
                new DriveItem { Name = "E: External Drive", Weight = random.NextDouble() * 100 },
                new DriveItem { Name = "F: Backup Drive", Weight = random.NextDouble() * 100 },
                new DriveItem { Name = "G: Media Drive", Weight = random.NextDouble() * 100 }
            };
        }

        private List<ChartSegment> GenerateChartData()
        {
            return new List<ChartSegment>
            {
                new ChartSegment { Label = "Documents", Color = "#FF6B6B" },
                new ChartSegment { Label = "Media", Color = "#4ECDC4" },
                new ChartSegment { Label = "System", Color = "#45B7D1" },
                new ChartSegment { Label = "Other", Color = "#FFA07A" }
            };
        }
    }
}
