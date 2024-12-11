
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BagageGroep;

public partial class Program
{
    // Helper functie om kluizen uit het bestand te lezen
    public static List<Kluis> GetLockersFromFile()
    {
        var lockers = new List<Kluis>();
        if (!File.Exists(LockerFile)) return lockers;

        var lines = File.ReadAllLines(LockerFile);
        foreach (var line in lines)
        {
            var parts = line.Split(';');
            if (parts.Length == 2)
            {
                lockers.Add(new Kluis { Code = parts[0], Password = parts[1] });
            }
        }
        return lockers;
    }

    // Helper functie om kluizen naar het bestand te schrijven
    public static void SaveLockersToFile(List<Kluis> lockers)
    {
        var lines = lockers.Select(l => $"{l.Code};{l.Password}");
        File.WriteAllLines(LockerFile, lines);
    }
}
