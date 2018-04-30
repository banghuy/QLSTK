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
    public class ChatBoxesController : Controller
    {
        private Entities db = new Entities();

        // GET: ChatBoxes
        public ActionResult Index()
        {
            var chatBoxes = db.ChatBoxes.Include(c => c.AspNetUser).Include(c => c.AspNetUser1);
            return View(chatBoxes.ToList());
        }

        // GET: ChatBoxes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatBox chatBox = db.ChatBoxes.Find(id);
            if (chatBox == null)
            {
                return HttpNotFound();
            }
            return View(chatBox);
        }

        // GET: ChatBoxes/Create
        public ActionResult Create()
        {
            ViewBag.UserID_Gui = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.UserID_Nhan = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: ChatBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserID_Gui,TinNhan,ThoiGian,UserID_Nhan")] ChatBox chatBox)
        {
            if (ModelState.IsValid)
            {
                db.ChatBoxes.Add(chatBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID_Gui = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Gui);
            ViewBag.UserID_Nhan = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Nhan);
            return View(chatBox);
        }

        // GET: ChatBoxes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatBox chatBox = db.ChatBoxes.Find(id);
            if (chatBox == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID_Gui = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Gui);
            ViewBag.UserID_Nhan = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Nhan);
            return View(chatBox);
        }

        // POST: ChatBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserID_Gui,TinNhan,ThoiGian,UserID_Nhan")] ChatBox chatBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID_Gui = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Gui);
            ViewBag.UserID_Nhan = new SelectList(db.AspNetUsers, "Id", "Email", chatBox.UserID_Nhan);
            return View(chatBox);
        }

        // GET: ChatBoxes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatBox chatBox = db.ChatBoxes.Find(id);
            if (chatBox == null)
            {
                return HttpNotFound();
            }
            return View(chatBox);
        }

        // POST: ChatBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatBox chatBox = db.ChatBoxes.Find(id);
            db.ChatBoxes.Remove(chatBox);
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
