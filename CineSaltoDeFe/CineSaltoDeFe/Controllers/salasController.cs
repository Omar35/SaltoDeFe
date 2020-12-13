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
    public class salasController : Controller
    {
        private cineEntities db = new cineEntities();

        // GET: salas
        public ActionResult Index()
        {
            var sala = db.sala.Include(s => s.sucursal);
            return View(sala.ToList());
        }

        // GET: salas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // GET: salas/Create
        public ActionResult Create()
        {
            ViewBag.suc_idSucursal = new SelectList(db.sucursal, "suc_idSucursal", "suc_nombre");
            return View();
        }

        // POST: salas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sal_idSala,sal_numeroSala,sal_numeroAsientos,suc_idSucursal")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.sala.Add(sala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.suc_idSucursal = new SelectList(db.sucursal, "suc_idSucursal", "suc_nombre", sala.suc_idSucursal);
            return View(sala);
        }

        // GET: salas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            ViewBag.suc_idSucursal = new SelectList(db.sucursal, "suc_idSucursal", "suc_nombre", sala.suc_idSucursal);
            return View(sala);
        }

        // POST: salas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sal_idSala,sal_numeroSala,sal_numeroAsientos,suc_idSucursal")] sala sala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.suc_idSucursal = new SelectList(db.sucursal, "suc_idSucursal", "suc_nombre", sala.suc_idSucursal);
            return View(sala);
        }

        // GET: salas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sala sala = db.sala.Find(id);
            if (sala == null)
            {
                return HttpNotFound();
            }
            return View(sala);
        }

        // POST: salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            sala sala = db.sala.Find(id);
            db.sala.Remove(sala);
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
