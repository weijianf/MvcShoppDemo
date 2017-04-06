using NF.WJF.BLL;
using NF.WJF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NF.WJF.Shopp.UI.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            List<Product> result = new ProductBll().GetDataAll();
            ViewBag.TypeName = new ProductBll().GetTypeName();
            return View(result);
        }
        public ActionResult GetProByType(string data)
        {
            List<Product> Pro;
            if (data == null)
            {
                Pro = new ProductBll().GetDataAll();
            }
            else
            {
                Pro = new ProductBll().GetDataByType(data);
            }
            return PartialView(Pro);
        }
        public ActionResult ProductInfo(int id)
        {
            var result =new ProductBll().GetDataByID(id);
            ViewBag.Item = result;
            return View(result);
        }

    }
}
