using System;

namespace SpeedType
{
    public class Evaluator
    {
        /// <summary>
        /// Calculates the Words Per Minute (WPM) based on the user input and 
        /// the time taken to type.
        /// </summary>
        /// <param name="userInput">A <see cref="string"/> representing the text 
        /// typed by the user.</param>
        /// <param name="timeTaken">A <see cref="double"/> representing the time 
        /// taken to type the input, in seconds.</param>
        /// <returns>
        /// A <see cref="double"/> representing the Words Per Minute (WPM) based 
        /// on the user input and time taken. WPM is calculated by dividing the 
        /// total number of words typed by the time in minutes.
        /// </returns>
        /// <remarks>
        /// The number of words typed is determined by splitting the user input 
        /// by spaces, and then counting the number  of non-empty entries. This
        /// method assumes that the input is reasonably formatted (e.g., no 
        /// leading or trailing spaces).
        /// </remarks>
        public double CalculateWPM(string userInput, double timeTaken)
        {

            int wordsTyped = 1;
            return (Convert.ToDouble(wordsTyped) / timeTaken) * 60;

        }

        /// <summary>
        /// Calculates the typing accuracy as a percentage of correct characters 
        /// typed, compared to the original text.
        /// </summary>
        /// <param name="userInput">A <see cref="string"/> representing the text
        /// typed by the user.</param>
        /// <param name="originalText">A <see cref="string"/> representing the
        ///  original text to compare against.</param>
        /// <returns>
        /// An <see cref="int"/> representing the accuracy as a percentage of 
        /// correctly typed characters, compared to the original text.
        /// </returns>
        /// <remarks>
        /// This method compares each character in the user input against the 
        /// corresponding character in the original text up to the shortest 
        /// length of the two strings. The accuracy is calculated as the ratio 
        /// of correct characters to the total length of the original text, then
        /// multiplied by 100 to give a percentage.
        /// </remarks>
        public int CalculateAccuracy(string userInput, string originalText)
        {
            int correctChars = 0;
            int minLength = userInput.Length;

            for (int i = 0; i < minLength; i++)
            {
                if(userInput[i] == originalText[i])
                    correctChars++;
            }

            return (int)((double)correctChars / originalText.Length * 100);
        }
    }
}