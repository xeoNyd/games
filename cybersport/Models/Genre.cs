using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cybersport.Models
{
    public class Genre : IValidatableObject
    {
        public Genre(int genreID, string genre_name, string genre_description)
        {
            GenreID = genreID;
            Genre_name = genre_name;
            Genre_description = genre_description;
        }

        public Genre()
        {
        }

        public int GenreID { get; set; }
        
        [Remote("suchGameAlreadyExist", "Genres", HttpMethod = "POST", ErrorMessage = "Such game is already exist in database.")]
        public String Genre_name { get; set; }

        [Required]
        public String Genre_description { get; set; }

        public ICollection<Game> games{ get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Genre_name))
            {
                errors.Add(new ValidationResult("You can not create group without name."));
            }
            return errors;
        }
    }
}
