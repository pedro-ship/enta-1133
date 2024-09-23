using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_LabAssigment_By_PedroMelo.Scripts {
    internal class DiceRoller {
        // Creating Player instance
        Player playerInstance = new Player();

        internal int sixSideDice = 6;
        internal int eightSideDice = 8;
        internal int twelveSideDice = 12;
        internal int twentySideDice = 20;

        // Creating instance of Ramdom
        Random randomNumber = new Random();

        // creating the variables with random numbers
        internal int RollD6() {
            int randomRoll = randomNumber.Next(1, sixSideDice + 1); // D6
            return randomRoll;
        }
        internal int RollD8() {
            int randomRoll = randomNumber.Next(1, eightSideDice + 1); // D8
            return randomRoll;
        }
        internal int RollD12() {
            int randomRoll = randomNumber.Next(1, twelveSideDice + 1); // D12
            return randomRoll;
        }
        internal int RollD20() {
            int randomRoll = randomNumber.Next(1, twentySideDice + 1); // D20
            return randomRoll;
        }


        // creating the function to roll and score the number
        internal void RollScoreD6(ref int score) { // D6
            score += RollD6();
        }
        internal void RollScoreD8(ref int score) { // D8
            score += RollD8();
        }
        internal void RollScoreD12(ref int score) { // D12
            score += RollD12();
        }
        internal void RollScoreD20(ref int score) { // D20
            score += RollD20();
        }
    }
}