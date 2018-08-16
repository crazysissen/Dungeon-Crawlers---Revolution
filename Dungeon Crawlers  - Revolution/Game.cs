using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Game
{
    public static void WriteColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void WriteLineColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static ConsoleKey GetKeyFromList(params ConsoleKey[] keys)
    {
        while (true)
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            if (keys.Contains(key))
                return key;
        }
    }

    public static int GetChoiceFromList(params string[] options)
    {
        ConsoleKey[] possibleChoices = new ConsoleKey[options.Length];
        for (int i = 0; i < options.Length; ++i)
        {
            WriteColor("[" + (i + 1) + "] ", ConsoleColor.Yellow);
            WriteLineColor(options[i], ConsoleColor.White);
            possibleChoices[i] = (ConsoleKey)(49 + i); 
        }

        ConsoleKey input = GetKeyFromList(possibleChoices);
        return (int)input - 49;
    }

    public static float RandomFloat(Random random, float min, float max) => (float)random.NextDouble() * (max - min) - min;
}
