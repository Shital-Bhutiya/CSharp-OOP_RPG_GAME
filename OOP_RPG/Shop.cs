using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        public Hero hero { get; set; }
        public List<Armor> armor { get; set; }
        public List<Potion> potion { get; set; }
        public List<Weapon> weapons { get; set; }
        public Game game { get; set; }
        public Shop(Game game, Hero hero)
        {
            this.weapons = new List<Weapon>();
            this.potion = new List<Potion>();
            this.armor = new List<Armor>();
            this.game = game;
            this.hero = hero;
            this.weapons.Add(new Weapon("Sword", 10, 2, 3));
            this.weapons.Add(new Weapon("Axe", 12, 3, 4));
            this.weapons.Add(new Weapon("Longsword", 20, 5, 7));

            this.armor.Add(new Armor("Wooden Armor", 10, 2, 3));
            this.armor.Add(new Armor("Metal Armor", 20, 5, 7));

            this.potion.Add(new Potion("Healing Potion", 10, 10, 5));
        }
        public void Menu()
        {
            Console.WriteLine("Welcome to My Shop What you want?");
            Console.WriteLine("1.Buy Item");
            Console.WriteLine("2.Sell Item");
            Console.WriteLine("3.Return to the game");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.ShowInventory();
            }
            else if (input == "2")
            {
                this.BuyfromUser();
            }
            else
            {
                this.game.Main();
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("What you want to buy?");
            Console.WriteLine("1.Weapons");
            Console.WriteLine("2.Armors");
            Console.WriteLine("3.Potions");
            var input = Console.ReadLine();
            if (input == "1")
            {
                Console.WriteLine("Enter Number of the item Or press r to return menu");
                for (int i = 0; i < weapons.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + weapons[i].Name + " $" + weapons[i].OriginalValue);
                }
                var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                if (inputNumber < this.weapons.Count)
                {
                    this.shell(inputNumber, "weapons");
                }
                else
                {
                    this.Menu();
                }
            }
            else if (input == "2")
            {
                for (int i = 0; i < armor.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + armor[i].Name + " $" + armor[i].OriginalValue);
                }
                var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                if (inputNumber < this.armor.Count)
                {
                    this.shell(inputNumber, "armor");
                }
                else
                {
                    this.Menu();
                }

            }
            else if (input == "3")
            {
                for (int i = 0; i < potion.Count; i++)
                {
                    Console.WriteLine((i + 1) + " " + potion[i].Name + " $" + potion[i].OriginalValue);
                }
                var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                if (inputNumber < this.potion.Count)
                {
                    this.shell(inputNumber, "potion");
                }
                else
                {
                    this.Menu();
                }
            }
            else
            {
                this.Menu();
            }
        }

        public void shell(int inputNumber, string name)
        {
            if (name == "weapons")
            {
                var price = this.weapons[inputNumber].OriginalValue;
                if (this.hero.Gold >= price)
                {
                    this.hero.Gold -= price;
                    this.hero.WeaponsBag.Add(this.weapons[inputNumber]);
                }
                else
                {
                    Console.WriteLine("Aeeeee You don't have enough money");
                }
            }
            else if (name == "armor")
            {
                var price = this.armor[inputNumber].OriginalValue;
                if (this.hero.Gold >= price)
                {
                    this.hero.Gold -= price;
                    this.hero.ArmorsBag.Add(this.armor[inputNumber]);
                }
                else
                {
                    Console.WriteLine("Aeeeee You don't have enough money");
                }
            }
            else if (name == "potion")
            {
                var price = this.potion[inputNumber].OriginalValue;
                if (this.hero.Gold >= price)
                {
                    this.hero.Gold -= price;
                    this.hero.PotionBag.Add(this.potion[inputNumber]);
                }
                else
                {
                    Console.WriteLine("Aeeeee You don't have enough money");
                }
            }
            this.Menu();
        }

        public void BuyfromUser()
        {
            Console.WriteLine("What you want to sell?");
            Console.WriteLine("1.Weapons");
            Console.WriteLine("2.Armors");
            Console.WriteLine("3.Potions");
            var input = Console.ReadLine();
            if (input == "1")
            {
                if (this.hero.WeaponsBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.WeaponsBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.WeaponsBag[i].Name + " $" + this.hero.WeaponsBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.WeaponsBag.Count)
                    {
                        this.shellFromUser(inputNumber, "weapons");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any weapons to sell");
                    this.Menu();
                }

            }
            else if (input == "2")
            {
                if (this.hero.ArmorsBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.ArmorsBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.ArmorsBag[i].Name + " $" + this.hero.ArmorsBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.ArmorsBag.Count)
                    {
                        this.shellFromUser(inputNumber, "armor");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any Armors to sell");
                    this.Menu();
                }
            }
            else if (input == "3")
            {
                if (this.hero.PotionBag.Count > 0)
                {
                    Console.WriteLine("Enter Number of the item Or press r to return menu");
                    for (int i = 0; i < this.hero.PotionBag.Count; i++)
                    {
                        Console.WriteLine((i + 1) + " " + this.hero.PotionBag[i].Name + " $" + this.hero.PotionBag[i].ResellValue);
                    }
                    var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (inputNumber < this.hero.PotionBag.Count)
                    {
                        this.shellFromUser(inputNumber, "potion");
                    }
                    else
                    {
                        this.Menu();
                    }
                }
                else
                {
                    Console.WriteLine("You don't have any Potion to sell");
                    this.Menu();
                }
            }
            else
            {
                this.Menu();
            }
        }

        public void shellFromUser(int inputNumber, string bag)
        {
            if (bag == "weapons")
            {
                this.hero.Gold += this.hero.WeaponsBag[inputNumber].ResellValue;
                this.hero.WeaponsBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the weapon");
                this.Menu();
            }
            else if (bag == "armor")
            {
                this.hero.Gold += this.hero.ArmorsBag[inputNumber].ResellValue;
                this.hero.ArmorsBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the Armor");
                this.Menu();
            }
            else
            {
                this.hero.Gold += this.hero.PotionBag[inputNumber].ResellValue;
                this.hero.PotionBag.RemoveAt(inputNumber);
                Console.WriteLine("You successfully sold the Potion");
                this.Menu();
            }
        }
    }
}
