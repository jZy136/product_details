using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using product_details;

namespace product_details.Controllers
{
    public class p_dtController : Controller
    {
        private Model1 db = new Model1();

        // GET: p_dt
        public ActionResult Index(string searchString, string cidString)
        {
            var p_dt = db.p_dt.Include(p => p.p_cg);
            ViewBag.cidString = new SelectList(db.p_cg, "cg_id", "cg_name");
            if (!String.IsNullOrEmpty(searchString))
            {
                p_dt = p_dt.Where(p => p.p_name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(cidString))
            {
                int cid = int.Parse(cidString);
                p_dt = p_dt.Where(p => p.cg_id.Equals(cid));
            }
            return View(p_dt.ToList());
        }

        public ActionResult Mall(string searchString, string cidString)
        {
            var p_dt = db.p_dt.Include(p => p.p_cg);
            ViewBag.cidString = new SelectList(db.p_cg, "cg_id", "cg_name");
            if (!String.IsNullOrEmpty(searchString))
            {
                p_dt = p_dt.Where(p => p.p_name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(cidString))
            {
                int cid = int.Parse(cidString);
                p_dt = p_dt.Where(p => p.cg_id.Equals(cid));
            }
            return View(p_dt.ToList());
        }

        

        public ActionResult AddToCart(int p_id)
        {
            p_ct cart = new p_ct();
            cart.p_id = p_id;
            cart.c_num = 1;
            db.p_ct.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Mall");
        }

        // GET: p_dt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dt p_dt = db.p_dt.Find(id);
            if (p_dt == null)
            {
                return HttpNotFound();
            }
            return View(p_dt);
        }

        // GET: p_dt/Create
        public ActionResult Create()
        {
            ViewBag.cg_id = new SelectList(db.p_cg, "cg_id", "cg_name");
            return View();
        }

        // POST: p_dt/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "p_id,p_name,cg_id,p_num,p_price,p_img")] p_dt p_dt)
        {
            if (ModelState.IsValid)
            {
                db.p_dt.Add(p_dt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cg_id = new SelectList(db.p_cg, "cg_id", "cg_name", p_dt.cg_id);
            return View(p_dt);
        }
        

        // GET: p_dt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dt p_dt = db.p_dt.Find(id);
            if (p_dt == null)
            {
                return HttpNotFound();
            }
            ViewBag.cg_id = new SelectList(db.p_cg, "cg_id", "cg_name", p_dt.cg_id);
            return View(p_dt);
        }

        // POST: p_dt/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "p_id,p_name,cg_id,p_num,p_price,p_img")] p_dt p_dt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p_dt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cg_id = new SelectList(db.p_cg, "cg_id", "cg_name", p_dt.cg_id);
            return View(p_dt);
        }

        // GET: p_dt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            p_dt p_dt = db.p_dt.Find(id);
            if (p_dt == null)
            {
                return HttpNotFound();
            }
            return View(p_dt);
        }

        // POST: p_dt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            p_dt p_dt = db.p_dt.Find(id);
            db.p_dt.Remove(p_dt);
            db.SaveChanges();
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
