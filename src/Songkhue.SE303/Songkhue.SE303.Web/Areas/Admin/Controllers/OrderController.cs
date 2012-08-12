using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songkhue.SE303.Core;
using Songkhue.SE303.Core.Order;
using Songkhue.SE303.Core.Order.Models;


namespace Songkhue.SE303.Web.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private OrderManager _orderManager = new OrderManager();
        //
        // GET: /Admin/Order/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Grid()
        {

            var entities = _orderManager.GetOrders();

            var model = OrderModel.ToModelList(entities);

            return View(model);
        }

    }
}
