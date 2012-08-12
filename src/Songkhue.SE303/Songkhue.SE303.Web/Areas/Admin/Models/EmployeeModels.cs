using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Songkhue.SE303.Core;
using System.Web.Mvc;
namespace Songkhue.SE303.Web.Models
{
    public class EmployeeModels
    {
        public static void create(FormCollection collection)
        {
            using(var db = new Dev_Sk_SE303Entities())
            {
                Sk_User u = new Sk_User();
                u.Username = collection["Username"].ToString();
                u.CreatedOn = DateTime.Today;
                u.Email = collection["Email"].ToString();
                db.Sk_User.AddObject(u);
                db.SaveChanges();
            }
        }
        public static void edit(FormCollection collection,int id)
        {
            using (var db = new Dev_Sk_SE303Entities())
            {
                Sk_User u = db.Sk_User.FirstOrDefault(c => c.Id == id);
                u.Username = collection["Username"].ToString();
                u.CreatedOn = DateTime.Today;
                u.Email = collection["Email"].ToString();
                db.SaveChanges();
            }
        }
        public static Sk_User detail(int id)
        {
            using (var db = new Dev_Sk_SE303Entities())
            {
                return db.Sk_User.FirstOrDefault(c => c.Id == id);
            }
            return null;
        }
        public static void delete(int id)
        {
            using (var db = new Dev_Sk_SE303Entities())
            {
                db.DeleteObject(db.Sk_User.FirstOrDefault(c => c.Id == id));
                db.SaveChanges();
            }
        }
        public static List<Sk_User> employeeList()
        {
            using (var db = new Dev_Sk_SE303Entities())
            {
                return db.Sk_User.ToList();
            }
            return null;
        }
    }
}