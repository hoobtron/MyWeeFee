using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeeFee.Models
{
    public class Logitem
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Datum/Zeit")]
        // initializing an auto-implemented property (alternatively: set as default value in db-context)
        public System.DateTime Created { get; set; } = System.DateTime.UtcNow.ToLocalTime();

        [Required]
        [Display(Name = "User-Email")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Aktion")]
        public string Action { get; set; }
    }
}