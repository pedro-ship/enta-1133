using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_PedroMelo.Scripts {
    internal class GameManager {
        string userStringWantsToPlay = "";
        bool userBoolWantsToPlay;

        // Creating the Array
        int[] rounds = new int[1];

        // Creating the Instances
        Player player1 = new Player(); // Player1 Instance
        Player player2 = new Player();// Player2 Instance

        // Function Play that does call others functions
        internal void Play() {
            Intro();
            UserWantsToPlay();
            GetPlayerName();
            Description();
            UserUnderstoodRules();
            GameLoop();
            End();
        }

        // Function GameLoop run the game logic
        internal void GameLoop() {
            player1.playerTotalScore = 0;
            player2.playerTotalScore = 0;
            // Assign value to the Array
            rounds[0] = 1;

            // For loop that execute the rounds
            for (rounds[0] = 1; rounds[0] <= 4; rounds[0]++) {
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("ROUND: " + rounds[0]);
                Console.ResetColor();
                // Call function Turns
                Turns();
            }
            // Call function WinLose
            WinLose();
        }

        // Function Turns that run the turns logic
        void Turns() {
            // Call function PlayerPickDice of player1
            player1.PlayerPickDice();
            // Call function PlayerPickDice of player2
            player2.PlayerPickDice();

            Console.WriteLine(); // blank space
            Console.Write("On ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("(Round " + rounds[0] + ") ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player1.playerName);
            Console.ResetColor();
            Console.WriteLine(" scored: " + player1.playerScore);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player2.playerName);
            Console.ResetColor();
            Console.WriteLine(" scored: " + player2.playerScore);
            // Call function RoundResult
            RoundResult();
        }

        // Function RoundResult calculates which player won the round
        void RoundResult() {
            if (player1.playerScore > player2.playerScore) { // Display Player 1 won the round
                Console.WriteLine(); // blank space
                Console.Write("On ");
                Console.Write("Round " + rounds[0] + " ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player1.playerName);
                Console.ResetColor();
                Console.WriteLine(" won this round !!");
                player1.playerTotalScore++;
            }
            else if (player1.playerScore < player2.playerScore) { // Display Player 2 won the round
                Console.WriteLine(); // blank space
                Console.Write("On ");
                Console.Write("Round " + rounds[0] + " ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player2.playerName);
                Console.ResetColor();
                Console.WriteLine(" won this round !!");
                player2.playerTotalScore++;
            }
            else if (player1.playerScore == player2.playerScore) { // Anyone won
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Anyone won this round");
                Console.ResetColor();
                Console.WriteLine(); // blank space
            }
            player1.playerScore = 0;
            player2.playerScore = 0;
        }

        // Function WinLose calculates which player won the game
        void WinLose() {
            player1.playerTotalScore--;
            player2.playerTotalScore--;
            Console.WriteLine(); // blank space
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player1.playerName);
            Console.ResetColor();
            Console.WriteLine(" your total score is: " + player1.playerTotalScore);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player2.playerName);
            Console.ResetColor();
            Console.WriteLine(" your total score is: " + player2.playerTotalScore);

            if (player1.playerTotalScore > player2.playerTotalScore) {
                Console.WriteLine(); // blank space
                Console.Write("GOOD JOB ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player1.playerName);
                Console.ResetColor();
                Console.WriteLine(" YOU WON THE GAME !!!");
            }
            else if (player1.playerTotalScore < player2.playerTotalScore) {
                Console.WriteLine(); // blank space
                Console.Write("GOOD JOB ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(player2.playerName);
                Console.ResetColor();
                Console.WriteLine(" YOU WON THE GAME !!!");
            }
            else if (player1.playerTotalScore == player2.playerTotalScore) {
                Console.WriteLine(); // blank space
                Console.WriteLine("!! Anyone won the game !!");
            }
        }



        // Function GetPlayerName
        void GetPlayerName() {
            Console.WriteLine(); // blank space
            // Getting name of player 1
            Console.Write("What the name of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Player 1");
            Console.ResetColor();
            Console.WriteLine(" ?");
            player1.playerName = Console.ReadLine().ToUpper();
            Console.WriteLine(); // blank space

            // Getting name of player 2
            Console.Write("What the name of ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Player 2");
            Console.ResetColor();
            Console.WriteLine(" ?");
            player2.playerName = Console.ReadLine().ToUpper();

            // Hello message to both players
            Console.WriteLine(); // blank space
            Console.Write("Hello ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player1.playerName);
            Console.ResetColor();
            Console.Write(" and ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(player2.playerName);
            Console.ResetColor();
            Console.Write(" welcome to the game ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Roll or Die");
            Console.ResetColor();
            Console.WriteLine(" !!");
            Console.WriteLine(); // blank space
        }

        // Function that will ask if the player wants to play
        internal void UserWantsToPlay() {
            Console.Write("Do you want to play? write: ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("<YES>");
            Console.ResetColor();
            Console.Write(" or ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("<NO>");
            Console.ResetColor();
            userStringWantsToPlay = Console.ReadLine().ToUpper();

            if (userStringWantsToPlay == "YES" || userStringWantsToPlay == "Y") {
                Console.WriteLine("You answared: YES");
            }
            else if (userStringWantsToPlay == "NO" || userStringWantsToPlay == "N") {
                Console.WriteLine("You answared: NO");
                Sorry();
            }
            while (userStringWantsToPlay != "YES" && userStringWantsToPlay != "Y" && userStringWantsToPlay != "NO" && userStringWantsToPlay != "N") {
                Console.WriteLine(); // blank space
                Console.WriteLine("--> !! Wrong input !! <--");
                Console.WriteLine(); // blank space
                UserWantsToPlay();
            }
        }

        // Function UserUnderstoodRules check if the player understood the rules to preceed to play
        internal void UserUnderstoodRules() {
            Console.WriteLine(); // blank space
            Console.Write("Did you understood the rules? (if yes press ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("<ENTER>");
            Console.ResetColor();
            Console.WriteLine(" to continue)");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        // Function Intro
        public void Intro() {
            // Display the intro message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|Coded by -->Pedro Melo<-- on 10/03/2024|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine
                (" _   _      _ _ \r\n" +
                "| | | | ___| | | ___  \r\n" +
                "| |_| |/ _ \\ | |/ _ \\ \r\n" +
                "|  _  |  __/ | | (_) |\r\n" +
                "|_| |_|\\___|_|_|\\___/ ");
            Console.ResetColor();
            Console.WriteLine(); // blank space
        }

        // Function Description
        public void Description() {
            Console.WriteLine(); // blank space
            Console.WriteLine("Okay! Now just read the rules of the game:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.WriteLine("| In this game is you against or opponent and the game in based in four rounds.          |");
            Console.WriteLine("| Every round the player 1 will pick one of the the dices and the same for the opponent. |");
            Console.WriteLine("| You will pick one dice of this in here:                                                |");
            Console.WriteLine("| -> 6 sides / -> 8 sides / -> 12 sides / -> 20 sides                                    |");
            Console.WriteLine("| After you roll the dice we will calculate who won the round.                           |");
            Console.WriteLine("| In the end the winner will be who has more round wins.                                 |");
            Console.WriteLine("|----------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        // Function Sorry
        public void Sorry() {
            Console.WriteLine(); // blank space
            Console.WriteLine("-- I understand that you don't want to play!! --");
            End();
            Environment.Exit(0);
        }

        // Function End
        public void End() {
            // Display the goodbye message
            Console.WriteLine(); // blank space
            Console.WriteLine("Goodbye!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|Coded by -->Pedro Melo<-- on10/03/2024|");
            Console.ResetColor();
        }

    }
}