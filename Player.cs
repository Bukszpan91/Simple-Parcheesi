using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chinczyk
{
    public class Player
    {
        public Player(int id)
        {
            playerID = id;
            startposition = 20 * (id - 1) + 1;
            pawnposition = startposition;
        }
        public int playerID;
        public int startposition;
        public int pawnposition;
        public int progress;
    }
}
