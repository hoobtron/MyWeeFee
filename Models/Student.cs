using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    public class Student : User
    {
        public bool IsBlocked { get; set; }
        public Class Class { get; set; }
    }
}