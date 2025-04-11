namespace SpeedType
{
    /// <summary>
    /// Represents the result of a game, including the Words Per Minute (WPM),
    /// accuracy, and the time taken to finish the game.
    /// </summary>
    public class GameResult
    {
        /// <summary>
        /// Gets the Words Per Minute (WPM) score for the game.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> representing the WPM score achieved in the 
        /// game.
        /// </value>
        public double WPM { get; }

        /// <summary>
        /// Gets the accuracy score for the game.
        /// </summary>
        /// <value>
        /// An <see cref="int"/> representing the accuracy percentage achieved
        /// in the game.
        /// </value>
        public int Accuracy { get; }

        /// <summary>
        /// Gets the time taken to complete the game.
        /// </summary>
        /// <value>
        /// A <see cref="double"/> representing the time in seconds taken to 
        /// complete the game.
        /// </value>
        public double TimeTaken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameResult"/> class 
        /// with the specified WPM, accuracy, and time taken.
        /// </summary>
        /// <param name="wpm">The Words Per Minute score, of type 
        /// <see cref="double"/>.</param>
        /// <param name="accuracy">The accuracy percentage, of type 
        /// <see cref="int"/>.</param>
        /// <param name="timeTaken">The time taken to complete the game, of type
        /// <see cref="double"/> (in seconds).</param>
        public GameResult(double wpm, int accuracy, double timeTaken)
        {
            // ////////// => TO IMPLEMENT <= //////////// //
        }
    }
}