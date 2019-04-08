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
    public class SalidaController : Controller
    {
        private DBRHEntities1 db = new DBRHEntities1();

        // GET: Salida
        public ActionResult Index()
        {
            var salida = db.salida.Include(s => s.empleado);
            return View(salida.ToList());
        }

        // GET: Salida/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida salida = db.salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // GET: Salida/Create
        public ActionResult Create()
        {
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo");
            return View();
        }

        // POST: Salida/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,idempleado,tipo,motivo,fesalida")] salida salida,DateTime? Fecha = null)
        {
            if (ModelState.IsValid)
            {
                db.salida.Add(salida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", salida.idempleado);
            return View(salida);
        }

        // GET: Salida/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida salida = db.salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", salida.idempleado);
            return View(salida);
        }

        // POST: Salida/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,idempleado,tipo,motivo,fesalida")] salida salida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idempleado = new SelectList(db.empleado, "id", "codigo", salida.idempleado);
            return View(salida);
        }

        // GET: Salida/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida salida = db.salida.Find(id);
            if (salida == null)
            {
                return HttpNotFound();
            }
            return View(salida);
        }

        // POST: Salida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salida salida = db.salida.Find(id);
            db.salida.Remove(salida);
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
