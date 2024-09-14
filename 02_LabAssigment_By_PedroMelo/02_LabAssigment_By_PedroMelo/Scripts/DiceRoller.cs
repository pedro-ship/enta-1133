using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LabAssigment_By_PedroMelo.Scripts {
    internal class DiceRoller {
        int numberOfSides = 6;
        int totalScore = 0;

        public void RollDice() {

            // calling function Random
            RandomSide();

            // printing the totalScore
            Console.WriteLine("Your total score is = " + totalScore);

            // calling function WinLose
            WinLose();
        }

        public void RandomSide() {

            // creating instance RND
            Random rnd = new Random();

            Console.WriteLine("--ROLLING THE DICE--");

            // creating a loop for roll the dice randomly
            for (int x = 1; x <= 4; x++) {
                int rolls = rnd.Next(1, numberOfSides);
                Console.Write("Rolled: " + rolls + " | ");
                totalScore += rolls;
            }

            Console.WriteLine(" "); // blank space
        }

        public void WinLose() {
            if (totalScore >= 12) {
                Console.WriteLine("Good job you WON");
            }
            else {
                Console.WriteLine("!! LOSER !!");
            }
        }

    }

}