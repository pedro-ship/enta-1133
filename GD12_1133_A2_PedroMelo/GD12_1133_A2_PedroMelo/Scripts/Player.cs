using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public class Player {
        public string PlayerName = "";
        public int PlayerScore = 0;
        public int PlayerLife = 40;
        public bool IsPlayerAlive = true;

        // Create instances
        public Inventory InventoryInstance = new Inventory(); // InventoryInstance Instance

        // Function GetPlayerLife
        public void GetPlayerLife() {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(PlayerName);
            Console.ResetColor();
            Console.Write(" you have ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(PlayerLife);
            Console.ResetColor();
            Console.WriteLine(" life points");
        }

        // Function TakeDamage
        public void TakeDamage(int damageTaken) {
            PlayerLife -= damageTaken;

            // If PlayerLife is less or equal 0 the Player is dead
            if (PlayerLife <= 0) {
                IsPlayerAlive = false;
                PlayerLife = 0;
            }
        }

        // Function ResetPlayerStats that reset the player's life and player's inventory
        public void ResetPlayerStats() {
            PlayerLife = 40;
            IsPlayerAlive = true;
            InventoryInstance.InventoryList.Clear();
        }
        
    }
}