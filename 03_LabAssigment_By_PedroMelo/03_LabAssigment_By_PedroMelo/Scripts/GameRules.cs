using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _03_LabAssigment_By_PedroMelo.Scripts {
    internal class GameRules {
        string playerChooseDice = "";
        int userTotalScore = 0;
        int cpuTotalScore = 0;
        internal bool Dice6 = true;
        internal bool Dice8 = true;
        internal bool Dice12 = true;
        internal bool Dice20 = true;

        /// <summary>
        /// Creating the instances
        /// </summary>
        DiceRoller diceD6 = new DiceRoller(); // D6 Instance
        DiceRoller diceD8 = new DiceRoller(); // D8 Instance
        DiceRoller diceD12 = new DiceRoller(); // D12 Instance
        DiceRoller diceD20 = new DiceRoller(); // D20 Instance
        Player user = new Player(); // USER Instance
        Player cpu = new Player(); // CPU Instance

        // Function of StartTurn
        internal void StartTurn() {
            diceD6.numberOfSides = 6;
            diceD8.numberOfSides = 8;
            diceD12.numberOfSides = 12;
            diceD20.numberOfSides = 20;
            user.score = 0;
            cpu.score = 0;

            Console.WriteLine(); // blank space
            Console.WriteLine("FIRST ROUND:");
            Console.WriteLine("Which dice you want to roll?");
            Console.WriteLine("6 sides | 8 sides | 12 sides | 20 sides");
            playerChooseDice = Console.ReadLine();

            if (playerChooseDice == "6" && Dice6) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 6 sided dice...");
                diceD6.RollScore(ref user.score);
                diceD6.RollScore(ref cpu.score);
                userTotalScore += user.score;
                cpuTotalScore += cpu.score;
                Console.WriteLine("You Score: " + user.score + " | Computer Score: " + cpu.score);

                if (user.score > cpu.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You won this round");
                }
                else if (cpu.score >= user.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You lost this round");
                }
                Dice6 = false;
            }
            else if (playerChooseDice == "8" && Dice8) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 8 sided dice...");
                diceD8.RollScore(ref user.score);
                diceD8.RollScore(ref cpu.score);
                userTotalScore += user.score;
                cpuTotalScore += cpu.score;
                Console.WriteLine("You Score: " + user.score + " | Computer Score: " + cpu.score);

                if (user.score > cpu.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You won this round");
                }
                else if (cpu.score >= user.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You lost this round");
                }
                Dice8 = false;
            }
            else if (playerChooseDice == "12" && Dice12) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 12 sided dice...");
                diceD12.RollScore(ref user.score);
                diceD12.RollScore(ref cpu.score);
                userTotalScore += user.score;
                cpuTotalScore += cpu.score;
                Console.WriteLine("You Score: " + user.score + " | Computer Score: " + cpu.score);

                if (user.score > cpu.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You won this round");
                }
                else if (cpu.score >= user.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You lost this round");
                }
                Dice12 = false;
            }
            else if (playerChooseDice == "20" && Dice20) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 20 sided dice...");
                diceD20.RollScore(ref user.score);
                diceD20.RollScore(ref cpu.score);
                userTotalScore += user.score;
                cpuTotalScore += cpu.score;
                Console.WriteLine("You Score: " + user.score + " | Computer Score: " + cpu.score);

                if (user.score > cpu.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You won this round");
                }
                else if (cpu.score >= user.score) {
                    Console.WriteLine(); // blank space
                    Console.WriteLine("You lost this round");
                }
                Dice20 = false;
            }
            else {
                Console.WriteLine(); // blank space
                Console.WriteLine("Select the number of side of the dice (6, 8, 12, 20)");
                Console.WriteLine("And you can't select the same dice more than one time");
                StartTurn();
            }

        }

        // Function of Win or Lose
        internal void WinLose() {
            Console.WriteLine(); // blank space
            Console.WriteLine("Your total score: " + userTotalScore);
            Console.WriteLine("Computer total score: " + cpuTotalScore);

            if (userTotalScore > cpuTotalScore) {
                Console.WriteLine(); // blank space
                Console.WriteLine("GOOD JOB YOU WON THE GAME");
            }
            else if (cpuTotalScore >= userTotalScore) {
                Console.WriteLine(); // blank space
                Console.WriteLine("!!Hahaha Loser!! You lost for the computer!");
            }
        }

    }
}