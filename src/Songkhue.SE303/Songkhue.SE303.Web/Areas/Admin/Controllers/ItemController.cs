using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songkhue.SE303.Core.Item;
using Songkhue.SE303.Core;

namespace Songkhue.SE303.Web.Areas.Admin.Controllers
{
    public class ItemController : Controller
    {
        ItemManager _itemManager = new ItemManager();
        //
        // GET: /Admin/Item/

        //public ActionResult Index()
        //{
        //    var entities = _itemManager.GetItemsByGroup(1);

        //    return View(entities);
        //}

        public ActionResult Index(int? group)
        {
            IEnumerable<Sk_Item> entities ;
            if (group.HasValue)
            {
                entities = _itemManager.GetItemsByGroup(group.Value);
            }
            else
            {
                entities = _itemManager.GetItemsByGroup(1);
            }

            return View(entities);
        }
    }
}
