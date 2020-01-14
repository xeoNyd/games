using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace cybersport.Models
{
    public class League
    {
        public int LeagueID { get; set; }

        [Required]
        public String Leag_name {get; set;}

        [Required]
        public int Leag_team_num { get; set; }

        [Required]
        public String Leag_Type { get; set; }

        [Required]
        public int prize_pool { get; set; }
        public int NameOfGameID { get; set; }
        public NameOfGame nameOfGame { get; set; }
        public ICollection<Team> teams { get; set; }

    }
}
