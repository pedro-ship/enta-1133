using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public class Message {
        // Function that get the player's name
        public void GetPlayerName() {
            Console.WriteLine("What is Your Name ?");
            GameManager.player.PlayerName = (Console.ReadLine() ?? "").ToUpper();
            Console.WriteLine(); // blank space
        }

        // Function Intro
        public void Intro() {
            // Display the intro message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|Coded by -->Pedro Melo<-- on 10/12/2024|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine
                (" _   _      _ _ \r\n" +
                "| | | | ___| | | ___  \r\n" +
                "| |_| |/ _ \\ | |/ _ \\ \r\n" +
                "|  _  |  __/ | | (_) |\r\n" +
                "|_| |_|\\___|_|_|\\___/ ");
            Console.ResetColor();
            Console.WriteLine(); // blank space
        }

        // Function Description
        public void Description() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hello ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(GameManager.player.PlayerName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" here is a description of the game:");
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine("| First welcome to the game \"Cursed Rooms\"                                       |");
            Console.WriteLine("| On this game you can explore the rooms in a 3x3 grid                           |");
            Console.WriteLine("| There are 3 kinds of rooms: Treasure, Puzzle and Combat                        |");
            Console.WriteLine("| Treasure: You can freely search in the room 3 times                            |");
            Console.WriteLine("| Puzzle: you can try to solve the puzzle and then be able to search in the room |");
            Console.WriteLine("| Combat: You select a found weapon and fight against the enemy                  |");
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        // Function End
        public void End() {
            // Display the goodbye message
            Console.WriteLine(); // blank space
            Console.WriteLine("Goodbye!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("|Coded by -->Pedro Melo<-- on10/12/2024|");
            Console.ResetColor();
        }

    }
}