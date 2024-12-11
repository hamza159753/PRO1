
using System;
using System.Linq;
using System.Collections.Generic;

namespace BagageGroep;

public partial class Program
{
    public static int NewLocker()
    {
        var lockers = GetLockersFromFile();
        var usedCodes = lockers.Select(l => l.Code).ToHashSet();

        Console.WriteLine("Beschikbare kluizen:");
        for (int i = 1; i <= TotalLockers; i++)
        {
            if (!usedCodes.Contains(i.ToString()))
            {
                Console.Write($"{i} ");
            }
        }
        Console.WriteLine("\nKies een kluisnummer:");
        if (!int.TryParse(Console.ReadLine(), out int lockerNumber) || lockerNumber < 1 || lockerNumber > TotalLockers || usedCodes.Contains(lockerNumber.ToString()))
        {
            Console.WriteLine("Ongeldig kluisnummer.");
            return 1;
        }

        Console.WriteLine("Voer een wachtwoord in (4-20 karakters, geen ';'):");
        var password = Console.ReadLine();
        if (password.Length < 4 || password.Length > 20 || password.Contains(";"))
        {
            Console.WriteLine("Wachtwoord voldoet niet aan de eisen.");
            return -1;
        }

        lockers.Add(new Kluis { Code = lockerNumber.ToString(), Password = password });
        SaveLockersToFile(lockers);
        return 0;
    }
}
