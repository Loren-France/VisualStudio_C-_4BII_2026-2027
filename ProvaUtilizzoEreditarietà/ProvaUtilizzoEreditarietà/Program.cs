namespace ProvaUtilizzoEreditarietà
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CAudio mioAudio = new CAudio();
            CVideo mioVideo = new CVideo();
            CImmagine miaImmagine = new CImmagine();

            Console.WriteLine("Audio");
            Console.WriteLine("Estensione: " + mioAudio.Estensione);
            Console.WriteLine("Dimensione: " + mioAudio.Dimensione);
            Console.WriteLine("Volume: " + mioAudio.Volume);
            Console.WriteLine(mioAudio.Riproduci());

            Console.WriteLine("\nVideo");
            Console.WriteLine("Estensione: " + mioVideo.Estensione);
            Console.WriteLine("Dimensione: " + mioVideo.Dimensione);
            Console.WriteLine("Durata: " + mioVideo.Durata);
            Console.WriteLine(mioVideo.Visualizza());

            Console.WriteLine("\nImmagine");
            Console.WriteLine("Estensione: " + miaImmagine.Estensione);
            Console.WriteLine("Dimensione: " + miaImmagine.Dimensione);
            Console.WriteLine("Pixel: " + miaImmagine.Pixel);
            Console.WriteLine(miaImmagine.FiltraBiancoNero());

        }
    }
}
