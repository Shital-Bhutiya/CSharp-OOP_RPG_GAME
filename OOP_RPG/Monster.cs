using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public int Gold { get; set; }
        // constructor with default perameters
        public Monster(string name = "Bhuro", int strength = 10, int defence = 20, int hp = 10)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defence;
            this.OriginalHP = hp;
            this.CurrentHP = hp;
            this.Gold = new Random().Next(0, 100);
        }
    }
}