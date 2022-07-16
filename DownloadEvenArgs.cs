 
public class DownloadEvenArgs : EventArgs
{
    public int NumberOfSurah { get; init; }

    public string PathOfUploadedFile { get; init; }

    public string EndTime { get; init; }

 
    public DownloadEvenArgs(int number)
    {
        NumberOfSurah = number;
    }

    public DownloadEvenArgs(int number, string path, string endtime)
    {
        NumberOfSurah = number;
        PathOfUploadedFile = path;
        EndTime = endtime;
    }

}