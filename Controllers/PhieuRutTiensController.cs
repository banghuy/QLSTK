using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QLSTK.Models;

namespace QLSTK.Controllers
{
    public class PhieuRutTiensController : Controller
    {
        private Entities db = new Entities();

        // GET: PhieuRutTiens
        public ActionResult Index()
        {
            var phieuRutTiens = db.PhieuRutTiens.Include(p => p.AspNetUser);
            return View(phieuRutTiens.ToList());
        }

        // GET: PhieuRutTiens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuRutTien phieuRutTien = db.PhieuRutTiens.Find(id);
            if (phieuRutTien == null)
            {
                return HttpNotFound();
            }
            return View(phieuRutTien);
        }

        // GET: PhieuRutTiens/Create
        public ActionResult Create()
        {
            ViewBag.MaSTK = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: PhieuRutTiens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuRut,MaSTK,SoTienRut,NgayRut")] PhieuRutTien phieuRutTien)
        {
            if (ModelState.IsValid)
            {
                db.PhieuRutTiens.Add(phieuRutTien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSTK = new SelectList(db.AspNetUsers, "Id", "Email", phieuRutTien.MaSTK);
            return View(phieuRutTien);
        }

        // GET: PhieuRutTiens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuRutTien phieuRutTien = db.PhieuRutTiens.Find(id);
            if (phieuRutTien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSTK = new SelectList(db.AspNetUsers, "Id", "Email", phieuRutTien.MaSTK);
            return View(phieuRutTien);
        }

        // POST: PhieuRutTiens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuRut,MaSTK,SoTienRut,NgayRut")] PhieuRutTien phieuRutTien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phieuRutTien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSTK = new SelectList(db.AspNetUsers, "Id", "Email", phieuRutTien.MaSTK);
            return View(phieuRutTien);
        }

        // GET: PhieuRutTiens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuRutTien phieuRutTien = db.PhieuRutTiens.Find(id);
            if (phieuRutTien == null)
            {
                return HttpNotFound();
            }
            return View(phieuRutTien);
        }

        // POST: PhieuRutTiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhieuRutTien phieuRutTien = db.PhieuRutTiens.Find(id);
            db.PhieuRutTiens.Remove(phieuRutTien);
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
