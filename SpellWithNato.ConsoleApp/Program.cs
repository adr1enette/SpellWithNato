using System;
using System.Linq;

internal class Program
{
    private static readonly string[] NatoAlphabet =
    [
        "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot",
        "Golf", "Hotel", "India", "Juliett", "Kilo", "Lima",
        "Mike", "November", "Oscar", "Papa", "Quebec", "Romeo",
        "Sierra", "Tango", "Uniform", "Victor", "Whiskey", "X-ray",
        "Yankee", "Zulu"
    ];

    private static void Main()
    {
        var wordsFromLetters = Console.ReadLine()!.Trim().ToUpper()
            .Where(c => c is >= 'A' and <= 'Z')
            .Select(c => NatoAlphabet[c - 'A']);

        Console.Clear();
        Console.Write(string.Join(Environment.NewLine, wordsFromLetters));
        Console.ReadKey(true);
    }
}