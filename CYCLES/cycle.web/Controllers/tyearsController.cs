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
	public class tyearsController : Controller
	{
		private D010MCSEntities db = new D010MCSEntities();

		// GET: tyears
		public async Task<ActionResult> Index()
		{
			return View(await db.tyears.OrderByDescending(a => a.yr).ToListAsync());
		}

		// GET: tyears/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tyear tyear = await db.tyears.FindAsync(id);
			if (tyear == null)
			{
				return HttpNotFound();
			}
			return View(tyear);
		}

		// GET: tyears/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: tyears/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "id,yr")] tyear tyear)
		{
			if (ModelState.IsValid)
			{
				db.tyears.Add(tyear);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(tyear);
		}

		// GET: tyears/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tyear tyear = await db.tyears.FindAsync(id);
			if (tyear == null)
			{
				return HttpNotFound();
			}
			return View(tyear);
		}

		// POST: tyears/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "id,yr")] tyear tyear)
		{

			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(tyear).State = EntityState.Modified;
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					return View(tyear);
				}
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = "Unable to save your changes due to a data error.  Make sure there is not a duplicate record.";
				return View(tyear);
			}
		}

		// GET: tyears/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tyear tyear = await db.tyears.FindAsync(id);
			if (tyear == null)
			{
				return HttpNotFound();
			}
			return View(tyear);
		}

		// POST: tyears/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			try
			{
					tyear tyear = await db.tyears.FindAsync(id);
				db.tyears.Remove(tyear);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
		}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = "This record cannot be deleted.  It's value may be assigned to another table.";
				return View("Delete");
	}
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
