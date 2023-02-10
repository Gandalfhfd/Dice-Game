namespace Dice_Game
{
    internal class Program
    {
        static string Truncate(string text, int numCharsToBeTruncated)
        {
            return text.Substring(0, text.Length - numCharsToBeTruncated);
        }

        static int[] RollDie(int numFaces, int numDice)
        {
            // Instantiate stuff
            Random rnd = new Random();
            int[] funcOutput = new int[numDice];

            // Roll as many dice as the user wants
            for (int i = 0; i < numDice; i++)
            {
                funcOutput[i] = rnd.Next(1, numFaces + 1);
            }

            return funcOutput;
        }

        static void PrintResults(int[] rolls, string player)
        {
            // player may not be what you think it is... this comment is high quality
            string str = " rolled a ";

            // Handles arbitrarily many dice
            foreach (int roll in rolls)
            {
                str += $"{roll} and a ";
            }

            // Truncate the final "and a "
            str = Truncate(str, 7);

            Console.WriteLine(player + str);
            Console.WriteLine($"Total is {rolls.Sum()}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int numFaces = 6; // Number of faces of the dice
            int numDice = 5; // Number of dice
            // Instantiate a random object
            Random rnd = new Random();
            int[] rolls = new int[numDice];
            rolls = RollDie(numFaces, numDice);

            int playerScore;
            int computerScore;

            // Store keypresses
            ConsoleKeyInfo keyPress;
            do
            {
                // Roll the dice for the player
                playerScore = rolls.Sum();

                Console.WriteLine("Your Roll");
                PrintResults(rolls, "You");

                // Pause to give the illusion of a game
                Console.WriteLine("Press any key...");
                Console.ReadKey(intercept: true);
                Console.WriteLine();

                // Roll the dice for the computer
                rolls = RollDie(numFaces, numDice);
                computerScore = rolls.Sum();

                Console.WriteLine("Computer's Roll");
                PrintResults(rolls, "Computer");

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
