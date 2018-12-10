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
    public class Tbl_ConfiguracionesController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Configuraciones
        public ActionResult Index()
        {
            return View(db.Tbl_Configuraciones.ToList());
        }

        // GET: Tbl_Configuraciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Configuraciones tbl_Configuraciones = db.Tbl_Configuraciones.Find(id);
            if (tbl_Configuraciones == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Configuraciones);
        }

        // GET: Tbl_Configuraciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Configuraciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Configuracion,Cuota_Fija,Mora,Valor_Metro,Valor_Metro2,Valor_Metro3,Multas,Detalles,Estado,Fecha_Registro")] Tbl_Configuraciones tbl_Configuraciones)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Configuraciones.Add(tbl_Configuraciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Configuraciones);
        }

        // GET: Tbl_Configuraciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Configuraciones tbl_Configuraciones = db.Tbl_Configuraciones.Find(id);
            if (tbl_Configuraciones == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Configuraciones);
        }

        // POST: Tbl_Configuraciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Configuracion,Cuota_Fija,Mora,Valor_Metro,Valor_Metro2,Valor_Metro3,Multas,Detalles,Estado,Fecha_Registro")] Tbl_Configuraciones tbl_Configuraciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Configuraciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Configuraciones);
        }

        // GET: Tbl_Configuraciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Configuraciones tbl_Configuraciones = db.Tbl_Configuraciones.Find(id);
            if (tbl_Configuraciones == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Configuraciones);
        }

        // POST: Tbl_Configuraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Configuraciones tbl_Configuraciones = db.Tbl_Configuraciones.Find(id);
            db.Tbl_Configuraciones.Remove(tbl_Configuraciones);
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
