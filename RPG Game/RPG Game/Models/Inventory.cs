using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class Inventory
    {
        public int Inventory_Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string SubType { get; set; }
        public decimal Weight { get; set; }
        public int StrengthProp { get; set; }
        public int AttackProp { get; set; }
        public int DefenseProp { get; set; }
        public int MagicProp { get; set; }
    }
}
