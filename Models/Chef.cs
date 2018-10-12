using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Chefs.Models
{
    public class Chef
    {
        [Key]
        public int chefid { get; set; }

        [Required]
        [MinLength(2)]
        public string firstname { get; set; }

        [Required]
        [MinLength(2)]
        public string lastname { get; set; }

        [Required]
        [Is18Attribute]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM0dd}", ApplyFormatInEditMode = true)]
        public DateTime dateofbirth { get; set; }

        public DateTime createdat { get; set; } = DateTime.Now;
        public DateTime updatedat { get; set; } = DateTime.Now;

        public List<Dish> Dishes { get; set; }

        public static int GetAge(DateTime birthday)
        {
            return Convert.ToInt32((DateTime.Now - birthday).Days/365.25);
        }


        // custom validator
        public class Is18Attribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                TimeSpan EighteenYears = new TimeSpan(Convert.ToInt32(365.25*18), 0, 0, 0);
                DateTime? birthday = (DateTime) value;
                if((DateTime.Now - birthday) < EighteenYears){
                    return new ValidationResult("Sorry, must be at least 18 to join Chef-Force.");
                }
                return ValidationResult.Success;
            }
        }
    }
}