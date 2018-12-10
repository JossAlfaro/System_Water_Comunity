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
    public class Tbl_EmpleadosController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Empleados
        public ActionResult Index()
        {
            return View(db.Tbl_Empleados.ToList());
        }

        // GET: Tbl_Empleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            if (tbl_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empleados);
        }

        // GET: Tbl_Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Empleados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empleados,Nombre_Completo,Edad,Cargo,DUI,Telefono,Correo,Direccion,Estado,Fecha_Registro")] Tbl_Empleados tbl_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Empleados.Add(tbl_Empleados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Empleados);
        }

        // GET: Tbl_Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            if (tbl_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empleados);
        }

        // POST: Tbl_Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empleados,Nombre_Completo,Edad,Cargo,DUI,Telefono,Correo,Direccion,Estado,Fecha_Registro")] Tbl_Empleados tbl_Empleados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Empleados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Empleados);
        }

        // GET: Tbl_Empleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            if (tbl_Empleados == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empleados);
        }

        // POST: Tbl_Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            db.Tbl_Empleados.Remove(tbl_Empleados);
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
