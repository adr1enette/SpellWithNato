﻿using System;
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

    private const int ReservedLinesCount = 7;
    private static string _input = string.Empty;
    private static int _previousLength;

    private static void Main()
    {
        Console.CancelKeyPress += (_, _) => Console.CursorVisible = true;
        Console.CursorVisible = false;

        RenderUi();

        while (true)
        {
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Escape)
            {
                Console.CursorVisible = true;
                break;
            }

            UpdateInput(key);

            if (_input.Length == _previousLength) continue;
            _previousLength = _input.Length;
            RenderUi();
        }
    }

    private static void UpdateInput(ConsoleKeyInfo key)
    {
        if (key.Key == ConsoleKey.Backspace && _input.Length > 0)
        {
            _input = key.Modifiers.HasFlag(ConsoleModifiers.Control)
                ? string.Empty
                : _input[..^1];
        }
        else
        {
            var upperChar = char.ToUpperInvariant(key.KeyChar);
            if (upperChar is >= 'A' and <= 'Z' && _input.Length < Console.WindowHeight - ReservedLinesCount)
            {
                _input += key.KeyChar;
            }
        }
    }

    private static void RenderUi()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold green]Enter text (Esc to exit):[/]");
        AnsiConsole.MarkupLine($"[bold yellow]{_input}[/]");

        if (_input.Length == 0) return;

        var table = new Table()
            .AddColumn("[underline]Char[/]")
            .AddColumn("[underline]NATO Word[/]");

        foreach (var c in _input.ToUpperInvariant())
        {
            table.AddRow($"[blue]{c}[/]", $"[white]{NatoPhoneticAlphabet[c - 'A']}[/]");
        }

        AnsiConsole.Write(table);
    }
}