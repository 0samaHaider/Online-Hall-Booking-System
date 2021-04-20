using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;
using System.Data.SqlClient;
using System.Data;

namespace qwerty.Controllers
{
    public class AccountController : Controller
    {
       
        readonly SqlConnection Con = new SqlConnection(@"Data Source=OSAMAHAIDER;Initial Catalog=Venue Booking;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework");
        Venue_BookingEntities1 db = new Venue_BookingEntities1();
        UserModel db1 = new UserModel();
        //rowscount
        public ActionResult row()
        {
            ViewBag.Count = db.Owners.Count();
            ViewBag.User = db1.Users.Count();
            ViewBag.User = db1.Users.Count();
            ViewBag.User = db1.Users.Count();

            return View();
        }
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }
        


        [HttpPost]
        public ActionResult Verify( Account Acc)
        {
            row();
            if (Acc.Name == "admin" && Acc.Password == "qwerty")
            {
                Session["Name"] = Acc.Name;
                return View("Verify");
            }
            
                        if (ModelState.IsValid)
                        {
                            using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
                            {
                                var obj = db.Owners.Where(a => a.Name.Equals(Acc.Name) && a.Phone.Equals(Acc.Password)).FirstOrDefault();
                                if (obj != null)
                                {
                                    Session["Name"] = Acc.Name;
                                    return View("Verify1");
                                }
                            }
                        }
           if (ModelState.IsValid)
            {
                using (UserModel db1 = new UserModel())
                {
                    var obj = db1.Users.Where(a => a.Name.Equals(Acc.Name) && a.Mobile.Equals(Acc.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Name"] = Acc.Name;
                        return View("Verify4");
                    }
                }
            }

            //return View();
            return HttpNotFound();

        }
    }
}