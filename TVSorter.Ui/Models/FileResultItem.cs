using ReactiveUI;
using TVSorter.Model;

namespace TVSorter.Ui.Models;

public class FileResultItem(FileResult fileResult, string destinationPath) : ReactiveObject
{
    private FileResult _fileResult = fileResult;
    private bool _isChecked = fileResult.Checked;
    private string _inputFileName = fileResult.InputFile.FullName;
    private string? _showName = fileResult.Show?.Name ?? fileResult.ShowName;
    private string? _episodeName = fileResult.Episode?.Name ?? string.Empty;
    private int? _season = fileResult.Episode?.SeasonNumber;
    private int? _episode = fileResult.Episode?.EpisodeNumber;
    private string? _destinationPath = destinationPath;

    public FileResult FileResult
    {
        get => _fileResult;
        set => this.RaiseAndSetIfChanged(ref _fileResult, value);
    }

    public string InputFileName
    {
        get => _inputFileName;
        set => this.RaiseAndSetIfChanged(ref _inputFileName, value);
    }

    public string? ShowName
    {
        get => _showName;
        set => this.RaiseAndSetIfChanged(ref _showName, value);
    }

    public string? EpisodeName
    {
        get => _episodeName;
        set => this.RaiseAndSetIfChanged(ref _episodeName, value);
    }

    public int? Season
    {
        get => _season;
        set => this.RaiseAndSetIfChanged(ref _season, value);
    }

    public int? Episode
    {
        get => _episode;
        set => this.RaiseAndSetIfChanged(ref _episode, value);
    }

    public string? DestinationPath
    {
        get => _destinationPath;
        set => this.RaiseAndSetIfChanged(ref _destinationPath, value);
    }

    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            FileResult.Checked = value;
            this.RaiseAndSetIfChanged(ref _isChecked, value);
        }
    }

    /// <summary>
    /// Call this after mutating properties on the underlying <see cref="FileResult"/> instance
    /// to push change notifications for all derived properties.
    /// </summary>
    public void Refresh()
    {
        ShowName = FileResult.Show?.Name ?? FileResult.ShowName;
        EpisodeName = FileResult.Episode?.Name ?? string.Empty;
        Season = FileResult.Episode?.SeasonNumber;
        Episode = FileResult.Episode?.EpisodeNumber;
    }
}