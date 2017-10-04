using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game.Models
{
    public class NonHumanEntity
    {
        public int NonHumanId { get; set; }
        public string Name { get; set; }
        public string PlayerType { get; set; }
        public int Life { get; set; }
        public string Gender { get; set; }
        public int Strength { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Gold { get; set; }
    }
}
