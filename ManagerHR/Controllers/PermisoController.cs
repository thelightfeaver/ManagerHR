using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ManagerHR.Models;

namespace ManagerHR.Controllers
{
    public class PermisoController : Controller
    {
        private DBRHEntities1 db = new DBRHEntities1();

        // GET: Permiso
        public ActionResult Index()
        {
            var permiso = db.permiso.Include(p => p.empleado);
            return View(permiso.ToList());
        }

        // GET: Permiso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: Permiso/Create
        public ActionResult Create()
        {
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo");
            return View();
        }

        // POST: Permiso/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idempleado,desde,hasta,comentario")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.permiso.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", permiso.idempleado);
            return View(permiso);
        }

        // GET: Permiso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", permiso.idempleado);
            return View(permiso);
        }

        // POST: Permiso/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idempleado,desde,hasta,comentario")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", permiso.idempleado);
            return View(permiso);
        }

        // GET: Permiso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: Permiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permiso permiso = db.permiso.Find(id);
            db.permiso.Remove(permiso);
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
