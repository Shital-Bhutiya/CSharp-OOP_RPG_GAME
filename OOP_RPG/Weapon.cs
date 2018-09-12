using System;
namespace OOP_RPG
{
    public class Weapon : IItem
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Weapon(string name, int strength, int originalvalue, int resellvalue)
        {
            this.Name = name;
            this.Strength = strength;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}