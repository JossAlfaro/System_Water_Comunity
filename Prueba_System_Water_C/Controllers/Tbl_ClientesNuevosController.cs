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
    public class Tbl_ClientesNuevosController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_ClientesNuevos
        public ActionResult Index()
        {
            return View(db.Tbl_ClientesNuevos.ToList());
        }

        // GET: Tbl_ClientesNuevos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ClientesNuevos tbl_ClientesNuevos = db.Tbl_ClientesNuevos.Find(id);
            if (tbl_ClientesNuevos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ClientesNuevos);
        }

        // GET: Tbl_ClientesNuevos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_ClientesNuevos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Clientes_Nuevos,Nombre,Fecha_Inicio,Monto_a_Pagar,Plazo,Cuota,Estado,EstadoConfig,Fecha_Registro,Estado2")] Tbl_ClientesNuevos tbl_ClientesNuevos)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_ClientesNuevos.Add(tbl_ClientesNuevos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_ClientesNuevos);
        }

        // GET: Tbl_ClientesNuevos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ClientesNuevos tbl_ClientesNuevos = db.Tbl_ClientesNuevos.Find(id);
            if (tbl_ClientesNuevos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ClientesNuevos);
        }

        // POST: Tbl_ClientesNuevos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Clientes_Nuevos,Nombre,Fecha_Inicio,Monto_a_Pagar,Plazo,Cuota,Estado,EstadoConfig,Fecha_Registro,Estado2")] Tbl_ClientesNuevos tbl_ClientesNuevos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_ClientesNuevos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_ClientesNuevos);
        }

        // GET: Tbl_ClientesNuevos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_ClientesNuevos tbl_ClientesNuevos = db.Tbl_ClientesNuevos.Find(id);
            if (tbl_ClientesNuevos == null)
            {
                return HttpNotFound();
            }
            return View(tbl_ClientesNuevos);
        }

        // POST: Tbl_ClientesNuevos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_ClientesNuevos tbl_ClientesNuevos = db.Tbl_ClientesNuevos.Find(id);
            db.Tbl_ClientesNuevos.Remove(tbl_ClientesNuevos);
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
