using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPalakChaudhary
{
    public class BasketballPlayer : Player
    {
        public int FieldGoals { get; set; }
        public int ThreePointers { get; set; }

        public BasketballPlayer(string PlName, string TmName, int GamesNo, int fieldGoals, int threePointers) : base(PlName , TmName, GamesNo)
        {
            FieldGoals = fieldGoals;
            ThreePointers = threePointers;
        }

        public override int Points()
        {
            return FieldGoals + (2 * ThreePointers);
        }
    }
}



