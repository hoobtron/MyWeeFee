using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    public class Class
    {
        public string ClassName { get; set; }
        public bool ExamMode { get; set; }
        public List<Student> Students { get; set; }
    }
}