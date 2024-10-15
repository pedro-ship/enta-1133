using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public class Player {
        public string PlayerName = "";
        public int PlayerScore = 0;
        public int PlayerLife = 50;
        public bool IsPlayerAlive = true;

        // Create instances
        public Inventory InventoryInstance = new Inventory(); // InventoryInstance Instance

        // Function TakeDamage
        public void TakeDamage(int damageTaken) {
            PlayerLife -= damageTaken;

            if (PlayerLife <= 0) { // If PlayerLife is less or equal 0 the Player is dead
                IsPlayerAlive = false;
                PlayerLife = 0;
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!! GAME OVER !!");
                Console.ResetColor();
            }
        }

        // Function TakeHeal
        public void TakeHeal(int healTaken) {
            PlayerLife += healTaken;
            if (PlayerLife > 50) { // If PlayerLife is greater than 50 the PlayerLife will be 50
                PlayerLife = 50;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You healed {healTaken} life points. Current life: {PlayerLife}");
            Console.WriteLine($"Now you have {PlayerLife} of life");
            Console.ResetColor();
        }
    }
}

// RECHECK TO CHANGE THE WRITES