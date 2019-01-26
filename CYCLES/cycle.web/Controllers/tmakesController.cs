using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cycles.ef;

namespace cycle.web.Controllers
{
    public class tmakesController : Controller
    {
        private D010MCSEntities db = new D010MCSEntities();

        // GET: tmakes
        public async Task<ActionResult> Index()
        {
            return View(await db.tmakes.ToListAsync());
        }

        // GET: tmakes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmake tmake = await db.tmakes.FindAsync(id);
            if (tmake == null)
            {
                return HttpNotFound();
            }
            return View(tmake);
        }

        // GET: tmakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tmakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,make_na")] tmake tmake)
        {
            if (ModelState.IsValid)
            {
                db.tmakes.Add(tmake);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tmake);
        }

        // GET: tmakes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmake tmake = await db.tmakes.FindAsync(id);
            if (tmake == null)
            {
                return HttpNotFound();
            }
            return View(tmake);
        }

        // POST: tmakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,make_na")] tmake tmake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tmake).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tmake);
        }

        // GET: tmakes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tmake tmake = await db.tmakes.FindAsync(id);
            if (tmake == null)
            {
                return HttpNotFound();
            }
            return View(tmake);
        }

        // POST: tmakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tmake tmake = await db.tmakes.FindAsync(id);
            db.tmakes.Remove(tmake);
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
