using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cybersport.Models
{
    public class Team
    {
        public int TeamID { get; set; }

        [Required]
        public String Team_name { get; set; }


        public ICollection<PlayingGame> games { get; set; }
        public ICollection<Player> players { get; set; }
        public ICollection<Manager> manager { get; set; }
    }
}
