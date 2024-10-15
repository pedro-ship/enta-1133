using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A1_PedroMelo.Scripts {
    public class DiceRoller {
        public int numberOfSides = 0;

        // Creating instance of Ramdom
        Random randomNumber = new Random();

        // Creating the variable Roll that will generate a random number every time
        public int Roll() {
            int randomRoll = randomNumber.Next(1, numberOfSides + 1);
            return randomRoll;
        }

        // Creating the function RollScore that add variable Score + variable Roll
        public void RollScore(ref int playerScore) {
            playerScore += Roll();
        }

    }
}