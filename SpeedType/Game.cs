using System;
using System.Collections.Generic;
using System.Diagnostics;
using Spectre.Console;

namespace SpeedType
{
    public class Game
    {
        /// <summary>
        /// The provider responsible for generating the sentences for the game.
        /// </summary>
        private readonly SentenceProvider sentenceProvider;

        /// <summary>
        /// The evaluator responsible for calculating the user's performance 
        /// (WPM and accuracy).
        /// </summary>
        private readonly Evaluator evaluator;

        /// <summary>
        /// A list to store the last 5 game results for the game stats board.
        /// </summary>
        private readonly GameResult[] gameStats;

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// Sets up the sentence provider, evaluator, and initializes the game 
        /// stats board.
        /// </summary>
        public Game()
        {
            sentenceProvider = new SentenceProvider();
            evaluator = new Evaluator();
            gameStats = new GameResult[5];
        }

        /// <summary>
        /// Displays the main menu of the game and prompts the user to choose an
        /// option.
        /// The available choices are to start the game, view the game stats 
        /// board, or quit the game.
        /// </summary>
        /// <remarks>
        /// This method uses the <see cref="Spectre.Console"/> library to 
        /// display the main menu and handle user input for choosing different 
        /// options. The game will continue prompting 
        /// the user until they choose to quit.
        /// </remarks>
        public void ShowMenu()
        {
            while (true)
            {
                AnsiConsole.Clear();
                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold yellow]Speed Type[/]")
                        .AddChoices("Start Game", "View Game Stats", "Quit"));

                switch (choice)
                {
                    case "Start Game":
                        StartGame();
                        break;
                    case "View Game Stats":
                        ShowGameStats();
                        break;
                    case "Quit":
                        return;
                }
            }
        }

        /// <summary>
        /// Starts a new game round where the player types a randomly generated 
        /// sentence. The game measures the time taken and the accuracy of the 
        /// input.
        /// </summary>
        /// <remarks>
        /// In this method, a random sentence is generated using the 
        /// <see cref="SentenceProvider"/>.
        /// The player must type the sentence within the given time. After the 
        /// player submits their input, the game calculates the Words Per Minute
        /// (WPM) and accuracy, and then records the result in the game stats 
        /// board. The game stats board only stores the last 5 results.
        /// </remarks>
        private void StartGame()
        {
            // The sentence that will be presented to the player.
            string sentence = sentenceProvider.GetRandomSentence();

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold green]Type This Sentence:[/]");
            AnsiConsole.MarkupLine($"[italic yellow]{sentence}[/]");
            AnsiConsole.Markup("\n[gray]Press Enter When Ready...[/]");
            Console.ReadLine();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string userInput = AnsiConsole.Ask<string>("\n[bold cyan]Start" +
                " Typing:[/] ");
            stopwatch.Stop();

            // The time taken by the user to type the sentence.
            double timeTaken = stopwatch.Elapsed.TotalSeconds;

            // The words per minute (WPM) calculated based on the time taken 
            // and the user input.
            double wpm = evaluator.CalculateWPM(userInput,timeTaken);

            // The accuracy percentage calculated based on the user's input and
            // the original sentence.
            int accuracy = evaluator.CalculateAccuracy(userInput,sentence);

            // Shift existing entries
            for (int i = gameStats.Length - 1; i > 0; i--)
            {
                gameStats[i]=gameStats[i-1];
            }


            gameStats[0] = new GameResult(wpm,accuracy,timeTaken);

            AnsiConsole.MarkupLine("\n[bold yellow]Results:[/]");
            AnsiConsole.MarkupLine($"[bold]Time Taken:[/] {timeTaken:F2} " +
                "Seconds");
            AnsiConsole.MarkupLine(
                $"[bold]Words Per Minute (WPM):[/] {wpm:F2}");
            AnsiConsole.MarkupLine($"[bold]Accuracy:[/] {accuracy}%");

            AnsiConsole.Markup("\n[bold green]Press Enter to Return to " +
                "Menu...[/]");
            Console.ReadLine();
        }

        /// <summary>
        /// Displays the game stats board showing the last 5 results with WPM, 
        /// accuracy, and time taken.
        /// </summary>
        /// <remarks>
        /// This method uses <see cref="Spectre.Console"/> to format and display
        /// a table with 
        /// the game stats board results. Each row displays the rank, WPM, 
        /// accuracy, and time taken for each entry.
        /// </remarks>
        private void ShowGameStats()
        {
            AnsiConsole.Clear();
            Table table = new Table();
            table.AddColumn("#");
            table.AddColumn("WPM");
            table.AddColumn("Accuracy");
            table.AddColumn("Time Taken (s)");

            for (int i = 0; i < gameStats.Length; i++)
            {
                if (gameStats[i] == null)
                {
                    // ////////// => TO IMPLEMENT <= //////////// //
                }

                // Add row to table
                // Table.AddRow() only accepts strings
                // ////////// => TO IMPLEMENT <= //////////// //
            }

            AnsiConsole.Write(table);
            AnsiConsole.Markup("\n[bold green]Press Enter to Return to " +
                "Menu...[/]");
            Console.ReadLine();
        }
    }
}