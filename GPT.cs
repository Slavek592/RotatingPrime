using System;
using System.Collections.Generic;

class Program
{
    static void GPTMain()
    {
        int start = 1; // Počáteční hodnota rozsahu
        int end = 1000; // Koncová hodnota rozsahu
        int seek = Int32.Parse(Console.ReadLine());

        //Console.WriteLine("Rotační prvočísla v rozsahu {0} - {1}:", start, end);
        Console.WriteLine(FindCircularPrimes(start, end)[seek-1]); // Hledání rotačních prvočísel v daném rozsahu

        //Console.ReadLine();
    }

    static List<int> FindCircularPrimes(int start, int end)
    {
        List<int> primes = new List<int>();
        for (int number = start; number <= end; number++)
        {
            if (IsPrime(number) && IsCircularPrime(number))
            {
                //Console.WriteLine(number); // Výpis rotačního prvočísla
                primes.Add(number);
            }
        }

        return primes;
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false; // Čísla menší než 2 nejsou prvočísla

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false; // Číslo je dělitelné beze zbytku, není prvočíslo
        }

        return true; // Číslo je prvočíslo
    }

    static bool IsCircularPrime(int number)
    {
        string numberString = number.ToString(); // Převod čísla na řetězcovou reprezentaci

        for (int i = 0; i < numberString.Length; i++)
        {
            string rotatedNumberString = RotateNumberString(numberString, i); // Rotace číslice v řetězci
            int rotatedNumber = int.Parse(rotatedNumberString); // Převod rotovaného řetězce zpět na číslo

            if (!IsPrime(rotatedNumber))
                return false; // Rotované číslo není prvočíslo, není rotačním prvočíslem
        }

        return true; // Všechny rotace jsou prvočísla, je to rotační prvočíslo
    }

    static string RotateNumberString(string numberString, int rotations)
    {
        rotations = rotations % numberString.Length; // Výpočet počtu rotací modulo délka řetězce
        string rotatedString = numberString.Substring(rotations) + numberString.Substring(0, rotations); // Rotace řetězce
        return rotatedString; // Vrácení rotovaného řetězce
    }
}