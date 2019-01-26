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
    public class tstylesController : Controller
    {
        private D010MCSEntities db = new D010MCSEntities();

        // GET: tstyles
        public async Task<ActionResult> Index()
        {
            return View(await db.tstyles.ToListAsync());
        }

        // GET: tstyles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstyle tstyle = await db.tstyles.FindAsync(id);
            if (tstyle == null)
            {
                return HttpNotFound();
            }
            return View(tstyle);
        }

        // GET: tstyles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tstyles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,style_na")] tstyle tstyle)
        {
            if (ModelState.IsValid)
            {
                db.tstyles.Add(tstyle);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tstyle);
        }

        // GET: tstyles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstyle tstyle = await db.tstyles.FindAsync(id);
            if (tstyle == null)
            {
                return HttpNotFound();
            }
            return View(tstyle);
        }

        // POST: tstyles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,style_na")] tstyle tstyle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tstyle).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tstyle);
        }

        // GET: tstyles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tstyle tstyle = await db.tstyles.FindAsync(id);
            if (tstyle == null)
            {
                return HttpNotFound();
            }
            return View(tstyle);
        }

        // POST: tstyles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tstyle tstyle = await db.tstyles.FindAsync(id);
            db.tstyles.Remove(tstyle);
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
