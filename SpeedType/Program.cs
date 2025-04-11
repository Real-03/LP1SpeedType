namespace SpeedType
{
    /// <summary>
    /// The Program class contains the entry point for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// It initializes the game and displays the main menu to the player.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        private static void Main(string[] args)
        {
            Game game = new Game();
            game.ShowMenu();
        }
    }
}

