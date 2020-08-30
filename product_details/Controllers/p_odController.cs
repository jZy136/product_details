using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using product_details;

namespace product_details.Controllers
{
    public class p_odController : Controller
    {
        private Model1 db = new Model1();

        // GET: p_od
        public async Task<ActionResult> Index()
        {
            var p_od = db.p_od.Include(p => p.p_dt);
            return View(await p_od.ToListAsync());
        }

        public async Task<ActionResult> Order()
        {
            var p_od = db.p_od.Include(p => p.p_dt);
            return View(await p_od.ToListAsync());
        }

        // GET: p_od/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_od p_od = await db.p_od.FindAsync(id);
            if (p_od == null)
            {
                return HttpNotFound();
            }
            return View(p_od);
        }

        // GET: p_od/Create
        public ActionResult Create()
        {
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name");
            return View();
        }

        // POST: p_od/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "o_id,p_id,o_num")] p_od p_od)
        {
            if (ModelState.IsValid)
            {
                db.p_od.Add(p_od);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_od.p_id);
            return View(p_od);
        }

        // GET: p_od/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_od p_od = await db.p_od.FindAsync(id);
            if (p_od == null)
            {
                return HttpNotFound();
            }
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_od.p_id);
            return View(p_od);
        }

        // POST: p_od/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "o_id,p_id,o_num")] p_od p_od)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_od).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_od.p_id);
            return View(p_od);
        }

        // GET: p_od/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_od p_od = await db.p_od.FindAsync(id);
            if (p_od == null)
            {
                return HttpNotFound();
            }
            return View(p_od);
        }

        // POST: p_od/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            p_od p_od = await db.p_od.FindAsync(id);
            db.p_od.Remove(p_od);
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
