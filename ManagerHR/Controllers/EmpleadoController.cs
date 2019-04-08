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
    public class EmpleadoController : Controller
    {
        private DBRHEntities1 db = new DBRHEntities1();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = db.empleado.Include(e => e.cargo).Include(e => e.departamento).Where(e=> e.estado==0);
            return View(empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.idcargo = new SelectList(db.cargo, "id", "cargo1");
            ViewBag.idpertamento = new SelectList(db.departamento, "id", "Departamento");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,codigo,nombre,apellido,telefono,idpertamento,feingreso,salario,idcargo,estado")] empleado empleado,DateTime? fecha = null)
        {
            if (ModelState.IsValid)
            {
               empleado.estado = 0;
                if (fecha.HasValue)
                {
                    empleado.feingreso = fecha.Value;
                }
                db.empleado.Add(empleado);
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcargo = new SelectList(db.cargo, "id", "cargo1", empleado.idcargo);
            ViewBag.idpertamento = new SelectList(db.departamento, "id", "codigo", empleado.idpertamento);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcargo = new SelectList(db.cargo, "id", "cargo1", empleado.idcargo);
            ViewBag.idpertamento = new SelectList(db.departamento, "id", "codigo", empleado.idpertamento);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,codigo,nombre,apellido,telefono,idpertamento,feingreso,salario,idcargo,estado")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcargo = new SelectList(db.cargo, "id", "cargo1", empleado.idcargo);
            ViewBag.idpertamento = new SelectList(db.departamento, "id", "codigo", empleado.idpertamento);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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
