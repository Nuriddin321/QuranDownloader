using System.Diagnostics;
using System.Net;


public class QuranDownloader
{
    Stopwatch stopwatch = new Stopwatch();
    public event EventHandler<DownloadEvenArgs> OnDownload;
    public event EventHandler<DownloadEvenArgs> EndDownload;
    private string _pathOfdownload = "https://server7.mp3quran.net/s_gmd/";

    // mywebClient.DownloadFile("https://server7.mp3quran.net/s_gmd/001.mp3", "`1.mp3");

    public async Task Download(int numberOfSurah)
    {
        stopwatch.Start();
        OnDownload?.Invoke(this, new DownloadEvenArgs(numberOfSurah));

        await Task.Delay(2000);
        if (numberOfSurah < 10)
        {
            _pathOfdownload += "00" + numberOfSurah.ToString() + ".mp3";
        }
        else if (numberOfSurah >= 10 && numberOfSurah < 100)
        {
            _pathOfdownload += "0" + numberOfSurah.ToString() + ".mp3";
        }
        else
        {
            _pathOfdownload += numberOfSurah.ToString() + ".mp3";
        }

        string filePath = numberOfSurah.ToString() + ".mp3";
 
        WebClient mywebClient = new WebClient();
        mywebClient.DownloadFile(_pathOfdownload, filePath);

        string file = System.IO.Path.GetFullPath(filePath);

        EndDownload?.Invoke(this, new DownloadEvenArgs(numberOfSurah, file, $"{stopwatch.ElapsedMilliseconds:F0} ms"));
 
    }
 
}
