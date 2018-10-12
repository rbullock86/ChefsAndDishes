using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Chefs.Models
{
    public class Dish
    {
        [Key]
        public int dishid { get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(45)]
        public string name { get; set; }

        [Required]
        [Range(1, 5)]
        public int tastiness { get; set; }

        [Required]
        [Range(0, 1000000000)]
        public int calories { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(255)]
        public string description { get; set; }

        [Required]
        public DateTime createdat { get; set; } = DateTime.Now;

        [Required]
        public DateTime updatedat { get; set; } = DateTime.Now;

        [Required]
        public int chefs_chefid {get; set;}

        [ForeignKey("chefs_chefid")]
        public Chef creator { get; set;}
    }
}