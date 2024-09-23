using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace _03_LabAssigment_By_PedroMelo.Scripts {
    internal class GameRules {
        int userTotalScore = 0;
        int cpuTotalScore = 0;
        internal bool Dice6 = true;
        internal bool Dice8 = true;
        internal bool Dice12 = true;
        internal bool Dice20 = true;

        /// <summary>
        /// Creating the instances
        /// </summary>
        DiceRoller diceRollerInstance = new DiceRoller(); // diceRollerInstance Instance
        Player user = new Player(); // user Instance
        Player cpu = new Player(); // cpu Instance

        // Function of first round
        internal void FirstTurn() {
            string playerChooseDice = "";

            Console.WriteLine(); // blank space
            Console.WriteLine("FIRST ROUND:");
            Console.WriteLine("Which dice you want to roll?");
            Console.WriteLine("6 sides | 8 sides | 12 sides | 20 sides");
            playerChooseDice = Console.ReadLine();

            if (playerChooseDice == "6" && Dice6) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 6 sided dice...");
                diceRollerInstance.RollScoreD6(ref user.score);
                diceRollerInstance.RollScoreD6(ref cpu.score);
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
                diceRollerInstance.RollScoreD8(ref user.score);
                diceRollerInstance.RollScoreD8(ref cpu.score);
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
                diceRollerInstance.RollScoreD12(ref user.score);
                diceRollerInstance.RollScoreD12(ref cpu.score);
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
                diceRollerInstance.RollScoreD20(ref user.score);
                diceRollerInstance.RollScoreD20(ref cpu.score);
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
                FirstTurn();
            }

        }

        // Function of second round
        internal void SecondTurn() {
            string playerChooseDice = "";

            Console.WriteLine(); // blank space
            Console.WriteLine("SECOND ROUND:");
            Console.WriteLine("Which dice you want to roll?");
            Console.WriteLine("6 sides | 8 sides | 12 sides | 20 sides");
            playerChooseDice = Console.ReadLine();

            if (playerChooseDice == "6" && Dice6) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 6 sided dice...");
                diceRollerInstance.RollScoreD6(ref user.score);
                diceRollerInstance.RollScoreD6(ref cpu.score);
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
                diceRollerInstance.RollScoreD8(ref user.score);
                diceRollerInstance.RollScoreD8(ref cpu.score);
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
                diceRollerInstance.RollScoreD12(ref user.score);
                diceRollerInstance.RollScoreD12(ref cpu.score);
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
                diceRollerInstance.RollScoreD20(ref user.score);
                diceRollerInstance.RollScoreD20(ref cpu.score);
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
                SecondTurn();
            }

        }

        // Function of third round
        internal void ThirdTurn() {
            string playerChooseDice = "";

            Console.WriteLine(); // blank space
            Console.WriteLine("THIRD ROUND:");
            Console.WriteLine("Which dice you want to roll?");
            Console.WriteLine("6 sides | 8 sides | 12 sides | 20 sides");
            playerChooseDice = Console.ReadLine();

            if (playerChooseDice == "6" && Dice6) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 6 sided dice...");
                diceRollerInstance.RollScoreD6(ref user.score);
                diceRollerInstance.RollScoreD6(ref cpu.score);
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
                diceRollerInstance.RollScoreD8(ref user.score);
                diceRollerInstance.RollScoreD8(ref cpu.score);
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
                diceRollerInstance.RollScoreD12(ref user.score);
                diceRollerInstance.RollScoreD12(ref cpu.score);
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
                diceRollerInstance.RollScoreD20(ref user.score);
                diceRollerInstance.RollScoreD20(ref cpu.score);
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
                SecondTurn();
            }

        }

        // Function of four round
        internal void FourTurn() {
            string playerChooseDice = "";

            Console.WriteLine(); // blank space
            Console.WriteLine("LAST ROUND:");
            Console.WriteLine("Which dice you want to roll?");
            Console.WriteLine("6 sides | 8 sides | 12 sides | 20 sides");
            playerChooseDice = Console.ReadLine();

            if (playerChooseDice == "6" && Dice6) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Rolling the 6 sided dice...");
                diceRollerInstance.RollScoreD6(ref user.score);
                diceRollerInstance.RollScoreD6(ref cpu.score);
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
                diceRollerInstance.RollScoreD8(ref user.score);
                diceRollerInstance.RollScoreD8(ref cpu.score);
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
                diceRollerInstance.RollScoreD12(ref user.score);
                diceRollerInstance.RollScoreD12(ref cpu.score);
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
                diceRollerInstance.RollScoreD20(ref user.score);
                diceRollerInstance.RollScoreD20(ref cpu.score);
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
                SecondTurn();
            }

        }

        // Function of Win or Lose
        internal void WinLose() {
            Console.WriteLine(); // blank space
            Console.WriteLine("Your total score: " +userTotalScore);
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
