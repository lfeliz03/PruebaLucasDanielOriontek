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
    public class DireccionesClientesController : Controller
    {
        private PruebaLucasFelizOriontekBDEntities db = new PruebaLucasFelizOriontekBDEntities();

        // GET: DireccionesClientes
        public async Task<ActionResult> Index()
        {
            var direccionesClientes = db.DireccionesClientes.Include(d => d.Clientes).Include(d => d.Direcciones);
            return View(await direccionesClientes.ToListAsync());
        }

        // GET: DireccionesClientes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionesClientes direccionesClientes = await db.DireccionesClientes.FindAsync(id);
            if (direccionesClientes == null)
            {
                return HttpNotFound();
            }
            return View(direccionesClientes);
        }

        // GET: DireccionesClientes/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres");
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion");
            return View();
        }

        // POST: DireccionesClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdDireccionCliente,IdCliente,IdDireccion")] DireccionesClientes direccionesClientes)
        {
            if (ModelState.IsValid)
            {
                db.DireccionesClientes.Add(direccionesClientes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", direccionesClientes.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", direccionesClientes.IdDireccion);
            return View(direccionesClientes);
        }

        // GET: DireccionesClientes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionesClientes direccionesClientes = await db.DireccionesClientes.FindAsync(id);
            if (direccionesClientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", direccionesClientes.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", direccionesClientes.IdDireccion);
            return View(direccionesClientes);
        }

        // POST: DireccionesClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdDireccionCliente,IdCliente,IdDireccion")] DireccionesClientes direccionesClientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccionesClientes).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.Clientes, "IdCliente", "Nombres", direccionesClientes.IdCliente);
            ViewBag.IdDireccion = new SelectList(db.Direcciones, "IdDireccion", "Direccion", direccionesClientes.IdDireccion);
            return View(direccionesClientes);
        }

        // GET: DireccionesClientes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DireccionesClientes direccionesClientes = await db.DireccionesClientes.FindAsync(id);
            if (direccionesClientes == null)
            {
                return HttpNotFound();
            }
            return View(direccionesClientes);
        }

        // POST: DireccionesClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DireccionesClientes direccionesClientes = await db.DireccionesClientes.FindAsync(id);
            db.DireccionesClientes.Remove(direccionesClientes);
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
