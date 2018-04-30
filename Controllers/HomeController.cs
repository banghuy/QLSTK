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
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            var username = db.AspNetUsers.Single(d => d.Email.Equals("daominhquan176@gmail.com"));
            ViewBag.idusername = username.Id;
            var nguoinhan = db.AspNetUsers.Single(d => d.Email.Equals("laiquanghung@gmail.com"));
            ViewBag.idnguoinhan = nguoinhan.Id;
            var chatBoxes = db.ChatBoxes.Include(c => c.AspNetUser).Include(c => c.AspNetUser1);
            return View(chatBoxes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult chatadmin([Bind(Include = "Id,UserID_Gui,TinNhan,ThoiGian,UserID_Nhan")] ChatBox chatBox)
        {
            if (ModelState.IsValid)
            {
                db.ChatBoxes.Add(chatBox);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}