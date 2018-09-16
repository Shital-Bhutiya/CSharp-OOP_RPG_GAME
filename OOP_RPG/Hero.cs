using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero(Game game)
        {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.game = game;
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 0;
            this.Speed = 5;
        }

        // These are the Properties of our Class.
        public int Gold { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Speed { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public Game game { get; set; }


        public List<Weapon> WeaponsBag { get; set; }
        public List<Potion> PotionBag { get; set; }
        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Gold Points: " + this.Gold);
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");
            foreach (var w in this.WeaponsBag)
            {
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }
            Console.WriteLine("Armor: ");
            foreach (var a in this.ArmorsBag)
            {
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }
            Console.WriteLine("Potion: ");
            foreach (var a in this.PotionBag)
            {
                Console.WriteLine(a.Name + " of " + a.HP + " HP");
            }
        }
        public void equipItem()
        {
            Console.WriteLine("Enter your Choise for Item or press r to return");
            Console.WriteLine("1.Weapons");
            Console.WriteLine("2.Armors");
            Console.WriteLine("3.Potion");
            var Item = Console.ReadLine();
            switch (Item)
            {
                case "1":
                    if (this.WeaponsBag.Count > 0)
                    {
                        Console.WriteLine("Enter Number of the item Or press r to return menu");
                        for (int i = 0; i < this.WeaponsBag.Count; i++)
                        {
                            Console.WriteLine((i + 1) + " " + this.WeaponsBag[i].Name + " " + this.WeaponsBag[i].Strength + "of Strength");
                        }
                        var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (inputNumber < this.WeaponsBag.Count)
                        {
                            this.EquipWeapon(inputNumber);
                            this.game.Main();

                        }
                        else
                        {
                            this.game.Main();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You Don't Have any Weapons to use");
                        this.game.Main();
                    }
                    break;
                case "2":
                    if (this.ArmorsBag.Count > 0)
                    {
                        Console.WriteLine("Enter Number of the item Or press r to return menu");
                        for (int i = 0; i < this.ArmorsBag.Count; i++)
                        {
                            Console.WriteLine((i + 1) + " " + this.ArmorsBag[i].Name + " " + this.ArmorsBag[i].Defense + "of Defence");
                        }
                        var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (inputNumber < this.ArmorsBag.Count)
                        {
                            this.EquipArmor(inputNumber);
                            this.game.Main();

                        }
                        else
                        {
                            this.game.Main();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You Don't Have any Armor to use");
                        this.game.Main();
                    }
                    break;
                case "3":
                    if (this.PotionBag.Count > 0)
                    {
                        Console.WriteLine("Enter Number of the item Or press r to return menu");
                        for (int i = 0; i < this.PotionBag.Count; i++)
                        {
                            Console.WriteLine((i + 1) + " " + this.PotionBag[i].Name + " $" + this.PotionBag[i].ResellValue);
                        }
                        var inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
                        if (inputNumber < this.PotionBag.Count)
                        {
                            this.CurrentHP += this.PotionBag[inputNumber].HP;
                            this.PotionBag.RemoveAt(inputNumber);
                            this.game.Main();

                        }
                        else
                        {
                            this.game.Main();
                        }
                    }
                    else
                    {
                        Console.WriteLine("You Don't Have any Potion to use");
                        this.game.Main();
                    }
                    break;
                default:
                    this.game.Main();
                    break;
            }


        }

        public void EquipWeapon(int WeaponIndex)
        {
            if (WeaponsBag.Any())
            {
                if (this.EquippedWeapon == null)
                {
                    this.EquippedWeapon = this.WeaponsBag[WeaponIndex];
                    this.Strength += this.EquippedWeapon.Strength;
                    this.WeaponsBag.RemoveAt(WeaponIndex);
                }
                else
                {
                    this.Strength -= this.EquippedWeapon.Strength;
                    this.WeaponsBag.Add(this.EquippedWeapon);
                    this.EquippedWeapon = this.WeaponsBag[WeaponIndex];
                    this.Strength += this.EquippedWeapon.Strength;
                    this.WeaponsBag.RemoveAt(WeaponIndex);
                }
            }
        }

        public void EquipArmor(int ArmorIndex)
        {
            if (ArmorsBag.Any())
            {
                if (this.EquippedArmor == null)
                {
                    this.EquippedArmor = this.ArmorsBag[ArmorIndex];
                    this.Defense += this.EquippedArmor.Defense;
                    this.ArmorsBag.RemoveAt(ArmorIndex);
                }
                else
                {
                    this.Defense -= this.EquippedArmor.Defense;
                    this.ArmorsBag.Add(this.EquippedArmor);
                    this.EquippedArmor = this.ArmorsBag[ArmorIndex];
                    this.Defense += this.EquippedArmor.Defense;
                    this.WeaponsBag.RemoveAt(ArmorIndex);
                }
            }
        }
    }
}