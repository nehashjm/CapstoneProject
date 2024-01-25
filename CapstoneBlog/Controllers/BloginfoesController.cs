using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CapstoneBlog.Models;

namespace CapstoneBlog.Controllers
{
    public class BloginfoesController : Controller
    {
        private capstonedbEntities db = new capstonedbEntities();

        // GET: Bloginfoes
        public ActionResult Index()
        {
            var bloginfoes = db.Bloginfoes.Include(b => b.employeeinfo);
            return View(bloginfoes.ToList());
        }

        public ActionResult DisplayHome()
        {
            var bloginfoes = db.Bloginfoes.Include(b => b.employeeinfo);
            return View(bloginfoes.ToList());
        }

        // GET: Bloginfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloginfo bloginfo = db.Bloginfoes.Find(id);
            if (bloginfo == null)
            {
                return HttpNotFound();
            }
            return View(bloginfo);
        }

        // GET: Bloginfoes/Create
        public ActionResult Create()
        {
            ViewBag.empemail = new SelectList(db.employeeinfoes, "emailid", "name");
            return View();
        }

        // POST: Bloginfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Blogid,Title,Subject,DateOfCreation,Blogurl,empemail")] Bloginfo bloginfo)
        {
            if (ModelState.IsValid)
            {
                db.Bloginfoes.Add(bloginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empemail = new SelectList(db.employeeinfoes, "emailid", "name", bloginfo.empemail);
            return View(bloginfo);
        }

        // GET: Bloginfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloginfo bloginfo = db.Bloginfoes.Find(id);
            if (bloginfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.empemail = new SelectList(db.employeeinfoes, "emailid", "name", bloginfo.empemail);
            return View(bloginfo);
        }

        // POST: Bloginfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Blogid,Title,Subject,DateOfCreation,Blogurl,empemail")] Bloginfo bloginfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloginfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empemail = new SelectList(db.employeeinfoes, "emailid", "name", bloginfo.empemail);
            return View(bloginfo);
        }

        // GET: Bloginfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bloginfo bloginfo = db.Bloginfoes.Find(id);
            if (bloginfo == null)
            {
                return HttpNotFound();
            }
            return View(bloginfo);
        }

        // POST: Bloginfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bloginfo bloginfo = db.Bloginfoes.Find(id);
            db.Bloginfoes.Remove(bloginfo);
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
