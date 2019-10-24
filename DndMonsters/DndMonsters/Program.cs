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
            var MaxArmor = monsters.OrderBy(x => x.ArmorClass).Max(x => x.ArmorClass);
            Console.WriteLine($"\nMonster with the max armor class is {MaxArmor}");
        }
    }
}
