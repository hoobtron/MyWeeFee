using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeeFee.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage="{0} benötigt.")]
        [Display(Name = "Vorname")]
        [StringLength(30, MinimumLength = 2)]
        public string Firstname { get; set; }

        [Required(ErrorMessage="{0} benötigt.")]
        [Display(Name = "Nachname")]
        [StringLength(20, MinimumLength = 2)]
        public string Surename { get; set; }
        
        [Required(ErrorMessage="{0} benötigt.")]
        // DatabaseGenerated attribute with None parameter specifies that primary key values are provided by the user rather than generated by the database
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Emailadresse", Description = "wird als eindeutiger Bezeichner genutzt")]
        // StringLength attribute sets the maximum length in the database and provides client side (unlike MaxLength) and server side validation 
        [StringLength(50)]
        [EmailAddress]
        // Remote Validation if email is used already 
        [Microsoft.AspNetCore.Mvc.Remote(action: "IsEmailAvailable", controller: "Admins", AdditionalFields = "InitialEmail")]
        public string Email { get; set; }

        // only for remote comparing purpose - NotMapped (will not appear as DB field)
        [NotMapped]
        [Microsoft.AspNetCore.Mvc.HiddenInput]
        public string InitialEmail { get; set; }
        
        [Required(ErrorMessage="{0} benötigt.")]
        [Display(Name = "Passwort")]
        [StringLength(20, ErrorMessage = "Das {0} muss mindestens {2} Zeichen lang sein.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
/*
        // only for comparing purpose - NotMapped (will not appear as DB field)
        [NotMapped]
        [Display(Name = "Passwort bestätigen")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwort stimmt nicht überein.")]
        public string ConfirmPassword { get; set; }
*/
    }
}