using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Class
    {
        public Class(){ var StudentsList = new List<Student>(); }
        [Required]
        [MaxLength(10)]
        public string ClassName { get; set; }
        // Notice that ClassName is Not Null column. So you must assign Class with Student entity every time you add or update Student.
        [Required]
        public bool ExamMode { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}