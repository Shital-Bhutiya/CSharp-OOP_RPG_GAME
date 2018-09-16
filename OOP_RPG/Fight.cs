using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        List<Monster> Monsters { get; set; }
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Monster monster { get; set; }
        public Fight(Hero hero, Game game)
        {
            this.Monsters = new List<Monster>();

            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20, 20);
            this.AddMonster("Aliga", 4, 7, 19, 15);
            this.AddMonster("Maniko", 3, 6, 18, 30);
            this.AddMonster("Vania", 8, 8, 15, 10);
            this.AddMonster("Bella", 8, 9, 21, 35);
            // ====== You can even add Blank Monster =====
            this.Monsters.Add(new Monster());

            var lastMonster = this.Monsters.Last();
            var secondMonster = this.Monsters[1];
            var lt20HPMonster = (from m in Monsters where m.CurrentHP < 20 select m).FirstOrDefault();
            var gt11SMonster = (from m in Monsters where m.Strength >= 11 select m).FirstOrDefault();
            var randomMonster = this.Monsters[new Random().Next(this.Monsters.Count - 1)];
            this.monster = randomMonster;
        }

        public void AddMonster(string name, int strength, int defense, int hp, int speed)
        {
            // Calling the constructor in the Monster class and adding monster to our monster list
            var monster = new Monster(name, strength, defense, hp, speed);
            this.Monsters.Add(monster);
        }

        public void Start()
        {
            Console.WriteLine("You've encountered a " + this.monster.Name + "! " + this.monster.Strength + " Strength/" + this.monster.Defense + " Defense/" +
            this.monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Run Away");
            Console.WriteLine("3. Regain HP");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.HeroTurn();
            }
            else if (input == "2")
            {
                this.RunAway();
            }
            else if (input == "3")
            {
                this.RegainHP();
            }
            else
            {
                this.game.Main();
            }
        }

        private void RegainHP()
        {
            if (this.hero.PotionBag.Count != 0)
            {
                this.hero.CurrentHP += this.hero.PotionBag[0].HP;
                Console.WriteLine("You got " + this.hero.PotionBag[0].HP + " HP");
                this.hero.PotionBag.RemoveAt(0);
            }
            else
            {
                Console.WriteLine("You don't have any portion to re gain HP");
            }
            this.Start();
        }

        public void RunAway()
        {
            if (this.hero.Speed > this.monster.Speed)
            {
                this.Win();
            }
            else
            {
                Console.WriteLine("You Don't Have Enough speed to run away");
                this.Start();
            }
        }

        public void HeroTurn()
        {
            var compare = hero.Strength - monster.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                monster.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                monster.CurrentHP -= damage;
            }
            Console.WriteLine("You did " + damage + " damage!");

            if (monster.CurrentHP <= 0)
            {
                this.Win();
            }
            else
            {
                this.MonsterTurn();
            }
        }

        public void MonsterTurn()
        {
            int damage;
            var compare = monster.Strength - hero.Defense;
            if (compare <= 0)
            {
                damage = 1;
                hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                hero.CurrentHP -= damage;
            }
            Console.WriteLine(monster.Name + " does " + damage + " damage!");
            if (hero.CurrentHP <= 0)
            {
                this.Lose();
            }
            else
            {
                this.Start();
            }
        }

        public void Win()
        {
            hero.Gold += monster.Gold;
            Console.WriteLine(monster.Gold == 0 ? "Oops Your Bad Luck" : "Congratulation! You won " + monster.Gold + " Gold");
            Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
            game.Main();
        }

        public void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }

    }

}
