using System;
namespace OOP_RPG
{
    public class Weapon : IItem
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Weapon(string name, int originalvalue, int resellvalue,int strength)
        {
            this.Name = name;
            this.Strength = strength;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}