using System;
using Spectre.Console;

internal class Program
{
    private static readonly string[] NatoPhoneticAlphabet =
    [
        "Alpha", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot",
        "Golf", "Hotel", "India", "Juliett", "Kilo", "Lima",
        "Mike", "November", "Oscar", "Papa", "Quebec", "Romeo",
        "Sierra", "Tango", "Uniform", "Victor", "Whiskey", "X-ray",
        "Yankee", "Zulu"
    ];

    private static void Main()
    {
        var input = string.Empty;
        Console.CursorVisible = false;

        while (true)
        {
            AnsiConsole.Clear();

            AnsiConsole.MarkupLine("[bold green]Enter text (Esc to exit):[/]");
            AnsiConsole.MarkupLine($"[bold yellow]{input}[/]");

            if (input.Length > 0)
            {
                var table = new Table()
                    .AddColumn("[underline]Char[/]")
                    .AddColumn("[underline]NATO Word[/]");

                foreach (var c in input.ToUpperInvariant())
                {
                    if (c is >= 'A' and <= 'Z')
                    {
                        table.AddRow($"[blue]{c}[/]", $"[white]{NatoPhoneticAlphabet[c - 'A']}[/]");
                    }
                }

                AnsiConsole.Write(table);
            }

            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Escape)
            {
                Console.CursorVisible = true;
                break;
            }

            if (input.Length > 0 && key.Key == ConsoleKey.Backspace)
            {
                input = key.Modifiers.HasFlag(ConsoleModifiers.Control) ? string.Empty : input[..^1];
            }
            else
            {
                var upperChar = char.ToUpperInvariant(key.KeyChar);
                if (upperChar is >= 'A' and <= 'Z' && input.Length < Console.WindowHeight - 7)
                {
                    input += key.KeyChar;
                }
            }
        }
    }
}