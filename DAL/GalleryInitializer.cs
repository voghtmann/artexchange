using MVCGallery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCGallery.DAL
{
    public class GalleryInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GalleryContext>
    {
        protected override void Seed(GalleryContext context)
        {
            var artists = new List<Artist>
            {
            new Artist{ArtistID=1, ArtistName="John Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Impressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=2, ArtistName="Jimbo Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="EXpressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=3, ArtistName="Mike Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Cubism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=4, ArtistName="Sally Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Cubism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=5, ArtistName="Philip Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Impressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" }
            };

            artists.ForEach(a => context.Artists.Add(a));
            context.SaveChanges();

            var exhibitions = new List<Exhibition>
            {
            new Exhibition{ExhibitionID=1,ExName="Blue",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"},
            new Exhibition{ExhibitionID=2,ExName="Red",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"},
            new Exhibition{ExhibitionID=3,ExName="Yellow",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"}

            };
            exhibitions.ForEach(a => context.Exhibitions.Add(a));
            context.SaveChanges();

            var patrons = new List<Patron>
            {
            new Patron{ PatronID =1, PatronName= "Bob", EntityType = "Government", ContactPhone = "12345", ContactEmail = "Bar Blar Bar" },
            new Patron{ PatronID =2, PatronName="Jack", EntityType = "Private", ContactPhone = "77777", ContactEmail = "PPP Blar PPP" },
            new Patron{ PatronID =3, PatronName="Bob", EntityType = "Government", ContactPhone = "12345", ContactEmail = "Bar Blar Bar" }
            };
            patrons.ForEach(a => context.Patrons.Add(a));
            context.SaveChanges();
            var artwork = new List<Artwork>
            {
            new Artwork{ ArtistID = 1, ExhibitionID = 1, PatronID = 1, Title="Violin", Year=1956, Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 1, ExhibitionID = 2, PatronID = 2, Title="Drum", Year=1986, Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 1, ExhibitionID = 3, PatronID = 3, Title="Drum", Year=1976, Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas" },
            new Artwork{ ArtistID = 2, ExhibitionID = 3, PatronID = 1, Title="Recorder", Year=1956, Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 2, ExhibitionID = 3, PatronID = 1, Title="Piano", Year=1976,Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 3, ExhibitionID = 2, PatronID = 2, Title="Piano", Year=1946,Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 4, ExhibitionID = 1, PatronID = 3, Title="Banjo", Year=1976,Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{ ArtistID = 5, ExhibitionID = 1, PatronID = 3, Title="Violin", Year=1912,Description="yah yah", Likes=12, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"}
            };
            artwork.ForEach(a => context.Artworks.Add(a));
            context.SaveChanges();
        }
    }

}

