public class Program
{
    public static void Main(string[] args)
    {
 
        Console.BackgroundColor = ConsoleColor.DarkGray;

        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine($" \n\n\t\t\t       ☪️  Assalamu alekum  ☪️       ");
        Console.WriteLine($" \t \t \t Quron 📖 Downloaderga xush kelibsiz  🙂 ");

       
        bool during = true;               
        while (during)
        {
            Console.WriteLine($" \n 🛒  Qaysi surani yuklamoqchisiz, tartib raqamini kiriting :");
            try
            {
                var numberOfSurah = int.Parse(Console.ReadLine());

                if(numberOfSurah < 1 || numberOfSurah > 114)
                {
                    throw new ArgumentOutOfRangeException();
                }

                QuranDownloader qd = new QuranDownloader();

                qd.OnDownload += OndownloadHandle;
                qd.EndDownload += EndDownloadHandle;

                qd.Download(numberOfSurah);

            }
            catch (Exception)
            {
                cach:
                Console.WriteLine($"siz xato kiritmadingiz");
                goto key;
            }


        key:
            Console.WriteLine($"Davom Etasizmi (raqamni tanlang) :");
            Console.WriteLine($"1 : 'ha' ,    2 : 'yoq'");

            during = int.Parse(Console.ReadLine()) == 1 ? true : false;

        }

        Console.WriteLine($" Salomat bo'ling 👋");
        Console.ReadLine();


        // == here methods for event
        void OndownloadHandle(object sender, DownloadEvenArgs e)
        {
            Console.WriteLine($"\n {e.NumberOfSurah} raqamli surani yuklash boshlandi \n");
        }

        void EndDownloadHandle(object sender, DownloadEvenArgs e)
        {
            Console.WriteLine($"\n {e.NumberOfSurah} raqamli surani yuklash {e.EndTime}da  yakunlandi, ");
            Console.WriteLine($"sura quyidagi papkada joylashgan");
            Console.WriteLine($"{e.PathOfUploadedFile} \n");

        }
    }
 
}
 

 


 