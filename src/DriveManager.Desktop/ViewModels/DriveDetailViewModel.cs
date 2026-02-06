namespace DriveManager.Desktop.ViewModels;

using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using ReactiveUI;

public class DriveDetailViewModel : ReactiveObject
{
    private Models.DriveInfo _selectedDrive;
    private ObservableCollection<FolderInfo> _folders;
    
    public Models.DriveInfo SelectedDrive
    {
        get => _selectedDrive;
        set => this.RaiseAndSetIfChanged(ref _selectedDrive, value);
    }
    
    public ObservableCollection<FolderInfo> Folders
    {
        get => _folders;
        set => this.RaiseAndSetIfChanged(ref _folders, value);
    }

    public DriveDetailViewModel(Models.DriveInfo drive)
    {
        SelectedDrive = drive;
        LoadFolders();
    }

    private void LoadFolders()
    {
        try
        {
            var dirInfo = new DirectoryInfo(SelectedDrive.Name);
            var folders = dirInfo.GetDirectories()
                .Select(d => new FolderInfo
                {
                    Name = d.Name,
                    Size = GetDirectorySize(d)
                })
                .OrderByDescending(f => f.Size)
                .ToList();
            
            Folders = new ObservableCollection<FolderInfo>(folders);
        }
        catch
        {
            Folders = new ObservableCollection<FolderInfo>();
        }
    }

    private long GetDirectorySize(DirectoryInfo dir)
    {
        try
        {
            return dir.GetFiles("*", SearchOption.AllDirectories).Sum(f => f.Length);
        }
        catch
        {
            return 0;
        }
    }
}