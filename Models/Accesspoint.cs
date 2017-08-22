using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeeFee.Models
{
    public class Accesspoint
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Ort (eindeutige Benennung)")]
        [StringLength(20, MinimumLength = 3)]
        public string Location { get; set; }
        [Required]
        [StringLength(20)]
        public string SSID { get; set; }
        [Required]
        [Display(Name = "Verschlüsselung")]
        [StringLength(20)]
        public string Encryption { get; set; }
    }
}