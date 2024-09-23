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

        internal int diceD6 = 6;
        internal int diceD8 = 8;
        internal int diceD12 = 12;
        internal int diceD20 = 20;

        // Creating instance of Ramdom
        Random randomNumber = new Random();

        // creating the variables with random numbers
        internal int RollD6() {
            int randomRoll6 = randomNumber.Next(1, diceD6 + 1); // D6
            return randomRoll6;
        }
        internal int RollD8() {
            int randomRoll8 = randomNumber.Next(1, diceD8 + 1); // D8
            return randomRoll8;
        }
        internal int RollD12() {
            int randomRoll12 = randomNumber.Next(1, diceD12 + 1); // D12
            return randomRoll12;
        }
        internal int RollD20() {
            int randomRoll20 = randomNumber.Next(1, diceD20 + 1); // D20
            return randomRoll20;
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