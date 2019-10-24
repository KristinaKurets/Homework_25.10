using System;
using System.Collections.Generic;
using System.Text;

namespace DndMonsters
{
    public class Monster
    {
        public string Name { get; set; }
        public Weapon Weapon { get; set; }
        public int ArmorClass { get; set; }
        public int AttackMod { get; set; }
        public int HitPoints { get; set; }
        public int Level { get; set; }
        public int DamageMode { get; set; }

        public Monster(string str)
        {
            Weapon = new Weapon();
            Weapon.Damage = new DamageDice();

            string[] parts = str.Split("***");
            Name = parts[0];
            ArmorClass = int.Parse(parts[1]);
            AttackMod = int.Parse(parts[2]);
            HitPoints = int.Parse(parts[3]);
            Level = int.Parse(parts[4]);
            Weapon.Name = parts[5];
            DamageMode = int.Parse(parts[6]);
            Weapon.Damage.Dices = int.Parse(parts[7]);
            Weapon.Damage.Sides = int.Parse(parts[8]);

        }
    }
    
}
