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
    public class proyeccionsController : Controller
    {
        private cineEntities db = new cineEntities();

        // GET: proyeccions
        public ActionResult Index()
        {
            var proyeccion = db.proyeccion.Include(p => p.pelicula);
            return View(proyeccion.ToList());
        }

        // GET: proyeccions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyeccion proyeccion = db.proyeccion.Find(id);
            if (proyeccion == null)
            {
                return HttpNotFound();
            }
            return View(proyeccion);
        }

        // GET: proyeccions/Create
        public ActionResult Create()
        {
            ViewBag.pel_idPeli = new SelectList(db.pelicula, "pel_idPel", "pel_nombre");
            return View();
        }

        // POST: proyeccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pro_idProyeccion,pro_horaInicio,pro_horaFin,pel_idPeli")] proyeccion proyeccion)
        {
            if (ModelState.IsValid)
            {
                db.proyeccion.Add(proyeccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.pel_idPeli = new SelectList(db.pelicula, "pel_idPel", "pel_nombre", proyeccion.pel_idPeli);
            return View(proyeccion);
        }

        // GET: proyeccions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyeccion proyeccion = db.proyeccion.Find(id);
            if (proyeccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.pel_idPeli = new SelectList(db.pelicula, "pel_idPel", "pel_nombre", proyeccion.pel_idPeli);
            return View(proyeccion);
        }

        // POST: proyeccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pro_idProyeccion,pro_horaInicio,pro_horaFin,pel_idPeli")] proyeccion proyeccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proyeccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.pel_idPeli = new SelectList(db.pelicula, "pel_idPel", "pel_nombre", proyeccion.pel_idPeli);
            return View(proyeccion);
        }

        // GET: proyeccions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proyeccion proyeccion = db.proyeccion.Find(id);
            if (proyeccion == null)
            {
                return HttpNotFound();
            }
            return View(proyeccion);
        }

        // POST: proyeccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            proyeccion proyeccion = db.proyeccion.Find(id);
            db.proyeccion.Remove(proyeccion);
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
