using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using product_details.ViewModel;
using product_details;

namespace product_details.Controllers
{
    public class p_sdController : Controller
    {
        Model1 db = new Model1();
        // GET: p_sd
        public ActionResult Index()
        {
            var sd = from pd in db.p_dt
                     join om in db.p_od on pd.p_id equals om.p_id
                     group om.o_num by new
                     {
                         om.o_num,
                         pd.p_name
                     }
                     into salerdetail
                     orderby salerdetail.Key.o_num descending
                     select new { ct_num = salerdetail.Sum(), pd_name = salerdetail.Key.p_name };
                     //select new p_sd { pd_name = pd.p_name, ct_num = om.o_num };
            return View(sd);
        }
    }
}