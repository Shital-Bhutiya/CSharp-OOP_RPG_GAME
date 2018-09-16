using System;
namespace OOP_RPG
{
    public class Armor : IItem
    {
        public string Name { get; set; }
        public int Defense { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }

        public Armor(string name, int originalvalue, int resellvalue, int defense)
        {
            this.Name = name;
            this.Defense = defense;
            this.OriginalValue = originalvalue;
            this.ResellValue = resellvalue;
        }
    }
}