using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class User
    {
        [Required]
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MaxLength(30)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(40)]
        public string Surename { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}