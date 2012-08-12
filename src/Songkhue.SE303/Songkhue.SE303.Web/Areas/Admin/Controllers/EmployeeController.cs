using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Songkhue.SE303.Core;
using Songkhue.SE303.Web.Models;

namespace Songkhue.SE303.Web.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        Dev_Sk_SE303Entities db = new Dev_Sk_SE303Entities();
        public ActionResult Index()
        {
            return View(EmployeeModels.employeeList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id)
        {
            return View(EmployeeModels.detail(id));
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Employee/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                EmployeeModels.create(collection);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Employee/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View(EmployeeModels.detail(id));
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                EmployeeModels.edit(collection, id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(EmployeeModels.detail(id));
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                EmployeeModels.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
