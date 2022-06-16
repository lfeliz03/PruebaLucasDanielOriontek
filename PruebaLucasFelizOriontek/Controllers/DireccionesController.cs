using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PruebaLucasFelizOriontek.Models;

namespace PruebaLucasFelizOriontek.Controllers
{
    public class DireccionesController : Controller
    {
        private PruebaLucasFelizOriontekBDEntities db = new PruebaLucasFelizOriontekBDEntities();

        // GET: Direcciones
        public async Task<ActionResult> Index()
        {
            return View(await db.Direcciones.ToListAsync());
        }

        // GET: Direcciones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = await db.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // GET: Direcciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Direcciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDireccion,Direccion,Inactivo")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Direcciones.Add(direcciones);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(direcciones);
        }

        // GET: Direcciones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = await db.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDireccion,Direccion,Inactivo")] Direcciones direcciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direcciones).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(direcciones);
        }

        // GET: Direcciones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direcciones direcciones = await db.Direcciones.FindAsync(id);
            if (direcciones == null)
            {
                return HttpNotFound();
            }
            return View(direcciones);
        }

        // POST: Direcciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Direcciones direcciones = await db.Direcciones.FindAsync(id);
            db.Direcciones.Remove(direcciones);
            await db.SaveChangesAsync();
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
