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
    public class LincenciaController : Controller
    {
        private DBRHEntities1 db = new DBRHEntities1();

        // GET: Lincencia
        public ActionResult Index()
        {
            var licencia = db.licencia.Include(l => l.empleado);
            return View(licencia.ToList());
        }

        // GET: Lincencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // GET: Lincencia/Create
        public ActionResult Create()
        {
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo");
            return View();
        }

        // POST: Lincencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idempleado,desde,hasta,motivo,comentario")] licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.licencia.Add(licencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", licencia.idempleado);
            return View(licencia);
        }

        // GET: Lincencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", licencia.idempleado);
            return View(licencia);
        }

        // POST: Lincencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idempleado,desde,hasta,motivo,comentario")] licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", licencia.idempleado);
            return View(licencia);
        }

        // GET: Lincencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // POST: Lincencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            licencia licencia = db.licencia.Find(id);
            db.licencia.Remove(licencia);
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
