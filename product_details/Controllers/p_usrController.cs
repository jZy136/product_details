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
    public class p_usrController : Controller
    {
        private Model1 db = new Model1();

        // GET: p_usr
        public async Task<ActionResult> Index()
        {
            return View(await db.p_usr.ToListAsync());
        }

        // GET: p_usr/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usr p_usr = await db.p_usr.FindAsync(id);
            if (p_usr == null)
            {
                return HttpNotFound();
            }
            return View(p_usr);
        }

        // GET: p_usr/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: p_usr/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "u_id,u_name,u_pwd")] p_usr p_usr)
        {
            if (ModelState.IsValid)
            {
                db.p_usr.Add(p_usr);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(p_usr);
        }

        // GET: p_usr/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usr p_usr = await db.p_usr.FindAsync(id);
            if (p_usr == null)
            {
                return HttpNotFound();
            }
            return View(p_usr);
        }

        // POST: p_usr/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "u_id,u_name,u_pwd")] p_usr p_usr)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_usr).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(p_usr);
        }

        // GET: p_usr/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_usr p_usr = await db.p_usr.FindAsync(id);
            if (p_usr == null)
            {
                return HttpNotFound();
            }
            return View(p_usr);
        }

        // POST: p_usr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            p_usr p_usr = await db.p_usr.FindAsync(id);
            db.p_usr.Remove(p_usr);
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
