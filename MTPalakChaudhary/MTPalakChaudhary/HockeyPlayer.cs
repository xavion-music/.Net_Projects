using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTPalakChaudhary
{
    public class HockeyPlayer : Player
    {
        public int Assists { get; set; }
        public int Goals { get; set; }

        public HockeyPlayer(string PlName, string TmName, int GamesNo, int assists, int goals) : base(PlName, TmName, GamesNo)
        {
            Assists = assists;
            Goals = goals;
        }

        public override int Points()
        {
            return Assists + (2 * Goals);
        }
    }
}