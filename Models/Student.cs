using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Student : User
    {
        [Required]
        public bool IsBlocked { get; set; }
        [MaxLength(10)]
        public string ClassName { get; set; }
        public virtual Class Class { get; set; }
    }
}