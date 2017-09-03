using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyWeeFee.Models
{
    public class Accesspoint
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage="{0} benötigt.")]
        [Display(Name = "Ort")]
        [StringLength(20, MinimumLength = 3)]
        public string Location { get; set; }
        
        [Required(ErrorMessage="{0} benötigt.")]
        [StringLength(20)]
        public string SSID { get; set; }

//        [Required(ErrorMessage="{0} benötigt.")]
        [Display(Name = "Verschlüsselung")]
        [StringLength(20)]
        public int Encryption { get; set; }

        public virtual APEncryption APEncryption { get; set; }
    }
}