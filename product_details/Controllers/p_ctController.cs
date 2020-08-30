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
    public class p_ctController : Controller
    {
        private Model1 db = new Model1();

        // GET: p_ct
        public async Task<ActionResult> Index()
        {
            var p_ct = db.p_ct.Include(p => p.p_dt);
            return View(await p_ct.ToListAsync());
        }

        // GET: p_ct/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_ct p_ct = await db.p_ct.FindAsync(id);
            if (p_ct == null)
            {
                return HttpNotFound();
            }
            return View(p_ct);
        }

        // GET: p_ct/Create
        public ActionResult Create()
        {
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name");
            return View();
        }

        // POST: p_ct/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "c_id,p_id,c_num")] p_ct p_ct)
        {
            if (ModelState.IsValid)
            {
                db.p_ct.Add(p_ct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_ct.p_id);
            return View(p_ct);
        }

        // GET: p_ct/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_ct p_ct = await db.p_ct.FindAsync(id);
            if (p_ct == null)
            {
                return HttpNotFound();
            }
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_ct.p_id);
            return View(p_ct);
        }

        // POST: p_ct/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "c_id,p_id,c_num")] p_ct p_ct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_ct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.p_id = new SelectList(db.p_dt, "p_id", "p_name", p_ct.p_id);
            return View(p_ct);
        }

        // GET: p_ct/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_ct p_ct = await db.p_ct.FindAsync(id);
            if (p_ct == null)
            {
                return HttpNotFound();
            }
            return View(p_ct);
        }

        // POST: p_ct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            p_ct p_ct = await db.p_ct.FindAsync(id);
            db.p_ct.Remove(p_ct);
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
