using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SocialNet.Models;
using SocialNet.ViewModels;

namespace SocialNet.Controllers
{
    public class MessengersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messengers
        public ActionResult Index()
        {
            return View(db.Messengers.ToList());
        }

        // GET: Messengers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messenger messenger = db.Messengers.Find(id);
            if (messenger == null)
            {
                return HttpNotFound();
            }
            return View(messenger);
        }

        // GET: Messengers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messengers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserOne,UserTwo,MessageBody")] Messenger messenger)
        {
            if (ModelState.IsValid)
            {
                db.Messengers.Add(messenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(messenger);
        }

        // GET: Messengers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messenger messenger = db.Messengers.Find(id);
            if (messenger == null)
            {
                return HttpNotFound();
            }
            return View(messenger);
        }

        // POST: Messengers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserOne,UserTwo,MessageBody")] Messenger messenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(messenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(messenger);
        }

        // GET: Messengers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Messenger messenger = db.Messengers.Find(id);
            if (messenger == null)
            {
                return HttpNotFound();
            }
            return View(messenger);
        }

        // POST: Messengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Messenger messenger = db.Messengers.Find(id);
            db.Messengers.Remove(messenger);
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
