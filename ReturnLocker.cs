
using System;
using System.Linq;

namespace BagageGroep;

public partial class Program
{
    public static bool ReturnLocker()
    {
        var lockers = GetLockersFromFile();
        Console.WriteLine("Voer uw kluisnummer in:");
        var lockerNumber = Console.ReadLine();
        Console.WriteLine("Voer uw wachtwoord in:");
        var password = Console.ReadLine();

        var locker = lockers.FirstOrDefault(l => l.Code == lockerNumber && l.Password == password);
        if (locker != null)
        {
            lockers.Remove(locker);
            SaveLockersToFile(lockers);
            return true;
        }

        return false;
    }
}
