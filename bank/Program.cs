using System.Runtime.InteropServices;

namespace bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Tworzenie konta
            KontoBankowe kontoBankowe = new KontoBankowe();

            // Tworzenie automatu do wpłat
            Automat automat = new Automat();

            automat.WrzucMonete(kontoBankowe, "0.5");

            automat.WrzucMonete(kontoBankowe, "2");
            automat.WrzucMonete(kontoBankowe, "0.50");
            automat.WrzucMonete(kontoBankowe, "5");
            automat.WrzucMonete(kontoBankowe, "0.1");
            automat.WrzucMonete(kontoBankowe, "3");    // zły nominał
            automat.WrzucMonete(kontoBankowe, "abc");  // nieczytelny odczyt

            Console.WriteLine();
            Console.WriteLine($"Stan konta: {kontoBankowe.StanKonta():0.00}");
            Console.WriteLine($"Numer konta: {kontoBankowe._numer}");
            automat.PokazMonety();

            // Drugie konto - numer musi być inny
            KontoBankowe konto2 = new KontoBankowe();
            Console.WriteLine();
            Console.WriteLine($"Numer drugiego konta: {konto2._numer}");
            Console.WriteLine(kontoBankowe._numer != konto2._numer
                ? "Numery kont są różne."
                : "BŁĄD: numery kont są takie same!");
            // Wyświetlamy stan konta (jeszcze nie zrobione)
            //Console.WriteLine(kontoBankowe.StanKonta());

        }
    }
}
