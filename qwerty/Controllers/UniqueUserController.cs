using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;

namespace qwerty.Controllers
{
    public class UniqueUserController : Controller
    {

        // GET: UniqueUser
        
        public ActionResult Index(string Name)
        {
            try
            {


                using (UserModel db1 = new UserModel())
                {
                    //string sid = HttpContext.Session.SessionID;
                    Name = Session["Name"].ToString();


                    var drafts = db1.Users.Where(d => d.Name == Name).ToList();

                    return View(drafts);

                }
            }
            catch
            {
                return Content("Session Expire , Please Relogin !!");
            }
             

          
           /* using (UserModel db1 = new UserModel())
            {
                var obj = db1.Users.Where(a => a.Name.Equals(Acc.Name) && a.Mobile.Equals(Acc.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["Name"] = Acc.Name;
                    var drafts = db1.Users.Where(d => d.Name == Acc.Name).ToList();
                return View(drafts);
                }*/
            

        }

        // GET: UniqueUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UniqueUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniqueUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UniqueUser/Edit/5
        public ActionResult Edit(int id)
        {
            using (UserModel db1 = new UserModel())
            {
                return View(db1.Users.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: UniqueUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            
            try
            {
                // TODO: Add update logic here
                using (UserModel db1 = new UserModel())
                {
                    db1.Entry(user).State = EntityState.Modified;
                    db1.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UniqueUser/Delete/5
        public ActionResult Delete(int id)
        {
            using (UserModel db1 = new UserModel())
            {
                return View(db1.Users.Where(x => x.ID == id).FirstOrDefault());

            }
        }
        public ActionResult Venue( string searching)
        {
            using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
            {
                return View(db3.venueinfoes.Where(x => x.Venue_Location.Contains(searching) || searching == null).ToList());

               // return View(db3.venueinfoes.ToList());
            }
        }


        // POST: UniqueUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                using (UserModel db1 = new UserModel())
                {
                    user = db1.Users.Where(x => x.ID == id).FirstOrDefault();
                    db1.Users.Remove(user);
                    db1.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
