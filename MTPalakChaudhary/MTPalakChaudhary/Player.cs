using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MTPalakChaudhary
{
        public abstract class Player
        {
            public string PlName { get; set; }
            public int GamesNo { get; set; }
            public string TmName { get; set; }
            

            public Player(string PN, string TN, int GN)
            {
                PlName = PN;
                GamesNo = GN;
                TmName = TN;
                
            }

            public abstract int Points();
            //return Points();
        }
    }



