using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cybersport.Models
{
    public class Player
    {
        public int PlayerID { get; set; }

        [Required]
        public String Player_name { get; set; }

        [Required]
        public String Player_nickname { get; set; }

        [Required]
        public String Player_surname { get; set; }

        [Required]
        public String Player_email { get; set; }

        [Required]
        public int Player_rate{ get; set; }


        public int TeamID { get; set; }
        public Team team { get; set; }
    }
}
