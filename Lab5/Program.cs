using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Constants to hold maximum and minimum scores
            const int MIN_SCORE = 0;
            const int MAX_SCORE = 300;
            const int NUMBER_OF_GAMES = 5;

            // Declaring a few variables
            int gameScoreValue;
            double overallScore = 0;
            double averageScore;
            double minScore;
            double maxScore;

            double[] gameScore = new double[NUMBER_OF_GAMES];  // An array to hold the gameScore

            

            // for-loop that will continue asking for the scores until NUMBER_OF_GAMES has been entered
            for (int gameCounter = 0; gameCounter < NUMBER_OF_GAMES; gameCounter++)
            {
                Console.Write("Please enter the score for Game {0}: ", gameCounter + 1);  // i+1 is used to display the game number because i is also used as the array index and it will always be 1 ahead if the array starts at 0 and the game number starts at 1

                if (Int32.TryParse(Console.ReadLine(), out gameScoreValue))  // Lets check if it can be parsed into a number
                {
                    if (gameScoreValue >= MIN_SCORE && gameScoreValue <= MAX_SCORE)  // Is  the score within the range?
                        gameScore[gameCounter] = gameScoreValue;  // Assign the array at [i] to the score that was entered

                    else  // If the score is not within range...
                    {
                        Console.WriteLine("\n\nScore must be between {0} and {1}. Please try again.\n", MIN_SCORE, MAX_SCORE);
                        gameCounter--;  // Go back 1 and lets redo the for loop and try and get proper input
                    }
                }

                else // If the score cannot be parsed...
                {
                    Console.WriteLine("\n\nScores must be numeric, while numbers only, no decimals..\n");
                    gameCounter--;  // Go back 1 and lets redo the for loop and try and get proper input
                }
            }

            // foreach loop that will go through each score and add it to the overall score
           // foreach (double score in gameScore)
              //  overallScore += score;

           // averageScore = overallScore / NUMBER_OF_GAMES;  // Divide overallScore by the number of games to get the average score

            minScore = gameScore[0];
            maxScore = gameScore[0];
            
         

            for (int gameCounter = 0; gameCounter < gameScore.Length; gameCounter++)
            {
                overallScore += gameScore[gameCounter];
               
                if (minScore > gameScore[gameCounter])
                    minScore = gameScore[gameCounter];

                if (gameScore[gameCounter] > maxScore)
                    maxScore = gameScore[gameCounter];
            }

            averageScore = overallScore / NUMBER_OF_GAMES;  // Divide overallScore by the number of games to get the average score

            // Lots of output will follow here
            Console.Clear(); // Lets clear the screen

            Console.WriteLine("Bowler Scores");

            Console.WriteLine("===================================================================\n");
          
            for (int gameCounter = 0; gameCounter < NUMBER_OF_GAMES; gameCounter++)
            {
                Console.Write("Game {0}: {1}   ", gameCounter + 1, gameScore[gameCounter]);
            }
           
            Console.WriteLine("\n\n===================================================================\n");

            Console.WriteLine("Average Score for Bowler: {0}\n", averageScore);
            Console.WriteLine("High Score for Bowler: {0}\n", maxScore);
            Console.WriteLine("Low Score for Bowler: {0}\n", minScore);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();  // Wait for user to press any key before exiting

        }
    }
}
