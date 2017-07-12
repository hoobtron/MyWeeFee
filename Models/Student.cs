using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Student : User
    {
        [Required]
        public bool IsBlocked { get; set; }
        [Required]
        public Class Class { get; set; }
    }
}