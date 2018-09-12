using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    class Shop
    {
        public List<Armor> armor { get; set; }
        public List<Potion> potion { get; set; }
        public List<Weapon> weapons { get; set; }

        public Shop()
        {
            this.weapons = new List<Weapon>();
            this.potion = new List<Potion>();
            this.armor = new List<Armor>();
        }

    }
}
