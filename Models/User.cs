using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MyWeeFee.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Surename { get; set; }
        public string Password { get; set; }
    }
}