using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LabAssigment_By_PedroMelo.Scripts {
    internal class GameManager {

        // Function of GameStart
        public void GameStart() {
            Intro();
            Description();
            GameLoop();
            End();
        }

        // Intro message
        private void Intro() {
            Console.WriteLine("Starting the game...");
            Console.WriteLine("Welcome to the game: ROLL OR DIE");
            Console.WriteLine("---> Pedro Melo 09/14/2024 <---");
            Console.WriteLine(" "); // blank space
        }

        // Function of GameLoop
        private void GameLoop() {

            // creating instance DiceRollerInstance
            DiceRoller diceRollerInstance = new DiceRoller();

            // calling function RollDice
            diceRollerInstance.RollDice();

            Console.WriteLine(" "); // blank space
        }

        // Description message
        private void Description() {
            Console.WriteLine("  !Description of the game:");
            Console.WriteLine("|-------------------------------------------------------------------------------------------------------|");
            Console.WriteLine("| -> You will roll four times a six sided dice and the amount of points per roll that you can earn are: |");
            Console.WriteLine("| Min Roll: 1                                                                                           |");
            Console.WriteLine("| Max Roll: 6                                                                                           |");
            Console.WriteLine("| If you get 12 points or more you win instead you will lose.                                           |");
            Console.WriteLine("|-------------------------------------------------------------------------------------------------------|");
            Console.WriteLine(" "); // blank space
        }

        // End message
        private void End() {
            Console.WriteLine("Thank you for playing the game: ROLL OR DIE");
            Console.WriteLine("|------------------------------------------|");
            Console.WriteLine("| ---> Coded by Pedro Melo 09/14/2024 <--- |");
            Console.WriteLine("|------------------------------------------|");
            Console.ReadKey();
        }

    }

}