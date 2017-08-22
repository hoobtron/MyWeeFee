using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeeFee.Models
{
    public class User
    {
        [Required]
        // DatabaseGenerated attribute with None parameter specifies that primary key values are provided by the user rather than generated by the database
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Emailadresse")]
        // StringLength attribute sets the maximum length in the database and provides client side and server side validation 
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Vorname")]
        [StringLength(30, MinimumLength = 2)]
        public string Firstname { get; set; }
        [Required]
        [Display(Name = "Nachname")]
        [StringLength(20, MinimumLength = 2)]
        public string Surename { get; set; }
        [Required]
        [Display(Name = "Passwort")]
        [StringLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}