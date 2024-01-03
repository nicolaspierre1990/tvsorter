using System.IO;

namespace TVSorter.Data.TvdbV2;

public class StreamWriter : IStreamWriter
{
    /// <summary>
    /// Writes the stream.
    /// </summary>
    /// <param name="stream">The stream.</param>
    /// <param name="path">The path.</param>
    public void WriteStream(Stream stream, string path)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(path));

        try
        {
            using var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            stream.CopyTo(fileStream);
        }
        catch (IOException)
        {
            Logger.OnLogMessage(this, "Failed to write stream", LogType.Info);
        }
    }
}
