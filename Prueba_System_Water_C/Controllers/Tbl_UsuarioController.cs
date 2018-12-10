using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba_System_Water_C.Models;
using System.Security.Cryptography;
using System.Text;

namespace Prueba_System_Water_C.Controllers
{
    public class Tbl_UsuarioController : Controller
    {
        private Sistem_WalterEntities db = new Sistem_WalterEntities();

        // GET: Tbl_Usuario
        public ActionResult Index()
        {
            var tbl_Usuario = db.Tbl_Usuario.Include(t => t.Tbl_Clientes).Include(t => t.Tbl_Rol);
            return View(tbl_Usuario.ToList());
        }

        // GET: Tbl_Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Id_Nombre = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo");
            ViewBag.Rol = new SelectList(db.Tbl_Rol, "Id_Rol", "Rol");
            return View();
        }

        // POST: Tbl_Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Usuarios,Id_Nombre,Usuario,Contraseña,Rol,Estado,Fecha_Registro")] Tbl_Usuario tbl_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Usuario.Add(tbl_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Nombre = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Usuario.Id_Nombre);
            ViewBag.Rol = new SelectList(db.Tbl_Rol, "Id_Rol", "Rol", tbl_Usuario.Rol);
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Nombre = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Usuario.Id_Nombre);
            ViewBag.Rol = new SelectList(db.Tbl_Rol, "Id_Rol", "Rol", tbl_Usuario.Rol);
            return View(tbl_Usuario);
        }

        // POST: Tbl_Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Usuarios,Id_Nombre,Usuario,Contraseña,Rol,Estado,Fecha_Registro")] Tbl_Usuario tbl_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Nombre = new SelectList(db.Tbl_Clientes, "Id_Cliente", "Nombre_Completo", tbl_Usuario.Id_Nombre);
            ViewBag.Rol = new SelectList(db.Tbl_Rol, "Id_Rol", "Rol", tbl_Usuario.Rol);
            return View(tbl_Usuario);
        }

        // GET: Tbl_Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            if (tbl_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Usuario);
        }

        // POST: Tbl_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Usuario tbl_Usuario = db.Tbl_Usuario.Find(id);
            db.Tbl_Usuario.Remove(tbl_Usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public class Helper
        {
            public static string EncodePassword(string originalPassword)
            {
                SHA1 sha1 = new SHA1CryptoServiceProvider();

                byte[] inputBytes = (new UnicodeEncoding()).GetBytes(originalPassword);
                byte[] hash = sha1.ComputeHash(inputBytes);

                return Convert.ToBase64String(hash);
            }
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
