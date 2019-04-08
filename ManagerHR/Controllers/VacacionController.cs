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
    public class VacacionController : Controller
    {
        private DBRHEntities1 db = new DBRHEntities1();

        // GET: Vacacion
        public ActionResult Index()
        {
            var vacaciones = db.vacaciones.Include(v => v.empleado);
            return View(vacaciones.ToList());
        }

        // GET: Vacacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // GET: Vacacion/Create
        public ActionResult Create()
        {
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo");
            return View();
        }

        // POST: Vacacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idempleado,desde,hasta,ano,comentarios")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.vacaciones.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", vacaciones.idempleado);
            return View(vacaciones);
        }

        // GET: Vacacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", vacaciones.idempleado);
            return View(vacaciones);
        }

        // POST: Vacacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idempleado,desde,hasta,ano,comentarios")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", vacaciones.idempleado);
            return View(vacaciones);
        }

        // GET: Vacacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // POST: Vacacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacaciones vacaciones = db.vacaciones.Find(id);
            db.vacaciones.Remove(vacaciones);
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
