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
	public class tservicesController : Controller
	{
		private D010MCSEntities db = new D010MCSEntities();

		// GET: tservices
		public async Task<ActionResult> Index()
		{
			return View(await db.tservices.ToListAsync());
		}

		// GET: tservices/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tservice tservice = await db.tservices.FindAsync(id);
			if (tservice == null)
			{
				return HttpNotFound();
			}
			return View(tservice);
		}

		// GET: tservices/Create
		public ActionResult Create()
		{
			ModelState.SetModelValue("crt_dt",new ValueProviderResult(DateTime.Now.ToString(), DateTime.Now.ToString(), culture: null));
			return View();
		}

		// POST: tservices/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "srvc_id,srvc_na,crt_dt")] tservice tservice)
		{
			if (ModelState.IsValid)
			{
				db.tservices.Add(tservice);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(tservice);
		}

		// GET: tservices/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tservice tservice = await db.tservices.FindAsync(id);
			if (tservice == null)
			{
				return HttpNotFound();
			}
			return View(tservice);
		}

		// POST: tservices/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "srvc_id,srvc_na,crt_dt")] tservice tservice)
		{
			try
			{
				if (ModelState.IsValid)
				{
					db.Entry(tservice).State = EntityState.Modified;
					await db.SaveChangesAsync();
					return RedirectToAction("Index");
				}
				else
				{
					return View(tservice);
				}
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMsg = "Unable to save your changes due to a data error.  Make sure there is not a duplicate record.";
				return View(tservice);
			}
		}


		// GET: tservices/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			tservice tservice = await db.tservices.FindAsync(id);
			if (tservice == null)
			{
				return HttpNotFound();
			}
			return View(tservice);
		}

		// POST: tservices/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			try
			{
				tservice tservice = await db.tservices.FindAsync(id);
				db.tservices.Remove(tservice);
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
