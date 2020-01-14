using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace cybersport.Models
{
    public class Game
    {
        public int GameID { get; set; }
        [Required]
        public String Game_result { get; set; }
        
        public int NameOfGameID { get; set;}
        public NameOfGame nameOfGame { get; set; }
        public int Team1ID { get; set; }
        public Team team1 { get; set; }

        public int Team2ID { get; set; }
        public Team team2 { get; set; }
    }
}
