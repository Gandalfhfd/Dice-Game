namespace Dice_Game
{
    internal class Program
    {
        static int RollDie(int numFaces)
        {
            Random rnd = new Random();
            return rnd.Next(1, numFaces + 1);
        }
        static void Main(string[] args)
        {
            // Instantiate a random object
            Random rnd = new Random();

            int roll1;
            int roll2;
            int playerScore;
            int computerScore;

            int numFaces = 6; // Number of faces of the dice

            ConsoleKeyInfo keyPress;
            do
            {
                // Roll the dice for the player
                roll1 = RollDie(numFaces);
                roll2 = RollDie(numFaces);
                playerScore = roll1 + roll2;

                Console.WriteLine("Your Roll");
                Console.WriteLine($"You rolled a {roll1} and a {roll2}");
                Console.WriteLine($"Total is {playerScore}");
                Console.WriteLine();

                // Pause to give the illusion of a game
                Console.WriteLine("Press any key...");
                Console.ReadKey(intercept: true);
                Console.WriteLine();

                // Roll the dice for the computer
                roll1 = RollDie(numFaces);
                roll2 = RollDie(numFaces);
                computerScore = roll1 + roll2;

                Console.WriteLine("Computer's Roll");
                Console.WriteLine($"Computer rolled a {roll1} and a {roll2}");
                Console.WriteLine($"Total is {computerScore}");
                Console.WriteLine();

                // Find out who won
                if (playerScore > computerScore)
                {
                    Console.WriteLine("You win");
                }
                else if (playerScore == computerScore)
                {
                    Console.WriteLine("It was a draw");
                }
                else if (playerScore < computerScore)
                {
                    Console.WriteLine("You LOST :)");
                }
                else
                {
                    Console.WriteLine("Congratulations! You broke the game.");
                }

                // Check if the player wishes to continue
                Console.WriteLine("Play again? y or n");
                // Only accept an 'n' or a 'y'
                do
                {
                    keyPress = Console.ReadKey(intercept: true);
                } while (keyPress.KeyChar != 'n' && keyPress.KeyChar != 'y');

                Console.WriteLine();
            } while (keyPress.KeyChar != 'n');
        }
    }
}
