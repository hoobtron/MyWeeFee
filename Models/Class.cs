using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Class
    {
        [Required]
        [MaxLength(10)]
        public string ClassName { get; set; }
        [Required]
        public bool ExamMode { get; set; }
        public List<Student> Students { get; set; }
    }
}