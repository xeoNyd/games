using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cybersport.Models
{
    public class Manager
    {
        public int ManagerID { get; set; }

        [Required]
        public String Manager_name { get; set; }

        [Required]
        public String Manager_surname { get; set; }

        [Required]
        public String Manager_email{ get; set; }

        public int TeamID { get; set; }
        public Team team { get; set; }
    }
}
