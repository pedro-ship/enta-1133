using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_PedroMelo.Scripts {
    public class Player {
        public int playerScore = 0;
        public int playerTotalScore = 0;
        public string playerName = "";
        public string playerStringPickDice = "";

        // Creating Dictionary of playerDicesAvailables to check what dices are availables
        public Dictionary<string, bool> dicesAvailables = new Dictionary<string, bool>() {
            { "isAvailableD6", true },
            { "isAvailableD8", true },
            { "isAvailableD12", true },
            { "isAvailableD20", true }

        };

        // Creating the Instances
        DiceRoller diceD6 = new DiceRoller(); // D6 instance
        DiceRoller diceD8 = new DiceRoller(); // D8 instance
        DiceRoller diceD12 = new DiceRoller(); // D12 instance
        DiceRoller diceD20 = new DiceRoller(); // D20 instance

        public void PlayerRollDice() {
            diceD6.numberOfSides = 6;
            diceD8.numberOfSides = 8;
            diceD12.numberOfSides = 12;
            diceD20.numberOfSides = 20;

            if (playerStringPickDice == "6" && dicesAvailables["isAvailableD6"] == true) {
                Console.WriteLine(); // blank space
                diceD6.RollScore(ref playerScore);
                dicesAvailables["isAvailableD6"] = false;
            }
            else if (playerStringPickDice == "8" && dicesAvailables["isAvailableD8"] == true) {
                Console.WriteLine(); // blank space
                diceD8.RollScore(ref playerScore);
                dicesAvailables["isAvailableD8"] = false;
            }
            else if (playerStringPickDice == "12" && dicesAvailables["isAvailableD12"] == true) {
                Console.WriteLine(); // blank space
                diceD12.RollScore(ref playerScore);
                playerTotalScore++;
                dicesAvailables["isAvailableD12"] = false;
            }
            else if (playerStringPickDice == "20" && dicesAvailables["isAvailableD20"] == true) {
                Console.WriteLine(); // blank space
                diceD20.RollScore(ref playerScore);
                dicesAvailables["isAvailableD20"] = false;
            }
            else {
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(playerName);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" you need to select one of this dices: (6, 8, 12, 20)");
                Console.WriteLine("And you can't select the same dice more than one time");
                Console.ResetColor();
                Console.WriteLine(); // blank space
                // Call function PlayerPickDice
                PlayerPickDice();
            }
        }

        // Function PlayerPickDice get the input of which dice player will roll
        public void PlayerPickDice() {
            playerStringPickDice = "";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerName);
            Console.ResetColor();
            Console.WriteLine(" turn:");
            Console.WriteLine("Dices availables are 'true'");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine
                ("D6: " + dicesAvailables["isAvailableD6"]
                + "| D8: " + dicesAvailables["isAvailableD8"]
                + "| D12: " + dicesAvailables["isAvailableD12"]
                + "| D20: " + dicesAvailables["isAvailableD20"]);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(playerName);
            Console.ResetColor();
            Console.WriteLine(" which dice do you want to roll ?");
            Console.WriteLine("--> 6 | 8 | 12 | 20 <--");
            playerStringPickDice = Console.ReadLine();
            // Call function PlayerRollDice
            PlayerRollDice();
        }
    }
}