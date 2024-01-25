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
    public class employeeinfoesController : Controller
    {
        private capstonedbEntities db = new capstonedbEntities();

        // GET: employeeinfoes
        public ActionResult Index()
        {
            return View(db.employeeinfoes.ToList());
        }

        // GET: employeeinfoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeinfo employeeinfo = db.employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // GET: employeeinfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeeinfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emailid,name,DOJ,passcode")] employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.employeeinfoes.Add(employeeinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeeinfo);
        }

        // GET: employeeinfoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeinfo employeeinfo = db.employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // POST: employeeinfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emailid,name,DOJ,passcode")] employeeinfo employeeinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeeinfo);
        }

        // GET: employeeinfoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employeeinfo employeeinfo = db.employeeinfoes.Find(id);
            if (employeeinfo == null)
            {
                return HttpNotFound();
            }
            return View(employeeinfo);
        }

        // POST: employeeinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            employeeinfo employeeinfo = db.employeeinfoes.Find(id);
            db.employeeinfoes.Remove(employeeinfo);
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
