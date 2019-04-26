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

namespace MVCGallery.Controllers
{
    public class PatronController : Controller
    {
        private GalleryContext db = new GalleryContext();

        // GET: Patron
        public ActionResult Index()
        {
            return View(db.Patrons.ToList());
        }

        // GET: Patron/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patron patron = db.Patrons.Find(id);
            if (patron == null)
            {
                return HttpNotFound();
            }
            return View(patron);
        }

        // GET: Patron/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patron/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatronID,PatronName,EntityType,ContactPhone,ContactEmail")] Patron patron)
        {
            if (ModelState.IsValid)
            {
                db.Patrons.Add(patron);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patron);
        }

        // GET: Patron/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patron patron = db.Patrons.Find(id);
            if (patron == null)
            {
                return HttpNotFound();
            }
            return View(patron);
        }

        // POST: Patron/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatronID,PatronName,EntityType,ContactPhone,ContactEmail")] Patron patron)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patron).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patron);
        }

        // GET: Patron/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patron patron = db.Patrons.Find(id);
            if (patron == null)
            {
                return HttpNotFound();
            }
            return View(patron);
        }

        // POST: Patron/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patron patron = db.Patrons.Find(id);
            db.Patrons.Remove(patron);
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
