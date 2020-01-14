using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace cybersport.Models
{
    public class NameOfGame
    {
        public int NameOfGameID { get; set; }

        [Remote("suchNameOfGameAlreadyExist", "NameOfGames", HttpMethod = "POST", ErrorMessage = "Such name of game is already exist in database.")]
        public String Name_of_Game { get; set; }

        [Required]
        public String Game_description { get; set; }
        public int GenreID { get; set; }
        public Genre genre { get; set; }

        public ICollection<PlayingGame> teams { get; set; }
    }
    
}

