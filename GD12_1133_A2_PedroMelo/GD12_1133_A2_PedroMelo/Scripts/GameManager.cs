using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public class GameManager {
        // Create the Instances
        public static Player player = new Player(); // Global player Instance
        Message messages = new Message(); // Local messages Instance
        Random random = new Random(); // Local random Instance

        // Create List of roomList
        List<Room> roomList = new List<Room> { new TreasureRoom(), new CombatRoom(), new PuzzleRoom() }; // List of Room

        // Creating Array of grid
        Room[,] grid = new Room[3, 3]; // Array of Room

        // Function that call all the others functions
        public void Play() {
            messages.Intro();
            messages.GetPlayerName();
            messages.Description();
            GameLoop();
            messages.End();
        }

        // Function CreateGrid
        private void CreateGrid() {
            // Create the grid instances and assign to a random room of roomList
            grid[0, 2] = roomList[random.Next(roomList.Count)]; // Top left
            grid[1, 2] = roomList[random.Next(roomList.Count)]; // Top mid
            grid[2, 2] = roomList[random.Next(roomList.Count)]; // Top right

            grid[0, 1] = roomList[random.Next(roomList.Count)]; // Mid Left
            grid[1, 1] = new WelcomeRoom(); // Mid mid (Start Room)
            grid[2, 1] = roomList[random.Next(roomList.Count)]; // Mid right

            grid[0, 0] = roomList[random.Next(roomList.Count)]; // Bottom left
            grid[1, 0] = roomList[random.Next(roomList.Count)]; // Bottom mid
            grid[2, 0] = roomList[random.Next(roomList.Count)]; // Bottom right
        }

        // Function contains game logic
        private void GameLoop() {
            int playerX = 1;
            int playerY = 1;
            int newPlayerX = playerX;
            int newPlayerY = playerY;
            bool gameIsActive = true;
            string optionAnswer = "";
            string directionAnswer = "";

            // Call function CreateGrid to create the grid
            CreateGrid();

            // While loop that keep running while the variable "gameIsActive" = true
            while (gameIsActive) {
                if (player.IsPlayerAlive) {
                    // Display message
                    Console.WriteLine(); // blank space
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"You are on the {grid[playerX, playerY].roomName}");
                    Console.ResetColor();
                    Console.WriteLine(); // blank space
                    Console.WriteLine("Select one the options:");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("1: Move to other room");
                    Console.WriteLine("2: Search current room");
                    Console.WriteLine("3: Check inventory");
                    Console.WriteLine("4: Check life points");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("5: Quit Game");
                    Console.ResetColor();
                    optionAnswer = (Console.ReadLine() ?? ""); // Get user input
                    Console.WriteLine(); // blank space

                    // Switch to choose option
                    switch (optionAnswer) {
                        case "1": // Option "1" move to other room
                            bool directionValid = true; // Create and assign value of directionValid to true
                                                        // Display message
                            Console.WriteLine("Which direction do you want to move ?");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("1: North");
                            Console.WriteLine("2: South");
                            Console.WriteLine("3: East");
                            Console.WriteLine("4: West");
                            Console.ResetColor();
                            directionAnswer = (Console.ReadLine() ?? "").ToLower(); // Get user input
                            Console.WriteLine(); // blank space

                            // Reassign values of the variables
                            newPlayerX = playerX;
                            newPlayerY = playerY;

                            // Switch to choose direction
                            switch (directionAnswer) {
                                // Direction "North"
                                case "north":
                                case "1":
                                    newPlayerY++;
                                    directionAnswer = "north";
                                    break;

                                // Direction "South"
                                case "south":
                                case "2":
                                    newPlayerY--;
                                    directionAnswer = "south";
                                    break;

                                // Direction "East"
                                case "east":
                                case "3":
                                    newPlayerX++;
                                    directionAnswer = "east";
                                    break;

                                // Direction "West"
                                case "west":
                                case "4":
                                    newPlayerX--;
                                    directionAnswer = "west";
                                    break;

                                default: // Default option
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Direction invalid");
                                    Console.ResetColor();
                                    Console.WriteLine("Select: 1 North | 2 South | 3 East | 4 West");
                                    directionValid = false; // Reassign value of directionValid to false
                                    break;
                            }
                            // Check if directionValid is true
                            if (directionValid) {
                                // Check if newPlayer position is inside the grid, and if is true will assign the variable playerX and playerY to the newPlayer position
                                if (newPlayerX >= 0 && newPlayerX < 3 && newPlayerY >= 0 && newPlayerY < 3) {
                                    // Call function OnRoomExit and display the room that the player left
                                    grid[playerX, playerY].OnRoomExit();

                                    // Reassigning values of the variables
                                    playerX = newPlayerX;
                                    playerY = newPlayerY;

                                    // Display which direction player moved
                                    Console.Write("You moved to ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(directionAnswer);
                                    Console.ResetColor();

                                    // Call function OnRoomEntered
                                    grid[playerX, playerY].OnRoomEntered();
                                }
                                else {
                                    // Display that player can't move to this direction
                                    Console.WriteLine(); // blank space
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("You can't move to ");
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.Write(directionAnswer);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" this is out of the grid");
                                    Console.ResetColor();
                                }
                            }
                            break;

                        case "2": // Option "2" search current room
                                  // Call function OnRoomSearched
                            grid[playerX, playerY].OnRoomSearched();
                            break;

                        case "3": // Option "3" check inventory
                            player.InventoryInstance.CheckInventory();
                            Console.WriteLine();
                            break;

                        case "4": // Option "4" check life points
                            Console.WriteLine("LIFE:");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(GameManager.player.PlayerName);
                            Console.ResetColor();
                            Console.Write(" you have ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(GameManager.player.PlayerLife);
                            Console.ResetColor();
                            Console.WriteLine(" life points");
                            break;

                        case "5": // Option "5" quit game
                            Console.WriteLine(); // blank space
                            Console.WriteLine("You selected to quit the game...");
                            Console.WriteLine("You quit the game");
                            gameIsActive = false;
                            break;

                        default: // Default option
                            Console.WriteLine(); // blank space
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Option invalid");
                            Console.ResetColor();
                            Console.WriteLine("Select: 1 | 2 | 3 | 4 | 5");
                            Console.WriteLine(); // blank space
                            break;
                    }
                }
                else {
                    Console.WriteLine(); // blank space
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!! GAME OVER !!");
                    Console.ResetColor();
                    Console.WriteLine("Do you want to play again ?");
                    Console.WriteLine("Select: YES | NO");
                    optionAnswer = (Console.ReadLine() ?? "").ToLower();

                    switch (optionAnswer) {
                        case "y":
                        case "yes":
                            // Display message
                            Console.WriteLine(); // blank space
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("GAME RESTARTED");
                            Console.ResetColor();

                            // Reassign playerX and playerY to reset player's location on the grid
                            playerX = 1;
                            playerY = 1;
                            // Call function ResetPlayerStats that reset the InventoryList, PlayerLife and IsPlayerAlive
                            player.ResetPlayerStats();
                            // Call function CreateGrid to recreate the grid
                            CreateGrid();
                            break;

                        case "n":
                        case "no":
                            gameIsActive = false;
                            break;

                        default:
                            Console.WriteLine(); // blank space
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Option invalid");
                            Console.ResetColor();
                            Console.WriteLine("Select: YES | NO");
                            Console.WriteLine(); // blank space
                            break;
                    }
                }
                
            }
        }

    }
}