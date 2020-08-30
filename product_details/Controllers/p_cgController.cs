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
    public class p_cgController : Controller
    {
        private Model1 db = new Model1();

        // GET: p_cg
        public async Task<ActionResult> Index()
        {
            return View(await db.p_cg.ToListAsync());
        }

        // GET: p_cg/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_cg p_cg = await db.p_cg.FindAsync(id);
            if (p_cg == null)
            {
                return HttpNotFound();
            }
            return View(p_cg);
        }

        // GET: p_cg/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_cg/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "cg_id,cg_name")] p_cg p_cg)
        {
            if (ModelState.IsValid)
            {
                db.p_cg.Add(p_cg);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(p_cg);
        }

        // GET: p_cg/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_cg p_cg = await db.p_cg.FindAsync(id);
            if (p_cg == null)
            {
                return HttpNotFound();
            }
            return View(p_cg);
        }

        // POST: p_cg/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "cg_id,cg_name")] p_cg p_cg)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_cg).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p_cg);
        }

        // GET: p_cg/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_cg p_cg = await db.p_cg.FindAsync(id);
            if (p_cg == null)
            {
                return HttpNotFound();
            }
            return View(p_cg);
        }

        // POST: p_cg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            p_cg p_cg = await db.p_cg.FindAsync(id);
            db.p_cg.Remove(p_cg);
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
