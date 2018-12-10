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
    public class Tbl_ClientesController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Clientes
        public ActionResult Index()
        {
            return View(db.Tbl_Clientes.ToList());
        }

        // GET: Tbl_Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // GET: Tbl_Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Clientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,Nombre_Completo,Edad,DUI,Telefono,Correo,Direccion,Fecha_Nacimiento,Roll,Estado,Fecha_Registro")] Tbl_Clientes tbl_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Clientes.Add(tbl_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Clientes);
        }

        // GET: Tbl_Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // POST: Tbl_Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,Nombre_Completo,Edad,DUI,Telefono,Correo,Direccion,Fecha_Nacimiento,Roll,Estado,Fecha_Registro")] Tbl_Clientes tbl_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Clientes);
        }

        // GET: Tbl_Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // POST: Tbl_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            db.Tbl_Clientes.Remove(tbl_Clientes);
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
