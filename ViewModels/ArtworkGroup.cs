using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGallery.ViewModels
{
    public class ArtworkGroup
    {
        public string DominantStyle { get; set; }

        public string ArtistName { get; set; }

        public int ArtworkCount { get; set; }

        public int ArtistCount { get; set; }
    }
}