using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace DriveManager.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MyButton.Click += OnButtonClick;
    }
    
    private void OnButtonClick(object? sender, RoutedEventArgs e)
    {
        StatusText.Text = "Clicked at " + DateTime.Now.ToLongTimeString();
    }
}