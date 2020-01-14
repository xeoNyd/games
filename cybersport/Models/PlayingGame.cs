using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cybersport.Models
{
    public class PlayingGame
    {
        public int PlayingGameID { get; set;}

        public int NameOfGameID { get; set; }
        public NameOfGame nameOfGame { get; set; }
        public int TeamID { get; set; }
        public Team team { get; set; }
    }
}
