using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_LabAssigment_By_PedroMelo.Scripts {
    internal class GameManager {
        string playerName = "";
        string playerStringWantsToPlay = "";
        internal bool playerBoolWantsToPlay = false;

        // Creating instance of GameRulles
        GameRules gameRulesInstance = new GameRules();

        // Function Play
        public void Play() {
            Intro();
            PlayerWantsToPlay();

            // Just if the player wants to play to code will run
            if (playerBoolWantsToPlay) {
                Description();
                GameLoop();
            }
            else if (playerBoolWantsToPlay == false) {
                Sorry();
            }
            End();
        }

        // Function GameLoop
        internal void GameLoop() {

            Console.WriteLine("FIRST ROUND:");
            gameRulesInstance.DecideTurn();
            Console.WriteLine("SECOND ROUND:");
            gameRulesInstance.UserPickDice();
            Console.WriteLine("THIRD ROUND:");
            gameRulesInstance.UserPickDice();
            Console.WriteLine("FOUR ROUND:");
            gameRulesInstance.UserPickDice();
            gameRulesInstance.WinLose();
        }

        // Intro message
        public void Intro() {
            Console.WriteLine("|Coded by -->Pedro Melo<-- on 9/20/2024|");
            Console.WriteLine(); // blank space
            Console.WriteLine("What is your name ?");
            playerName = Console.ReadLine();
            Console.WriteLine(); // blank space
            Console.WriteLine("Hello " + playerName + " welcome to my game!");
        }

        // Function that will ask if the player wants to play
        internal void PlayerWantsToPlay() {
            Console.WriteLine("Do you want to play? (if yes: write <YES>)");
            playerStringWantsToPlay = Console.ReadLine().ToUpper();

            // Question player want to play ?
            if (playerStringWantsToPlay == "YES" || playerStringWantsToPlay == "Y") {
                playerBoolWantsToPlay = true;
            }
            else {
                Console.WriteLine(); // blank space
                Console.WriteLine("Are you sure you don't want to play ?");
                Console.WriteLine("If you want to play: write <YES>");
                playerStringWantsToPlay = Console.ReadLine().ToUpper();

                if (playerStringWantsToPlay == "YES" || playerStringWantsToPlay == "Y") {
                    playerBoolWantsToPlay = true;
                }
                else {
                    playerBoolWantsToPlay = false;
                }
            }
        }

        // Description message
        public void Description() {
            Console.WriteLine(); // blank space
            Console.WriteLine("Okay! Here is a description of the game:");
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            Console.WriteLine("| In this game is you against the computer and the game in based in four rounds. |");
            Console.WriteLine("| To the first round we will decide randomly who will start  and who was choose  |");
            Console.WriteLine("| will pick one dice between your dice of:                                       |");
            Console.WriteLine("| -> 6 sides / -> 8 sides / -> 12 sides / -> 20 sides                            |");
            Console.WriteLine("| After you roll the dice we will calculate who won the round.                   |");
            Console.WriteLine("| In the end the winner will be who has more round wins.                         |");
            Console.WriteLine("|--------------------------------------------------------------------------------|");
            PressEnter();

            // Function that will keep the user in the loop while he don't pree the Key <Enter>
            void PressEnter() {
                Console.WriteLine("Did you understood the rules? (if yes press <ENTER>)");

                if (Console.ReadKey().Key != ConsoleKey.Enter) {
                    PressEnter();
                }
                Console.WriteLine(); // blank space
            }
        }

        // Sorry message
        internal void Sorry() {
            Console.WriteLine(); // blank space
            Console.WriteLine("-- I understand that you don't want to play, Bye!! --");
        }

        // Goodbye message
        internal void End () {
            Console.WriteLine(); // blank space
            Console.WriteLine("Goodbye!");
            Console.WriteLine("|Coded by -->Pedro Melo<-- on 9/20/2024|");
        }

    }
}