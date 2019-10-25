using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DndMonsters
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Monster> monsters = new List<Monster>();
            var weapon = new Weapon();
            weapon.Damage = new DamageDice();
            using (StreamReader sr = File.OpenText("monsters.txt"))
            {
                while (!sr.EndOfStream)
                {
                    monsters.Add(new Monster(sr.ReadLine()));
                    //string line = sr.ReadToEnd();
                    //Console.WriteLine(line);
                }
            }

            //List of monsters:
            Console.Write($"List of monsters: ");
            foreach (var monster in monsters.Select(x => new { name = x.Name }))
            {
                Console.Write($"{monster.name} ");
            }
            
            //Max armor class:
            var MaxArmor = monsters.OrderBy(x => x.ArmorClass).Max(x => (x.ArmorClass, x.Name));
            Console.WriteLine($"\n\nMonster with the max armor class is {MaxArmor.Name} - {MaxArmor.ArmorClass}");

            //Monsters with claws:
            var Claws = monsters.Where(x => x.Weapon.Name == "Claws");
            Console.WriteLine("\nThere are list of monsters with claws:");
            foreach (var monster in Claws)
            {
                Console.Write($"{ monster.Name} ");
            }

            //First monster with 2<level<4
            var monster1 = monsters.FirstOrDefault(x => x.Level > 2 && x.Level < 4);
            Console.WriteLine($"\n\nThe first monster with 3 level is {monster1.Name}");

            //Monster's damage:
            Console.WriteLine($"\nAll monster's damage: ");
            foreach (var monster in monsters.Select(x => new { name = x.Name, dice = x.Weapon.Damage.Dices, side = x.Weapon.Damage.Sides, damagemode = x.DamageMode}))
            {
                Console.WriteLine($"{monster.name} {monster.dice}d{monster.side}+{monster.damagemode} ");
            }

            //Max damage:
            var MaxDamage = monsters.OrderBy(x => x.DamageMode).Max(x => (x.Weapon.Damage.Dices * x.Weapon.Damage.Sides + x.DamageMode, x.Name) );
            Console.WriteLine($"\nMax damage has {MaxDamage.Name} - {MaxDamage.Item1}");

            //Average damage:
            foreach (var monster in monsters.Select(x => new { avDamage = (x.Weapon.Damage.Dices * x.Weapon.Damage.Sides + x.DamageMode) / 2, name = x.Name } ))
            {
                Console.WriteLine($"Average damage of {monster.name} is {monster.avDamage}");
            }

            //Sorting
            var sorted = monsters.OrderBy(x => x.Level);
            sorted = monsters.OrderBy(x=>x.Level).ThenBy(x => x.HitPoints);
            foreach (var monster in sorted)
            {
                Console.WriteLine($"{ monster.Name}, {monster.Level} level, has {monster.HitPoints} hitpoints");
            }

            //Summ of hitpoints
            var hitpoints = monsters.Where(x => x.Level == 1).Sum(x=> x.HitPoints);
            Console.WriteLine($"\nThe sum of the hit points of all the first level's monsters is {hitpoints}");
        }
    }
}
