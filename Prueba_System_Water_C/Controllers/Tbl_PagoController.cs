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
    public class Tbl_PagoController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Pago
        public ActionResult Index()
        {
            var tbl_Pago = db.Tbl_Pago.Include(t => t.Tbl_Clientes);
            return View(tbl_Pago.ToList());
        }

        // GET: Tbl_Pago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pago tbl_Pago = db.Tbl_Pago.Find(id);
            if (tbl_Pago == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Pago);
        }

        // GET: Tbl_Pago/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo");
            ViewBag.Id_Lectura = new SelectList(db.Tbl_Lectura, "Id_Lectura", "Lectura");
            return View();
        }

        // POST: Tbl_Pago/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Pago,Id_Cliente,Id_Lectura,Numero_Factura,Lectura_Anterior,Lectura_Actual,Consumo,Cuota_Fija,Mes_Atrasado,Mora,Total,Fecha_Lectura,Fecha_Pago,Estado,Fecha_Registro")] Tbl_Pago tbl_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Pago.Add(tbl_Pago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Tbl_Lectura, "Id_Cliente", "Lectura",tbl_Pago.Id_Lectura);
         //   ViewBag.Id_Nombre = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Usuario.Id_Nombre);
            return View(tbl_Pago);
        }

        // GET: Tbl_Pago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pago tbl_Pago = db.Tbl_Pago.Find(id);
            if (tbl_Pago == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Lectura = new SelectList(db.Tbl_Lectura, "Lectura", "N", tbl_Pago.Id_Cliente);
            return View(tbl_Pago);
        }

        // POST: Tbl_Pago/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Pago,Id_Cliente,Id_Lectura,Numero_Factura,Lectura_Anterior,Lectura_Actual,Consumo,Cuota_Fija,Mes_Atrasado,Mora,Total,Fecha_Lectura,Fecha_Pago,Estado,Fecha_Registro")] Tbl_Pago tbl_Pago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Pago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Pago.Id_Cliente);
            return View(tbl_Pago);
        }

        // GET: Tbl_Pago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Pago tbl_Pago = db.Tbl_Pago.Find(id);
            if (tbl_Pago == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Pago);
        }

        // POST: Tbl_Pago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Pago tbl_Pago = db.Tbl_Pago.Find(id);
            db.Tbl_Pago.Remove(tbl_Pago);
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
