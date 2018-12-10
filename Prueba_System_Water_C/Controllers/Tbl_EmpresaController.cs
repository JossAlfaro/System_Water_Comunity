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
    public class Tbl_EmpresaController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Empresa
        public ActionResult Index()
        {
            return View(db.Tbl_Empresa.ToList());
        }

        // GET: Tbl_Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empresa tbl_Empresa = db.Tbl_Empresa.Find(id);
            if (tbl_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empresa);
        }

        // GET: Tbl_Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tbl_Empresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Empresa,Nombre,Direccion,Correo,NIT,Rubro,Telefono,Estado,FechaRegistro")] Tbl_Empresa tbl_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Empresa.Add(tbl_Empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Empresa);
        }

        // GET: Tbl_Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empresa tbl_Empresa = db.Tbl_Empresa.Find(id);
            if (tbl_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empresa);
        }

        // POST: Tbl_Empresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Empresa,Nombre,Direccion,Correo,NIT,Rubro,Telefono,Estado,FechaRegistro")] Tbl_Empresa tbl_Empresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Empresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Empresa);
        }

        // GET: Tbl_Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Empresa tbl_Empresa = db.Tbl_Empresa.Find(id);
            if (tbl_Empresa == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Empresa);
        }

        // POST: Tbl_Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Empresa tbl_Empresa = db.Tbl_Empresa.Find(id);
            db.Tbl_Empresa.Remove(tbl_Empresa);
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
