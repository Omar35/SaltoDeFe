using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineSaltoDeFe.Models;

namespace CineSaltoDeFe.Controllers
{
    public class funcionsController : Controller
    {
        private cineEntities db = new cineEntities();

        // GET: funcions
        public ActionResult Index()
        {
            var funcion = db.funcion.Include(f => f.proyeccion).Include(f => f.sala);
            return View(funcion.ToList());
        }

        // GET: funcions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcion funcion = db.funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // GET: funcions/Create
        public ActionResult Create()
        {
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio");
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala");
            return View();
        }

        // POST: funcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fun_idFuncion,pro_idProyeccion,sal_idSala,fun_horario")] funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.funcion.Add(funcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", funcion.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", funcion.sal_idSala);
            return View(funcion);
        }

        // GET: funcions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcion funcion = db.funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", funcion.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", funcion.sal_idSala);
            return View(funcion);
        }

        // POST: funcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fun_idFuncion,pro_idProyeccion,sal_idSala,fun_horario")] funcion funcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", funcion.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", funcion.sal_idSala);
            return View(funcion);
        }

        // GET: funcions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcion funcion = db.funcion.Find(id);
            if (funcion == null)
            {
                return HttpNotFound();
            }
            return View(funcion);
        }

        // POST: funcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            funcion funcion = db.funcion.Find(id);
            db.funcion.Remove(funcion);
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
