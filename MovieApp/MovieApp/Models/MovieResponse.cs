using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        [Required]
        public bool Edited { get; set; }
        public string Lentto { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

        //foreign key relationship
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
