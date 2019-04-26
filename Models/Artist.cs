using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGallery.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        [Required]
        [StringLength(50, MinimumLength =2)]
        [Column("ArtistName")]
        [Display(Name = "Artist")]
        public string ArtistName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birth { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> Death { get; set; }
        [Display(Name = "Country of Origin")]
        public string CountryOfOrigin { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = " Dominant Style cannot be longer than 50 characters.")]
        [Display(Name = "Dominant Style")]
        public string DominantStyle { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Biography")]
        public string ArtistDesc { get; set; }
        [Display(Name = "Image")]
        public string ArtistUrl { get; set; }

        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}