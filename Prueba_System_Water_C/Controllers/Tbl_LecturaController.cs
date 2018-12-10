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
    public class Tbl_LecturaController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Lectura
        public ActionResult Index()
        {
            var tbl_Lectura = db.Tbl_Lectura.Include(t => t.Tbl_Clientes);
            return View(tbl_Lectura.ToList());
        }

        // GET: Tbl_Lectura/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Lectura tbl_Lectura = db.Tbl_Lectura.Find(id);
            if (tbl_Lectura == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Lectura);
        }

        // GET: Tbl_Lectura/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo");
            return View();
        }

        // POST: Tbl_Lectura/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Lectura,Lectura,Id_Cliente,Estado_Lectura,Estado,Fecha_Registro,Id_Lecturas,Mes")] Tbl_Lectura tbl_Lectura)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Lectura.Add(tbl_Lectura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Lectura.Id_Cliente);
            return View(tbl_Lectura);
        }

        // GET: Tbl_Lectura/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Lectura tbl_Lectura = db.Tbl_Lectura.Find(id);
            if (tbl_Lectura == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Lectura.Id_Cliente);
            return View(tbl_Lectura);
        }

        // POST: Tbl_Lectura/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Lectura,Lectura,Id_Cliente,Estado_Lectura,Estado,Fecha_Registro,Id_Lecturas,Mes")] Tbl_Lectura tbl_Lectura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Lectura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Lectura.Id_Cliente);
            return View(tbl_Lectura);
        }

        // GET: Tbl_Lectura/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Lectura tbl_Lectura = db.Tbl_Lectura.Find(id);
            if (tbl_Lectura == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Lectura);
        }

        // POST: Tbl_Lectura/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Lectura tbl_Lectura = db.Tbl_Lectura.Find(id);
            db.Tbl_Lectura.Remove(tbl_Lectura);
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
