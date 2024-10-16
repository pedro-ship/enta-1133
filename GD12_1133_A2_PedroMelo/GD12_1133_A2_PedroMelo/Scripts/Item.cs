using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD12_1133_A2_PedroMelo.Scripts {
    public abstract class Item {
        public DiceRoller dice = new DiceRoller();
        public abstract string ItemName { get; }
        public abstract bool IsUsable { get; }
    }

    public abstract class Weapon : Item {
        public override bool IsUsable { get; } = false;
        public abstract void WeaponDamage(ref int damage);
    }

    public abstract class Consumable : Item {
        public override bool IsUsable { get; } = true;
        public abstract int GiveHeal();
    }

    public class Dagger : Weapon {
        public override string ItemName { get; } = "Dagger";

        public override void WeaponDamage(ref int damage) {
            dice.NumberOfSides = 8;
            damage = dice.Roll();
        }
    }

    public class LongSword : Weapon {
        public override string ItemName { get; } = "Long Sword";

        public override void WeaponDamage(ref int damage) {
            dice.NumberOfSides = 12;
            damage = dice.Roll();
        }
    }

    public class LightSaber : Weapon {
        public override string ItemName { get; } = "Light Saber";

        public override void WeaponDamage(ref int damage) {
            dice.NumberOfSides = 20;
            damage = dice.Roll();
        }
    }

    public class SupermanPower : Weapon {
        public override string ItemName { get; } = "Superman Power";

        public override void WeaponDamage(ref int damage) {
            dice.NumberOfSides = 40;
            damage = dice.Roll();
        }
    }

    public class HealPotion : Consumable {
        public override string ItemName { get; } = "Heal Potion";
        public override int GiveHeal() {
            dice.NumberOfSides = 12;
            int healGiven = dice.Roll();
            return healGiven;
        }
    }

}