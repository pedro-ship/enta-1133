using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LabAssigment_By_PedroMelo.Scripts {
    internal class GameManager {

        // Creating function Play
        public void Play() {
            Intro();
            Description();
            GameLoop();
            Research();
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

            // creating instance DieRollerInstance
            DieRoller diceRollerInstance = new DieRoller();

            // calling function Roll
            diceRollerInstance.Roll();

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

        // Research message
        private void Research() {
            Console.WriteLine("Research and Explain");
            Console.WriteLine(" + is Addition operator");
            Console.WriteLine(" - is Subtraction operator");
            Console.WriteLine(" / is Division operator");
            Console.WriteLine(" * is Multiplication operator");
            Console.WriteLine(" ++ is Increment operator");
            Console.WriteLine(" -- is Decrement operator");
            Console.WriteLine(" % is Modulus operator");

            Console.WriteLine(" "); // Blank space
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