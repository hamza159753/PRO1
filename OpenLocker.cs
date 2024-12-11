
using System;
using System.Linq;

namespace BagageGroep;

public partial class Program
{
    public static bool OpenLocker()
    {
        var lockers = GetLockersFromFile();
        Console.WriteLine("Voer uw kluisnummer in:");
        var lockerNumber = Console.ReadLine();
        Console.WriteLine("Voer uw wachtwoord in:");
        var password = Console.ReadLine();

        return lockers.Any(l => l.Code == lockerNumber && l.Password == password);
    }
}
