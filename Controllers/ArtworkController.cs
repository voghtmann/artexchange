using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using MVCGallery.DAL;
using MVCGallery.Models;
using PagedList;

namespace MVCGallery.Controllers
{
    public class ArtworkController : Controller
    {
        private GalleryContext db = new GalleryContext();

        
        //AJAX Test

        public String Test()
        {

            return ("Ajax is working okay!");
        }

        public ActionResult MostValuable()
        {

            var mostValuable = from v in db.Artworks
                            orderby v.CurrentValue descending
                            select v;

            return PartialView("_MostValuable", mostValuable.First());
        }

        public ActionResult MostLiked()
        { 
        
            var mostLiked = from r in db.Artworks
                            orderby r.Likes descending
                            select r;

            return PartialView("_MostLiked", mostLiked.First());
        }

        // GET: Artworks
        //public ActionResult Index()


        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.ArtworkNameSortParm = String.IsNullOrEmpty(sortOrder) ? "Title_desc" : "";
            ViewBag.LikesSortParm = sortOrder == "Likes" ? "likes_desc" : "Likes";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var artworks = from a in db.Artworks
                          select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                artworks = artworks.Where(a => a.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Title_desc":
                    artworks = artworks.OrderByDescending(a => a.Title);
                    break;
                case "Likes":
                    artworks = artworks.OrderBy(a => a.Likes);
                    break;
                case "likes_desc":
                    artworks = artworks.OrderByDescending(a => a.Likes);
                    break;
                default:
                    artworks = artworks.OrderBy(a => a.Title);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(artworks.ToPagedList(pageNumber, pageSize));
            }

        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public ActionResult _Indexpartial(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(Id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return PartialView(artwork);
        }

        [HttpPost]
        public ActionResult Likes(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(Id);
            if (artwork == null)
            {
                return HttpNotFound();
            }

            int currentLikes = (int)artwork.Likes;
            artwork.Likes = currentLikes + 1;

            if (ModelState.IsValid)
            {
                db.Entry(artwork).State = EntityState.Modified;
                db.SaveChanges();
            }

            artwork = db.Artworks.Find(Id);
            return PartialView("_Indexpartial", artwork);
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX



        // GET: Artworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }


        // GET: Artworks/Create
        public ActionResult Create()
        {
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName");
            ViewBag.ExhibitionID = new SelectList(db.Exhibitions, "ExhibitionID", "ExName");
            ViewBag.PatronID = new SelectList(db.Patrons, "PatronID", "PatronName");
            return View();
        }

        // POST: Artworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArtworkID,ArtistID,PatronID,ExhibitionID,Title,Year,Description,Likes,ImageUrl,CurrentValue,Medium")] Artwork artwork)
        {
            if (artwork.ImageUrl == "")
            {
                artwork.ImageUrl = "https://www.bing.com/images/search?view=detailV2&id=6D5F69D514B5A2C5754F51845620E05A63EFD2C5&thid=OIP.hyu6RrWma2nM8560Kl4FbwHaE8&exph=800&expw=1200&q=football&selectedindex=0&vt=0&eim=1,2,6";
            }

            if (ModelState.IsValid)
            {
                db.Artworks.Add(artwork);
                db.SaveChanges();

                //artwork.ImageUrl.SaveAs(Server.MapPath("~/IMG") + artwork.ArtworkID + ".jpg");

                return RedirectToAction("Index");
            }

            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", artwork.ArtistID);
            ViewBag.ExhibitionID = new SelectList(db.Exhibitions, "ExhibitionID", "ExName", artwork.ExhibitionID);
            ViewBag.PatronID = new SelectList(db.Patrons, "PatronID", "PatronName", artwork.PatronID);
            return View(artwork);
        }

        // GET: Artworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", artwork.ArtistID);
            ViewBag.ExhibitionID = new SelectList(db.Exhibitions, "ExhibitionID", "ExName", artwork.ExhibitionID);
            ViewBag.PatronID = new SelectList(db.Patrons, "PatronID", "PatronName", artwork.PatronID);
            return View(artwork);
        }

        // POST: Artworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArtworkID,ArtistID,PatronID,ExhibitionID,Title,Year,Description,Likes,ImageUrl,CurrentValue,Medium")] Artwork artwork)
        {
            if (artwork.ImageUrl == "")
            {
                artwork.ImageUrl = "~/Content/https://www.bing.com/images/search?view=detailV2&id=6D5F69D514B5A2C5754F51845620E05A63EFD2C5&thid=OIP.hyu6RrWma2nM8560Kl4FbwHaE8&exph=800&expw=1200&q=football&selectedindex=0&vt=0&eim=1,2,6mona_lisa.jpg";
            }


            if (ModelState.IsValid)
            {
                db.Entry(artwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArtistID = new SelectList(db.Artists, "ArtistID", "ArtistName", artwork.ArtistID);
            ViewBag.ExhibitionID = new SelectList(db.Exhibitions, "ExhibitionID", "ExName", artwork.ExhibitionID);
            ViewBag.PatronID = new SelectList(db.Patrons, "PatronID", "PatronName", artwork.PatronID);
            return View(artwork);
        }

        // GET: Artworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artwork artwork = db.Artworks.Find(id);
            if (artwork == null)
            {
                return HttpNotFound();
            }
            return View(artwork);
        }

        // POST: Artworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artwork artwork = db.Artworks.Find(id);
            db.Artworks.Remove(artwork);
            db.SaveChanges();
            return RedirectToAction("Index");
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
