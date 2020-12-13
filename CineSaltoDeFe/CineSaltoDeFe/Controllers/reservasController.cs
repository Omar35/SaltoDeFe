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
    public class reservasController : Controller
    {
        private cineEntities db = new cineEntities();

        // GET: reservas
        public ActionResult Index()
        {
            var reserva = db.reserva.Include(r => r.cliente).Include(r => r.cliente1).Include(r => r.cliente2).Include(r => r.proyeccion).Include(r => r.sala);
            return View(reserva.ToList());
        }

        // GET: reservas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: reservas/Create
        public ActionResult Create()
        {
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre");
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre");
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre");
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio");
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala");
            return View();
        }

        // POST: reservas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "res_idReserva,cl_idCliente,pro_idProyeccion,res_boletos,res_costoTotal,sal_idSala")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", reserva.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", reserva.sal_idSala);
            return View(reserva);
        }

        // GET: reservas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", reserva.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", reserva.sal_idSala);
            return View(reserva);
        }

        // POST: reservas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "res_idReserva,cl_idCliente,pro_idProyeccion,res_boletos,res_costoTotal,sal_idSala")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.cl_idCliente = new SelectList(db.cliente, "cl_idCliente", "cl_nombre", reserva.cl_idCliente);
            ViewBag.pro_idProyeccion = new SelectList(db.proyeccion, "pro_idProyeccion", "pro_horaInicio", reserva.pro_idProyeccion);
            ViewBag.sal_idSala = new SelectList(db.sala, "sal_idSala", "sal_idSala", reserva.sal_idSala);
            return View(reserva);
        }

        // GET: reservas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            reserva reserva = db.reserva.Find(id);
            db.reserva.Remove(reserva);
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
