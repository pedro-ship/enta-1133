using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _03_LabAssigment_By_PedroMelo.Scripts {
    internal class DiceRoller {
        internal int numberOfSides = 6;

        // Creating instance of Ramdom
        Random randomNumber = new Random();

        // Creating the variables with random numbers
        internal int Roll() {
            int randomRoll = randomNumber.Next(1, numberOfSides + 1);
            return randomRoll;
        }

        // Creating the function to roll and score the number
        internal void RollScore(ref int score) {
            score += Roll();
        }
    }
}