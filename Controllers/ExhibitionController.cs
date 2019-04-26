using System;
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
    public class ExhibitionController : Controller
    {
        private GalleryContext db = new GalleryContext();

        // GET: Exhibition

        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FinishDateSortParm = String.IsNullOrEmpty(sortOrder) ? "FinishDate_desc" : "";
            ViewBag.CitySortParm = sortOrder == "City" ? "city_desc" : "City";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var exhibitions = from a in db.Exhibitions
                          select a;

            if (!string.IsNullOrEmpty(searchString))
            {
                exhibitions = exhibitions.Where(a => a.ExName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "FinishDate_desc":
                    exhibitions = exhibitions.OrderByDescending(a => a.FinishDate);
                    break;
                case "City":
                    exhibitions = exhibitions.OrderBy(a => a.City);
                    break;
                case "city_desc":
                    exhibitions = exhibitions.OrderByDescending(a => a.City);
                    break;
                default:
                    exhibitions = exhibitions.OrderBy(a => a.ExName);
                    break;
            }
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            return View(exhibitions.ToPagedList(pageNumber, pageSize));
        }

        //public ActionResult Index()
        //{
        //    return View(db.Exhibitions.ToList());
        //}


        // GET: Exhibition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // GET: Exhibition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Exhibition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExhibitionID,ExName,StartDate,FinishDate,Venue,City,ExDesc")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Exhibitions.Add(exhibition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exhibition);
        }

        // GET: Exhibition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExhibitionID,ExName,StartDate,FinishDate,Venue,City,ExDesc")] Exhibition exhibition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exhibition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exhibition);
        }

        // GET: Exhibition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exhibition exhibition = db.Exhibitions.Find(id);
            if (exhibition == null)
            {
                return HttpNotFound();
            }
            return View(exhibition);
        }

        // POST: Exhibition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exhibition exhibition = db.Exhibitions.Find(id);
            db.Exhibitions.Remove(exhibition);
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
