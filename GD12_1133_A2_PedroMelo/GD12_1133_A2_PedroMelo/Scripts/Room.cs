using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public abstract class Room {
        public string itemFound = "";
        public abstract string roomName { get; }
        public virtual void OnRoomEntered() {
            // Display message of which room the player is in
            Console.WriteLine(); // blank space
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You entered in the {roomName}");
            Console.ResetColor();
        }
        public abstract void OnRoomSearched();
        public virtual void OnRoomExit() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You left the {roomName}");
            Console.ResetColor();
        }
    }

    public class TreasureRoom : Room {
        int timesSearched = 0;
        public override string roomName { get; } = "Treasure Room";

        public override void OnRoomEntered() {
            // Call the base function OnRoomEntered
            base.OnRoomEntered();
        }

        public override void OnRoomSearched() {
            if (timesSearched < 3) {
                // Call function AddItemToInventory
                GameManager.player.InventoryInstance.AddItemToInventory(ref itemFound);
                Console.Write("You found: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(itemFound);
                Console.ResetColor();
                timesSearched++;
            }
            else if (timesSearched >= 3) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameManager.player.PlayerName);
                Console.ResetColor();
                Console.WriteLine($" you can't search more than 3 times on {roomName}");
            }
            else {
                Console.WriteLine("Nothing more on this room!");
            }
        }

    }

    public class CombatRoom : Room {
        int timesSearched = 0;
        bool doesPlayerWon = false;
        bool userWantsToFight = false;
        string userAnswer = "";

        // Create Instances
        DiceRoller dice = new DiceRoller(); // dice Instance

        public override string roomName { get; } = "Combat Room";

        public override void OnRoomEntered() {
            userWantsToFight = false;

            // Call the base function OnRoomEntered
            base.OnRoomEntered();

            // Display message
            Console.WriteLine(); // blank space
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(GameManager.player.PlayerName);
            Console.ResetColor();
            Console.Write(" you have ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(GameManager.player.PlayerLife);
            Console.ResetColor();
            Console.WriteLine(" life points");

            // While loop that start the combat
            while (userWantsToFight != true) {
                Console.WriteLine("Do you want to fight? WRITE: YES | NO");
                userAnswer = (Console.ReadLine() ?? "").ToLower();

                switch (userAnswer) {
                    case "y":
                    case "yes":
                        userWantsToFight = true;
                        // Create a variable enemy that is assign to the RandomEnemy() function
                        Enemy enemy = Enemy.RandomEnemy();

                        // Display message of which enemy the player is fighting against
                        Console.Write($"You are fighting against the ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(enemy.EnemyName);
                        Console.Write(enemy.EnemyName);
                        Console.ResetColor();
                        Console.Write(" has ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(enemy.EnemyLife);
                        Console.ResetColor();
                        Console.WriteLine(" life points");
                        Console.WriteLine(); // blank space

                        // Combat loop that runs while player and enemy are alive
                        while (GameManager.player.IsPlayerAlive && enemy.IsAlive()) {
                            // Call function PlayerTurn
                            PlayerTurn(enemy);
                            // If enemy is not alive the loop stop
                            if (enemy.IsAlive() != true)
                                break;
                            // Call function EnemyTurn
                            EnemyTurn(enemy);
                        }
                        // Call function WinLose that check if player won or lost
                        WinLose(enemy);
                        break;

                    case "n":
                    case "no":
                        Console.WriteLine(); // blank space
                        Console.WriteLine("Okay, you don't want to fight");
                        userWantsToFight = true;
                        doesPlayerWon = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong input. Write: YES | NO");
                        Console.ResetColor();
                        Console.WriteLine(); // blank space
                        break;
                }
            }
        }

        // Function PlayerTurn
        void PlayerTurn(Enemy enemy) {
            int playerHeal = 0;
            int playerDamage = 0;
            int choice = 0;
            bool validChoice = false;
            string userInput = "";

            // Check if the player has a weapon in the inventory
            List<Weapon> weapons = GameManager.player.InventoryInstance.GetWeapons(); // List of weapons
            List<Consumable> consumables = GameManager.player.InventoryInstance.GetConsumables(); // List of consumables
            Weapon selectedWeapon = null;
            Consumable selectedConsumable = null;

            // If loop with logic to select the consumable
            if (GameManager.player.PlayerLife < 40) {
                Console.WriteLine(); // blank space
                GameManager.player.GetPlayerLife(); // Display player's life
                Console.WriteLine("Choose a consumable to use:");
                for (int x = 0; x < consumables.Count; x++) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{x + 1}: {consumables[x].ItemName}");
                    Console.ResetColor();
                }
                Console.WriteLine($"{consumables.Count + 1}: God's mercy");
                validChoice = false; // Reassign validChoice to false

                // While loop that keep running the code while validChoice is false
                while (validChoice != true) {
                    Console.Write("Enter your choice: ");
                    userInput = (Console.ReadLine() ?? "");
                    // If player input is greater or equal 1 and the choice is less or equal the number of weapons in the List the variable validChoice is true
                    if (int.TryParse(userInput, out choice) && choice >= 1 && choice <= consumables.Count + 1) {
                        validChoice = true; // Reassign validChoice to true
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please press the number of the consumable");
                        Console.ResetColor();
                    }
                }
                // If loop that if choice is less or equal the amount of consumables will run the code
                if (choice <= consumables.Count && consumables.Count > 0) {
                    selectedConsumable = consumables[choice - 1]; // Assign the consumables[choice - 1] to selectedConsumable
                }
                
            }

            // If player don't have consumables in the inventory the player will receive a heal of until 4 life points
            if (selectedConsumable == null && GameManager.player.PlayerLife < 40) {
                Console.WriteLine(); // blank space
                Console.WriteLine("The God's will have mercy and will heal you a bit");
                dice.NumberOfSides = 4; // Heal of Gods mercy
                playerHeal = dice.Roll();
                GameManager.player.PlayerLife += playerHeal;
                Console.Write("You healed ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(playerHeal);
                Console.ResetColor();
                Console.WriteLine(" life points");
            }
            else if (selectedConsumable != null && GameManager.player.PlayerLife < 40) {
                // Call function GiveHeal
                playerHeal = selectedConsumable.GiveHeal();
                GameManager.player.PlayerLife += playerHeal;
                Console.WriteLine(); // blank space
                Console.WriteLine($"You used the {selectedConsumable.ItemName}");
                Console.Write("You healed ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(playerHeal);
                Console.ResetColor();
                Console.WriteLine(" life points");
                Console.WriteLine($"The {selectedConsumable.ItemName} has been removed of you inventory");
                Console.WriteLine(); // blank space
                // Call function RemoveItemOfInventory
                GameManager.player.InventoryInstance.RemoveItemOfInventory(selectedConsumable);
            }

            // If loop with logic to select the weapon
            if (weapons.Count >= 0) {
                Console.WriteLine(); // blank space
                GameManager.player.GetPlayerLife(); // Display player's life
                Console.WriteLine("Choose a weapon:");
                for (int x = 0; x < weapons.Count; x++) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{x + 1}: {weapons[x].ItemName}");
                    Console.ResetColor();
                }
                Console.WriteLine($"{weapons.Count + 1}: Fists");
                validChoice = false; // Reassign validChoice to false

                // While loop that keep running the code while validChoice is false
                while (validChoice != true) {
                    Console.Write("Enter your choice: ");
                    userInput = (Console.ReadLine() ?? "");
                    // If player input is greater or equal 1 and the choice is less or equal the number of weapons in the List the variable validChoice is true
                    if (int.TryParse(userInput, out choice) && choice >= 1 && choice <= weapons.Count + 1) {
                        validChoice = true; // Reassign validChoice to true
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please press the number of the weapon.");
                        Console.ResetColor();
                    }
                }
                // If loop that if choice is less or equal the amount of weapons will run the code
                if (choice <= weapons.Count) {
                    selectedWeapon = weapons[choice - 1]; // Assign the weapons[choice - 1] to selectedWeapon
                }
            }

            // If player don't have weapon in the inventory the player will fight with the hands
            if (selectedWeapon == null || (weapons.Count > 0 && choice == weapons.Count + 1)) {
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FIGHT:");
                Console.ResetColor();
                Console.WriteLine("You chose to attack with your fists.");
                dice.NumberOfSides = 4; // Damage attacking with Fist
                playerDamage = dice.Roll();
                Console.WriteLine($"You attack with your fists and deal {playerDamage} damage.");
            }
            else {
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("FIGHT:");
                Console.ResetColor();
                Console.WriteLine($"You attack with your {selectedWeapon.ItemName}.");
                // Call function WeaponDamage
                selectedWeapon.WeaponDamage(ref playerDamage);
                Console.WriteLine($"You deal {playerDamage} damage with your {selectedWeapon.ItemName}.");
            }
            // Call function enemy.TakeDamage
            enemy.TakeDamage(playerDamage);
        }

        //Function EnemyTurn
        void EnemyTurn(Enemy enemy) {
            int enemyDamage = enemy.Attack(); // Assign enemy.Attack to enemyDamage
            // Call function player.TakeDamage
            GameManager.player.TakeDamage(enemyDamage);
        }

        // Function WinLose check if player won or lost
        void WinLose(Enemy enemy) {
            // If loop to display the winner
            if (enemy.IsAlive() == false) { // PLAYER WON
                Console.WriteLine(); // blank space
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You won the combat and killed the ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(enemy.EnemyName);
                Console.ResetColor();
                // Call function AddItemToInventory
                GameManager.player.InventoryInstance.AddItemToInventory(ref itemFound);
                Console.Write("Here is your reward: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(itemFound);
                Console.ResetColor();
                doesPlayerWon = true;
            }
            else if (GameManager.player.IsPlayerAlive != true) { // PLAYER LOST
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lost the combat!");
                Console.ResetColor();
                doesPlayerWon = false;
            }
        }

        public override void OnRoomSearched() {
            if (doesPlayerWon && timesSearched < 3) {
                // Call function AddItemToInventory
                GameManager.player.InventoryInstance.AddItemToInventory(ref itemFound);
                Console.Write("You found: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(itemFound);
                Console.ResetColor();
                timesSearched++;
            }
            else if (doesPlayerWon && timesSearched >= 3) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameManager.player.PlayerName);
                Console.ResetColor();
                Console.WriteLine($" you can't search more than 3 times on {roomName}");
            }
            else {
                Console.WriteLine("Nothing more on this room!");
            }
        }

    }

    public class PuzzleRoom : Room {
        int timesSearched = 0;
        int puzzlesTimes = 0;
        string puzzleAnswer = "";
        bool puzzleIsCorrect = false;

        // Creating the Arrays
        string[] puzzleList = [ // Array of puzzleList
            "What is full of holes but still holds water?", // 0 -y
            "What can you catch but not throw?", // 1 -y
            "What has many rings but no fingers?", // 2
            "I go all around the world, but never leave the corner. What am I?", // 3 -y
            "What goes up but never comes back down?", // 4
        ];
        string[] puzzlesAnswerList = [ // Array of puzzlesAnswerList
            "sponge", // 0
            "cold", // 1
            "telephone", // 2
            "stamp", // 3
            "age", // 4
        ];

        // Method that return a random value of which puzzle will be asked for the player
        int RandomPuzzles() {
            Random random = new Random();
            int randomPuzzle = random.Next(0, puzzleList.Length); // Assign random value to randomPuzzle
            return randomPuzzle; // return randomPuzzle
        }

        public override string roomName { get; } = "Puzzle Room";

        public override void OnRoomEntered() {
            int index = RandomPuzzles(); // Assign the variable RandomPuzzles() to the variable index

            // Call the base function OnRoomEntered
            base.OnRoomEntered();

            // If loop that if player has solved or tried to solve the puzzle more than 3 times the player will can't solve more puzzles
            if (puzzlesTimes < 3) {
                Console.WriteLine(); // blank space
                Console.WriteLine("Answer the correct answer to the riddle");
                Console.WriteLine(); // blank space
                Console.WriteLine("RIDDLE:");
                Console.WriteLine(puzzleList[index]);
                puzzleAnswer = (Console.ReadLine() ?? "").ToLower();

                // If loop that check if the answer is correct
                if (puzzleAnswer == puzzlesAnswerList[index]) {
                    Console.Write("Good job ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(GameManager.player.PlayerName);
                    Console.ResetColor();
                    Console.WriteLine(" your answer is correct!!");
                    Console.WriteLine("Try to search for an item");
                    puzzleIsCorrect = true;
                    puzzlesTimes++;
                }
                else if (puzzlesTimes < 3) {
                    puzzlesTimes++;
                    Console.WriteLine("Your answer is wrong!");
                    Console.WriteLine("Do you want to try again ?");
                    Console.WriteLine("Ask the puzzle here");
                    puzzleAnswer = (Console.ReadLine() ?? "");
                    if (puzzleAnswer == "thanks") {
                        Console.Write("Good job ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(GameManager.player.PlayerName);
                        Console.ResetColor();
                        Console.WriteLine(" your answer is correct!!");
                        Console.WriteLine("Try to search for an item");
                        puzzleIsCorrect = true;
                        puzzlesTimes++;
                    }
                    else {
                        Console.Write($"Hahaha. ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(GameManager.player.PlayerName);
                        Console.ResetColor();
                        Console.WriteLine(" your answer is wrong again! Hahaha!!");
                        puzzlesTimes++;
                    }
                }
            }
            else {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameManager.player.PlayerName);
                Console.ResetColor();
                Console.WriteLine(" you can't try to solve puzzles more than 3 times");
            }
        }

        public override void OnRoomSearched() {
            if (puzzleIsCorrect && timesSearched < 3) {
                // Call function AddItemToInventory
                GameManager.player.InventoryInstance.AddItemToInventory(ref itemFound);
                Console.Write("You found: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(itemFound);
                Console.ResetColor();
                timesSearched++;
            }
            else if (puzzleIsCorrect && timesSearched >= 3) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameManager.player.PlayerName);
                Console.ResetColor();
                Console.WriteLine($" you can't search more than 3 times on {roomName}");
            }
            else {
                Console.WriteLine("Nothing more on this room!");
            }
        }

    }

    public class WelcomeRoom : Room {
        int timesSearched = 0;
        public override string roomName { get; } = "Welcome Room";

        public override void OnRoomEntered() {
            // Call the base function OnRoomEntered
            base.OnRoomEntered();
        }

        public override void OnRoomSearched() {
            if (timesSearched < 3) {
                // Call function AddItemToInventory
                GameManager.player.InventoryInstance.AddItemToInventory(ref itemFound);
                Console.Write("You found: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(itemFound);
                Console.ResetColor();
                timesSearched++;
            }
            else if (timesSearched >= 3) {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(GameManager.player.PlayerName);
                Console.ResetColor();
                Console.WriteLine($" you can't search more than 3 times on {roomName}");
            }
            else {
                Console.WriteLine("Nothing more on this room!");
            }
        }

    }

}