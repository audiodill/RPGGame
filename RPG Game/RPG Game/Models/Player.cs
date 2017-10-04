using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class Player
    {
        public int Player_Id { get; set; }
        public string Name { get; set; }
        public int Life { get; set; }
        public string PlayerType { get; set; }
        public string Gender { get; set; }
        public int XP { get; set; }
        public int Strength { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
    }
}
