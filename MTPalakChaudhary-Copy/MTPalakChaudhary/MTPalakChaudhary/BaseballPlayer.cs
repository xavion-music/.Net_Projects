using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPalakChaudhary
{
    public class BaseballPlayer : Player
    {
        public int Runs { get; set; }
        public int HomeRuns { get; set; }

        public BaseballPlayer(string PlName, string TmName, int GamesNo, int runs, int homeRuns) : base(PlName, TmName, GamesNo)
        {
            Runs = runs;
            HomeRuns = homeRuns;
        }

        public override int Points()
        {
            return Runs + (2 * HomeRuns);
        }
    }
}


