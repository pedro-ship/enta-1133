using _02_LabAssigment_By_PedroMelo.Scripts;

namespace _02_LabAssigment_By_PedroMelo {
    internal class Program {
        static void Main(string[] args) {

            // creating instance gameManagerInstance
            GameManager gameManagerInstance = new GameManager();

            // creating a loop to start the game
            for (int x = 1; x <= 10; x++) {
                Console.WriteLine("Press any Key to start the game!");
                Console.ReadKey();
                Console.WriteLine(" "); // blank space

                // calling function GameStart
                gameManagerInstance.GameStart();
            }
        }

    }

}