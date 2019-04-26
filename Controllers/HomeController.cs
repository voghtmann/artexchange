using System;
using MVCGallery.DAL;
using MVCGallery.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCGallery.Models;

namespace MVCGallery.Controllers
{
    public class HomeController : Controller
    {
        private GalleryContext db = new GalleryContext();

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            IQueryable<ArtworkGroup> data = from artist in db.Artists
                      group artist by artist.DominantStyle into styleGroup
                      select new ArtworkGroup()
                      {
                          DominantStyle = styleGroup.Key,
                          ArtistCount = styleGroup.Count()
                      };
     
            return View(data.ToList());
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}