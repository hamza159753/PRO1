
namespace BagageGroep;

partial class Program
{
    public const int TotalLockers = 100;
    public const string LockerFile = "lockers.txt";

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nWelkom bij zwembad de golf!");
            Console.WriteLine("1. Laat het aantal kluizen zien");
            Console.WriteLine("2. Huur een nieuwe kluis");
            Console.WriteLine("3. Open een kluis");
            Console.WriteLine("4. Lever een kluis in");
            Console.WriteLine("5. Afsluiten");

            Console.Write("Kies een optie: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine($"Aantal vrije kluizen: {TotalLockers - GetLockersFromFile().Count}");
                    break;
                case "2":
                    var result = NewLocker();
                    if (result == 0) Console.WriteLine("Kluis succesvol gehuurd.");
                    else if (result == -1) Console.WriteLine("Wachtwoord voldoet niet aan de eisen.");
                    else Console.WriteLine("Er is iets fout gegaan.");
                    break;
                case "3":
                    if (OpenLocker()) Console.WriteLine("Kluis geopend.");
                    else Console.WriteLine("Onjuiste gegevens.");
                    break;
                case "4":
                    if (ReturnLocker()) Console.WriteLine("Kluis succesvol ingeleverd.");
                    else Console.WriteLine("Onjuiste gegevens.");
                    break;
                case "5":
                    Console.WriteLine("Tot ziens!");
                    return;
                default:
                    Console.WriteLine("Ongeldige keuze.");
                    break;
            }
        }
    }
}
