using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public abstract class Room {
        public string itemFound = "";
        public abstract string roomName { get; }
        public abstract void OnRoomEntered();
        public abstract void OnRoomSearched();
        public abstract void OnRoomExit();
    }

    public class TreasureRoom : Room {
        int timesSearched = 0;
        public override string roomName { get; } = "Treasure Room";

        public override void OnRoomEntered() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You entered in the {roomName}");
            Console.ResetColor();
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
        public override void OnRoomExit() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You left the {roomName}");
            Console.ResetColor();
        }
    }

    public class CombatRoom : Room {
        int timesSearched = 0;
        bool doesPlayerWon = false;
        bool userWantsToFight = false;
        string userAnswer = "";

        // Create Instances
        DiceRoller dice = new DiceRoller(); // dice Instance
        Random random = new Random(); // random Instance

        Enemy RandomEnemy() {
            // Create a List that has probability of select an enemy
            List<Enemy> enemyList = new List<Enemy>(); // List of enemies Instances

            // For loop that add 30 times "new Knight()" 30% of chance to be selected
            for (int i = 0; i < 30; i++) {
                enemyList.Add(new Knight());
            }

            // For loop that add 30 times "new Bear()" 30% of chance to be selected
            for (int i = 0; i < 30; i++) {
                enemyList.Add(new Bear());
            }

            // For loop that add 25 times "new WhiteSnow()" 25% of chance to be selected
            for (int i = 0; i < 25; i++) {
                enemyList.Add(new WhiteSnow());
            }

            // For loop that add 15 times "new Batman()" 15% of chance to be selected
            for (int i = 0; i < 15; i++) {
                enemyList.Add(new Batman());
            }
            return enemyList[random.Next(enemyList.Count)];
        }
        public override string roomName { get; } = "Combat Room";

        public override void OnRoomEntered() {
            userWantsToFight = false;

            // Display message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You entered in the {roomName}");
            Console.ResetColor();
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
                        // Choose a random enemy
                        Enemy enemy = RandomEnemy();
                        Console.WriteLine($"You are fighting against a {enemy.EnemyName}");
                        Console.WriteLine($"The {enemy.EnemyName} has {enemy.EnemyLife} life points.");
                        Console.WriteLine(); // blank space

                        // Combat loop that runs while player and enemy are alive
                        while (GameManager.player.IsPlayerAlive && enemy.IsAlive()) {
                            PlayerTurn(enemy); // Player Turn
                            // If enemy.IsAlive is false the loop stop
                            if (enemy.IsAlive() != true)
                                break;

                            EnemyTurn(enemy); // Enemy Turn
                        }

                        // If loop that display the winner
                        if (enemy.IsAlive() == false) { // Player won
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"You defeated the enemy {enemy.EnemyName}!");
                            Console.ResetColor();
                            doesPlayerWon = true;
                        }
                        else if (GameManager.player.IsPlayerAlive != true) { // Player lost
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You have lost the combat!");
                            Console.ResetColor();
                            doesPlayerWon = false;
                        }
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
            // Check if the player has a weapon in the inventory
            List<Weapon> weapons = GameManager.player.InventoryInstance.GetWeapons();
            Weapon selectedWeapon = null;

            int playerDamage = 0;
            int choice = 0;
            bool validChoice = false;

            if (weapons.Count > 0) {
                Console.WriteLine("Choose a weapon to attack with:");
                for (int i = 0; i < weapons.Count; i++) {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{i + 1}: {weapons[i].ItemName}");
                    Console.ResetColor();
                }
                Console.WriteLine($"{weapons.Count + 1}: Fists");

                // While loop that keep running the code while validChoice is false
                while (validChoice != true) {
                    Console.Write("Enter your choice: ");
                    string userInput = (Console.ReadLine() ?? "");
                    // If player input is greater or equal 1 and the choice is less or equal the number of weapons in the List the variable validChoice is true
                    if (int.TryParse(userInput, out choice) && choice >= 1 && choice <= weapons.Count + 1) {
                        validChoice = true;
                    }
                    else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please press the number of the weapon.");
                        Console.ResetColor();
                    }
                }

                if (choice <= weapons.Count) {
                    selectedWeapon = weapons[choice - 1];
                }
            }

            // If player don't have weapon in the inventory the player will fight with the hands
            if (selectedWeapon == null || (weapons.Count > 0 && choice == weapons.Count + 1)) {
                Console.WriteLine("You have no weapons or chose to attack with your fists.");
                dice.NumberOfSides = 4; // Damage fighting with hands
                playerDamage = dice.Roll();
                Console.WriteLine($"You attack with your fists and deal {playerDamage} damage.");
            }
            else {
                Console.WriteLine($"You attack with your {selectedWeapon.ItemName}.");
                selectedWeapon.WeaponDamage(ref playerDamage);
                Console.WriteLine($"You deal {playerDamage} damage with your {selectedWeapon.ItemName}.");
            }
            // Call function enemy.TakeDamage
            enemy.TakeDamage(playerDamage);
        }

        //Function EnemyTurn
        void EnemyTurn(Enemy enemy) {
            int enemyDamage = enemy.Attack();
            GameManager.player.TakeDamage(enemyDamage);

            // Display player's life
            Console.WriteLine($"You have {GameManager.player.PlayerLife} life points remaining.");
            Console.WriteLine(); // blank space
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

        public override void OnRoomExit() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You left the {roomName}");
            Console.ResetColor();
        }
    }

    public class PuzzleRoom : Room {
        int timesSearched = 0;
        int puzzlesTimes = 0;
        string puzzleAnswer = "";
        bool puzzleIsCorrect = false;
        public override string roomName { get; } = "Puzzle Room";

        public override void OnRoomEntered() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You entered in the {roomName}");
            Console.ResetColor();

            // If player solved or tried to solve the puzzle more than 
            if (puzzlesTimes < 3) {
                Console.WriteLine("Ask the puzzle here");
                puzzleAnswer = (Console.ReadLine() ?? "").ToLower();

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
        public override void OnRoomExit() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You left the {roomName}");
            Console.ResetColor();
        }
    }

    public class WelcomeRoom : Room {
        int timesSearched = 0;
        public override string roomName { get; } = "Welcome Room";

        public override void OnRoomEntered() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You entered in the {roomName}");
            Console.ResetColor();
            Console.WriteLine("Try to search to see if you found an item");
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
        public override void OnRoomExit() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"You left the {roomName}");
            Console.ResetColor();
        }
    }

}

// RECHECK TO CHANGE THE WRITES