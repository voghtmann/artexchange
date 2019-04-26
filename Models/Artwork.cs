using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGallery.Models
{
    public class Artwork
    {
        public int ArtworkID { get; set; }
        public int ArtistID { get; set; }
        public int PatronID { get; set; }
        public int ExhibitionID { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        public Nullable<int> Year { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Likes { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        //[DisplayFormat(NullDisplayText = "Withheld")]
        [Display(Name = "Current Value")]
        [DataType(DataType.Currency)]
        public decimal CurrentValue { get; set; }

        public string Medium { get; set; }
       

        public virtual Artist Artist { get; set; }
        public virtual Exhibition Exhibition { get; set; }
        public virtual Patron Patron { get; set; }

    }
}