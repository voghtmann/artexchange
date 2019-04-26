using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGallery.Models
{
    public class Patron
    {
        public int PatronID { get; set; }
        [Required]
        [Column("PatronName")]
        [Display(Name = "Owner"),StringLength(50, MinimumLength = 3)]
        public string PatronName { get; set; }
        [Display(Name = "Entity Type"), StringLength(50, MinimumLength = 2)]
        public string EntityType { get; set; }
        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        public string ContactPhone { get; set; }
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}