using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeeFee.Models
{
    public class Class
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [StringLength(10, MinimumLength = 3)]
        public string ClassName { get; set; }
        // Notice that ClassName is Not Null column. So you must assign Class with Student entity every time you add or update Student.
        
        [Required]
        [Display(Name = "Klausurmodus")]
        public bool ExamMode { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}