using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Laboratorio08.Models;
using Laboratorio08.Handlers;

namespace Laboratorio08.Controllers
{
    public class ProductsController : Controller
    {
        private ProductsHandler ProductsHandler;

        public ProductsController() {
            ProductsHandler = new ProductsHandler();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllProducts() {
            var products = ProductsHandler.GetAll();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}