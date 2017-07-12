using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyWeeFee.Models
{
    public class Accesspoint
    {
        [Required]
        [MaxLength(20)]
        public string Location { get; set; }
        [Required]
        [MaxLength(20)]
        public string SSID { get; set; }
        [Required]
        [MaxLength(20)]
        public string Encryption { get; set; }
    }
}