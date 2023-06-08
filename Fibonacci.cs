using System;
using System.Collections.Generic;

namespace SP010708
{
    public class Fibonacci
    {
        public static void Main()
        {
            while (true)
            {
                ulong entered;
                try
                {
                    entered = UInt64.Parse(Console.ReadLine());
                    //entered = UInt64.MaxValue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("You exited the program with a bad input.");
                    break;
                }
                /*if (entered < 0)
                {
                    Console.WriteLine("Positive only!");
                    continue;
                }*/
                ulong before = 0, last = 1;
                List<ulong> numbers = new List<ulong>();
                numbers.Add(0);
                numbers.Add(1);
                while (last < entered)
                {
                    ulong sum;
                    try
                    {
                        sum = before + last;
                        if (sum < last) break;
                    }
                    catch (Exception e)
                    {
                        break;
                    }
                    numbers.Add(sum);
                    before = last;
                    last = sum;
                }

                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    if (numbers[i] <= entered)
                    {
                        entered -= numbers[i];
                        Console.Write(numbers[i]); Console.Write(' ');
                        i--;
                        if (entered == 0)
                            break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}