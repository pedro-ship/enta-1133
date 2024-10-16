using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public abstract class Enemy {
        internal DiceRoller dice = new DiceRoller();
        public abstract string EnemyName { get; }
        public int EnemyLife { get; set; }
        public abstract int Attack();

        // Method that return a random enemy of enemyList
        public static Enemy RandomEnemy() {
            Random random = new Random();
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
            return enemyList[random.Next(enemyList.Count)]; // Return a random enemy of enemyList
        }

        // Method IsAlive return if enemy is alive
        public bool IsAlive() {
            if (EnemyLife > 0) {
                return true;
            }
            else {
                return false;
            }
        }

        // Create function TakeDamage that deals the damage on the enemy
        public void TakeDamage(int damageTaken) {
            EnemyLife -= damageTaken;

            // If loop that reassign the EnemyLife to 0 if the EnemyLife is less or equal 0
            if (EnemyLife <= 0) {
                EnemyLife = 0;
            }
            Console.WriteLine($"{EnemyName} takes {damageTaken} damage. {EnemyName} has: {EnemyLife} life points");
        }

        // Constructor initializes enemies life
        protected Enemy(int initialLife) {
            EnemyLife = initialLife; // Assign initialLife to EnemyLife
        }
    }

    public class Knight : Enemy {
        public override string EnemyName { get; } = "Knight";

        public Knight() : base(30) { } // Class Knight initializes with 30 life points

        // Method Attack return the random value of method Attack
        public override int Attack() {
            dice.NumberOfSides = 10;
            int attackDamage = dice.Roll();
            Console.WriteLine($"{EnemyName} attacked and deals {attackDamage} damage to you.");
            return attackDamage;
        }
    }

    public class Bear : Enemy {
        public override string EnemyName { get; } = "Bear";

        public Bear() : base(35) { } // Class Bear initializes with 35 life points

        // Method Attack return the random value of method Attack
        public override int Attack() {
            dice.NumberOfSides = 14;
            int attackDamage = dice.Roll();
            Console.WriteLine($"{EnemyName} bitted you and deals {attackDamage} damage to you.");
            return attackDamage;
        }
    }

    public class WhiteSnow : Enemy {
        public override string EnemyName { get; } = "White Snow";

        public WhiteSnow() : base(40) { } // Class WhiteSnow initializes with 40 life points

        // Method Attack return the random value of method Attack
        public override int Attack() {
            dice.NumberOfSides = 16;
            int attackDamage = dice.Roll();
            Console.WriteLine($"{EnemyName} poisoned you and deals {attackDamage} damage to you.");
            return attackDamage;
        }
    }

    public class Batman : Enemy {
        public override string EnemyName { get; } = "Batman";

        public Batman() : base(60) { } // Class Batman initializes with 50 life points

        // Method Attack return the random value of method Attack
        public override int Attack() {
            dice.NumberOfSides = 25;
            int attackDamage = dice.Roll();
            Console.WriteLine($"{EnemyName} threw a boomerang in you and deals {attackDamage} damage to you.");
            return attackDamage;
        }
    }

}