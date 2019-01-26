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
	public class tmodelsController : Controller
	{
		private D010MCSEntities db = new D010MCSEntities();

		// GET: tmodels
		public async Task<ActionResult> Index()
		{
			var tmodels = db.tmodels.Include(t => t.tmake).Include(t => t.tyear).Include(t => t.tstyle);
			return View(await tmodels.ToListAsync());
		}

		// GET: tmodels/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodels.FindAsync(id);
			if (tmodel == null)
			{
				return HttpNotFound();
			}
			return View(tmodel);
		}

		// GET: tmodels/Create
		public ActionResult Create()
		{
			ViewBag.make_id = new SelectList(db.tmakes, "id", "make_na");
			ViewBag.year_id = new SelectList(db.tyears, "yr", "yr");
			ViewBag.style_id = new SelectList(db.tstyles, "Id", "style_na");
			return View();
		}

		// POST: tmodels/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "id,year_id,make_id,model_na,style_id")] tmodel tmodel)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.tmodels.Add(tmodel);
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					ViewBag.make_id = new SelectList(db.tmakes, "id", "make_na", tmodel.make_id);
					ViewBag.year_id = new SelectList(db.tyears, "yr", "yr", tmodel.year_id);
					ViewBag.style_id = new SelectList(db.tstyles, "Id", "style_na", tmodel.style_id);
					return View("Create");
				}
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = ex.InnerException.Message;
				ViewBag.make_id = new SelectList(db.tmakes, "id", "make_na", tmodel.make_id);
				ViewBag.year_id = new SelectList(db.tyears, "yr", "yr", tmodel.year_id);
				ViewBag.style_id = new SelectList(db.tstyles, "Id", "style_na", tmodel.style_id);
				return View("Create");
			}
		}

		// GET: tmodels/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodels.FindAsync(id);
			if (tmodel == null)
			{
				return HttpNotFound();
			}
			ViewBag.make_id = new SelectList(db.tmakes, "id", "make_na", tmodel.make_id);
			ViewBag.year_id = new SelectList(db.tyears, "yr", "yr", tmodel.year_id);
			ViewBag.style_id = new SelectList(db.tstyles, "Id", "style_na", tmodel.style_id);
			return View(tmodel);
		}

		// POST: tmodels/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "id,year_id,make_id,model_na,style_id")] tmodel tmodel)
		{
			if (ModelState.IsValid)
			{
				db.Entry(tmodel).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			ViewBag.make_id = new SelectList(db.tmakes, "id", "make_na", tmodel.make_id);
			ViewBag.year_id = new SelectList(db.tyears, "yr", "yr", tmodel.year_id);
			ViewBag.style_id = new SelectList(db.tstyles, "Id", "style_na", tmodel.style_id);
			return View(tmodel);
		}

		// GET: tmodels/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tmodel tmodel = await db.tmodels.FindAsync(id);
			if (tmodel == null)
			{
				return HttpNotFound();
			}
			return View(tmodel);
		}

		// POST: tmodels/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			tmodel tmodel = await db.tmodels.FindAsync(id);
			db.tmodels.Remove(tmodel);
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
