using System;
using System.Linq;

namespace SP080723
{
    public class Morse
    {
        public static void Main()
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine(Count(input));
            }
        }

        private static int Count(string data)
        {
            string[] strings =
            {
                ".", "-", "..", ".-", "-.", "--",
                "...", "..-", ".-.", ".--",
                "-..", "-.-", "--.", "---",
                "....", "...-", "..-.", ".-..",
                ".--.", ".---", "-...", "-..-",
                "-.-.", "-.--", "--..", "--.-"
            };
            int len = data.Length;
            if (data.Length > 4) len = 4;
            int result = 0;
            for (int i = 1; i <= len; i++)
            {
                if (i == data.Length && strings.Contains(data))
                    return result + 1;
                if (strings.Contains(data.Substring(0, i)))
                    result += Count(data.Substring(i));
            }
            return result;
        }
    }
}