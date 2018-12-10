using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba_System_Water_C.Models;

namespace Prueba_System_Water_C.Controllers
{
    public class Tbl_RolController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Rol
        public ActionResult Index()
        {
            return View(db.Tbl_Rol.ToList());
        }

        // GET: Tbl_Rol/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Rol tbl_Rol = db.Tbl_Rol.Find(id);
            if (tbl_Rol == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rol);
        }

        // GET: Tbl_Rol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Rol/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Rol,Rol")] Tbl_Rol tbl_Rol)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Rol.Add(tbl_Rol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Rol);
        }

        // GET: Tbl_Rol/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Rol tbl_Rol = db.Tbl_Rol.Find(id);
            if (tbl_Rol == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rol);
        }

        // POST: Tbl_Rol/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Rol,Rol")] Tbl_Rol tbl_Rol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Rol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Rol);
        }

        // GET: Tbl_Rol/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Rol tbl_Rol = db.Tbl_Rol.Find(id);
            if (tbl_Rol == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Rol);
        }

        // POST: Tbl_Rol/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Rol tbl_Rol = db.Tbl_Rol.Find(id);
            db.Tbl_Rol.Remove(tbl_Rol);
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
