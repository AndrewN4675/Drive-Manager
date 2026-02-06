namespace DriveManager.Desktop.Models;

public class DriveInfo
{
    public string Name { get; set; }
    public string Label { get; set; }
    public long TotalSize { get; set; }
    public long UsedSpace { get; set; }
    public long FreeSpace { get; set; }
    
    public string FormattedTotal => FormatBytes(TotalSize);
    public string FormattedUsed => FormatBytes(UsedSpace);
    public string FormattedFree => FormatBytes(FreeSpace);
    
    public static string FormatBytes(long bytes)
    {
        string[] sizes = { "B", "KB", "MB", "GB", "TB" };
        double len = bytes;
        int order = 0;
        while (len >= 1024 && order < sizes.Length - 1)
        {
            order++;
            len = len / 1024;
        }
        return $"{len:0.##} {sizes[order]}";
    }
}

public class FolderInfo
{
    public string Name { get; set; }
    public long Size { get; set; }
    public string FormattedSize => DriveInfo.FormatBytes(Size);
}