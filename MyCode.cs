using System;
using System.Collections.Generic;
using System.Linq;

namespace SP010623
{
    public class MyCode
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            List<int> primes = new List<int>();
            List<int> circular = new List<int>();
            for (int i = 2; i <= 100000; i++)
                numbers.Add(i);
            for (int i = 2; i <= 100000; i++)
                if (numbers.Contains(i))
                {
                    primes.Add(i);
                    for (int j = i; j <= 100000; j+=i)
                        if (numbers.Contains(j))
                            numbers.Remove(j);
                    List<int> digits = new List<int>();
                    int number = i;
                    while (number > 0)
                    {
                        digits.Add(number%10);
                        number = (number - (number % 10)) / 10;
                    }
                    List<int> rots = new List<int>();
                    for (int j = 0; j < digits.Count; j++)
                    {
                        int rotation = 0;
                        for (int d = 0; d < digits.Count; d++)
                        {
                            if (d-j < 0)
                                rotation += digits[digits.Count + d - j] * (int) Math.Pow(10, d);
                            else
                                rotation += digits[d - j] * (int) Math.Pow(10, d);
                        }
                        if (rotation > i || !primes.Contains(rotation))
                            break;
                        else
                            rots.Add(rotation);
                        if (j==digits.Count-1)
                            foreach (int rot in rots)
                            {
                                if (!circular.Contains(rot))
                                    circular.Add(rot);
                            }
                    }
                }
            circular = circular.OrderBy(x => x).ToList();
            /*foreach (var c in circular)
            {
                Console.WriteLine(c);
            }*/
            Console.WriteLine("I am ready.");
            while (true)
                try
                {
                    Console.WriteLine(circular[Int32.Parse(Console.ReadLine())+1]);
                }
                catch (Exception e)
                {
                    Console.WriteLine("You ended the program with an incorrect input.");
                    break;
                }
        }
    }
}