using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCGallery.Models
{
    public class Exhibition
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExhibitionID { get; set; }
        [Display(Name = "Exhibition"), StringLength(50, MinimumLength = 3)]
        public string ExName { get; set; }
        [Required]
        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> FinishDate { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Venue { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string City { get; set; }
        [Display(Name = "Summary"), StringLength(1000, MinimumLength = 10)]
        public string ExDesc { get; set; }

        
        public virtual ICollection<Artwork> Artworks { get; set; }
    }
}