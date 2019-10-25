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
            Console.WriteLine($"\n\nMonster with the max armor class is {MaxArmor}");

            //Monsters with claws:
            var Claws = monsters.Where(x => x.Weapon.Name == "Claws");
            Console.WriteLine("\nThere are list of monsters with claws:");
            foreach (var monster in Claws)
            {
                Console.Write($"{ monster.Name} ");
            }

            //First monster with 2<level<4
            var monster1 = monsters.FirstOrDefault(x => x.Level > 2 && x.Level < 4);
            Console.WriteLine($"\n\nThe first monster with level more then 2 and less then 4 is {monster1.Name}");
        }
    }
}
