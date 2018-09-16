using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Game
    {
        public Hero hero { get; set; }
        Shop Shop { get; set; }
        public Game()
        {
            this.hero = new Hero(this);
            this.Shop = new Shop(this, this.hero);
        }

        public void Start()
        {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            this.hero.Name = Console.ReadLine();
            Console.WriteLine("Hello " + hero.Name);
            this.Main();
        }

        public void Main()
        {
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Shop");
            Console.WriteLine("5. Equip An Item");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.Stats();
            }
            else if (input == "2")
            {
                this.Inventory();
            }
            else if (input == "3")
            {
                this.Fight();
            }
            else if (input == "4")
            {
                this.Shop.Menu();
            }
            else if (input == "5")
            {
                this.hero.equipItem();
            }
            else
            {
                return;
            }
        }

        public void Stats()
        {
            hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }

        public void Inventory()
        {
            hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }

        public void Fight()
        {
            var fight = new Fight(this.hero, this);
            fight.Start();
        }
    }
}