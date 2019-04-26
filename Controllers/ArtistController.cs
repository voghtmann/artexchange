using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCGallery.DAL;
using MVCGallery.Models;
using PagedList;

namespace MVCGallery.Controllers
{
    public class ArtistController : Controller
    {
        private GalleryContext db = new GalleryContext();


        // GET: Artist
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ArtistNameSortParm = String.IsNullOrEmpty(sortOrder) ? "artistName_desc" : "";
            ViewBag.BirthSortParm = sortOrder == "Birth" ? "birth_desc" : "Birth";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var artists = from a in db.Artists
                          select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                artists = artists.Where(a => a.ArtistName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "artistName_desc":
                    artists = artists.OrderByDescending(a => a.ArtistName);
                    break;
                case "Birth":
                    artists = artists.OrderBy(a => a.Birth);
                    break;
                case "birth_desc":
                    artists = artists.OrderByDescending(a => a.Birth);
                    break;
                default:
                    artists = artists.OrderBy(a => a.ArtistName);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(artists.ToPagedList(pageNumber, pageSize));
        }


        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }


        // GET: Artist/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Artist/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtistName,Birth,Death,CountryOfOrigin,DominantStyle,ArtistDesc,ArtistUrl")] Artist artist)
        {
            try
            {
                if (artist.ArtistUrl == "")
                {
                    artist.ArtistUrl = "https://www.bing.com/images/search?view=detailV2&id=6D5F69D514B5A2C5754F51845620E05A63EFD2C5&thid=OIP.hyu6RrWma2nM8560Kl4FbwHaE8&exph=800&expw=1200&q=football&selectedindex=0&vt=0&eim=1,2,6";
                }


                if (ModelState.IsValid)
                {
                    db.Artists.Add(artist);
                    db.SaveChanges();

           
                    return RedirectToAction("Index");
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Unable to save changes");
            }
             return View(artist);
        }

        // GET: Artist/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        //public ActionResult Edit([Bind(Include = "ArtistID,ArtistName,Birth,Death,CountryOfOrigin,DominantStyle,ArtistDesc,ArtistUrl")] Artist artist)
        {
          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artistToUpdate = db.Artists.Find(id);
            if (TryUpdateModel(artistToUpdate, "",
                new string[] { "ArtistID", "ArtistName", "Birth", "Death", "CountryOfOrigin", "DominantStyle", "ArtistDesc", "ArtistUrl" }))
            {

                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException)
                {
                    ModelState.AddModelError("", "Unable to save changes");
                }
            }
            return View(artistToUpdate);
        }
        
                // GET: Artist/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError=false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete Failed. Try again.";
            }
            Artist artist = db.Artists.Find(id);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }

        // POST: Artist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Artist artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (RetryLimitExceededException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
