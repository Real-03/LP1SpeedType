
```mermaid
classDiagram
    class Game {
        -SentenceProvider senteceProvider
        -Evaluator evaluator
        -GameResult[] gameStats
        +Game()
        +ShowMenu()
        -StartGame()
        -ShowGameStats()
        -ShowGameStatsBarChart()
    }

    class SentenceProvider {
        -string[] senteces
        -Random random
        +SentenceProvider()
        +GetRandomSentence() string
    }

    class GameResult {
        +double WPM
        +int Accuracy
        +double TimeTaken
        +string LosingPattern
        +GameResult(double wpm, int accuracy, double timeTaken)
    }
    class Evaluator {
        +CalculateWPM(string userInput, double timeTaken)
        +CalculateAccuracy(string userInput,string originalText)
    }

    Game --> SentenceProvider
    Game --> GameResult
    Game --> Evaluator

