namespace MVCGallery.Migrations
{
    using MVCGallery.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCGallery.DAL.GalleryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MVCGallery.DAL.GalleryContext context)
        {
            var artists = new List<Artist>
            {
            new Artist{ArtistID=1, ArtistName="John Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Impressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=2, ArtistName="Jimbo Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="France",DominantStyle="Expressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=3, ArtistName="Mike Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="German",DominantStyle="Cubism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=4, ArtistName="Sally Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="England",DominantStyle="Impressionism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" },
            new Artist{ArtistID=5, ArtistName="Philip Jones",Birth=DateTime.Parse("1902-03-01"),Death=DateTime.Parse("1998-02-02"),CountryOfOrigin="Spain",DominantStyle="Realism",ArtistDesc="Blar Blar blar",ArtistUrl="~/Content/artist_ppicasso.jpg" }
            };
            artists.ForEach(a => context.Artists.AddOrUpdate(b => b.ArtistName, a));
            context.SaveChanges();

            var exhibitions = new List<Exhibition>
            {
            new Exhibition{ExhibitionID=1,ExName="Blue",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"},
            new Exhibition{ExhibitionID=2,ExName="Red",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"},
            new Exhibition{ExhibitionID=3,ExName="Yellow",StartDate=DateTime.Parse("1999-03-01"), FinishDate=DateTime.Parse("2009-03-01"),Venue="School Hall",City="London",ExDesc="Bar Blar Bar"}

            };
            exhibitions.ForEach(a => context.Exhibitions.AddOrUpdate(b => b.ExName, a));
            context.SaveChanges();

            var patrons = new List<Patron>
            {
            new Patron{ PatronID =1, PatronName= "Bob", EntityType = "Government", ContactPhone = "12345", ContactEmail = "Bar Blar Bar" },
            new Patron{ PatronID =2, PatronName="Jack", EntityType = "Private", ContactPhone = "77777", ContactEmail = "PPP Blar PPP" },
            new Patron{ PatronID =3, PatronName="Peter", EntityType = "Government", ContactPhone = "12345", ContactEmail = "Bar Blar Bar" }
            };
            patrons.ForEach(a => context.Patrons.AddOrUpdate(b => b.PatronName, a));
            context.SaveChanges();

            var artworks = new List<Artwork>
            {
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "John Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Blue").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Violin", Year=1956, Description="yah yah", Likes=52, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "John Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Drum", Year=1986, Description="yah yah", Likes=42, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Mike Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Blue").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Chip", Year=1976, Description="yah yah", Likes=32, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas" },
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Philip Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Yellow").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Recorder", Year=1956, Description="yah yah", Likes=22, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Sally Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Blue").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Piano", Year=1976,Description="yah yah", Likes=14, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Sally Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Jack").PatronID,
                Title ="Peas", Year=1946,Description="yah yah", Likes=62, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Sally Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Bob").PatronID,
                Title ="Banjo", Year=1976,Description="yah yah", Likes=72, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Jimbo Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Peter").PatronID,
                Title ="MiniBus", Year=1912,Description="yah yah", Likes=82, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Jimbo Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Peter").PatronID,
                Title ="Fire", Year=1976,Description="yah yah", Likes=92, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Jimbo Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Peter").PatronID,
                Title ="Carrot", Year=1946,Description="yah yah", Likes=112, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Sally Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Yellow").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Peter").PatronID,
                Title ="Mug", Year=1976,Description="yah yah", Likes=122, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"},
            new Artwork{
                ArtistID = artists.Single( a => a.ArtistName == "Jimbo Jones").ArtistID,
                ExhibitionID = exhibitions.Single( e => e.ExName == "Red").ExhibitionID,
                PatronID = patrons.Single( p => p.PatronName == "Peter").PatronID,
                Title ="Cheese", Year=1912,Description="yah yah", Likes=632, ImageUrl="~/Content/mona_lisa.jpg",CurrentValue=1300,Medium="Oil on Canvas"}
            };



            foreach (Artwork w in artworks)
            {
                var artworkInDataBase = context.Artworks.Where(

                    a =>
                        a.Artist.ArtistID == w.ArtistID &&
                        a.Exhibition.ExhibitionID == w.ExhibitionID).FirstOrDefault();
                if (artworkInDataBase == null)
                {
                    context.Artworks.Add(w);
                }

            }
            context.SaveChanges();
        }
    }

}