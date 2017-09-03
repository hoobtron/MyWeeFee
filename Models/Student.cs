using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Student : User
    {
        [Required]
        [Display(Name = "Gesperrt")]
        public bool IsBlocked { get; set; }
        
        [Display(Name = "Klasse")]
        [StringLength(10)]
        public string ClassId { get; set; }

        public virtual Class Class { get; set; }
    }
}