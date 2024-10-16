using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public abstract class Enemy {
        public DiceRoller dice = new DiceRoller();
        public int EnemyLife { get; set; }
        public abstract string EnemyName { get; }
        public abstract void TakeDamage(int damageTaken);
        public virtual int Attack() {
            return dice.Roll();
        }

        // Constructor initializes enemies life
        protected Enemy(int initialLife) {
            EnemyLife = initialLife;
        }

        // Method IsAlive check is enemy is alive
        public bool IsAlive() {
            return EnemyLife > 0;
        }
    }

    public class Knight : Enemy {
        public override string EnemyName { get; } = "Knight";

        public Knight() : base(30) { } // Class Knight initializes with 30 life points

        // Function TakeDamage
        public override void TakeDamage(int damageTaken) {
            EnemyLife -= damageTaken;
            Console.WriteLine($"{EnemyName} takes {damageTaken} damage. {EnemyName} has: {EnemyLife} life points");
            if (EnemyLife <= 0) {
                EnemyLife = 0;
            }
        }

        // Function Attack
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

        // Function TakeDamage
        public override void TakeDamage(int damageTaken) {
            EnemyLife -= damageTaken;
            Console.WriteLine($"{EnemyName} takes {damageTaken} damage. {EnemyName} has: {EnemyLife} life points");
            if (EnemyLife <= 0) {
                EnemyLife = 0;
            }
        }

        // Function Attack
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

        // Function TakeDamage
        public override void TakeDamage(int damageTaken) {
            EnemyLife -= damageTaken;
            Console.WriteLine($"{EnemyName} takes {damageTaken} damage. {EnemyName} has: {EnemyLife} life points");
            if (EnemyLife <= 0) {
                EnemyLife = 0;
            }
        }

        // Function Attack
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

        // Function TakeDamage
        public override void TakeDamage(int damageTaken) {
            EnemyLife -= damageTaken;
            Console.WriteLine($"{EnemyName} takes {damageTaken} damage. {EnemyName} has: {EnemyLife} life points");
            if (EnemyLife <= 0) {
                EnemyLife = 0;
            }
        }

        // Function Attack
        public override int Attack() {
            dice.NumberOfSides = 25;
            int attackDamage = dice.Roll();
            Console.WriteLine($"{EnemyName} threw a boomerang in you and deals {attackDamage} damage to you.");
            return attackDamage;
        }
    }

}