using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;

namespace qwerty.Controllers
{
    public class VeiwBookingController : Controller
    {
        Venue_BookingEntities1 db = new Venue_BookingEntities1();
        UserModel db1 = new UserModel();
        //rowscount
        public ActionResult row()
        {
            ViewBag.Count = db.Owners.Count();
            ViewBag.User = db1.Users.Count();
            return View();
        }
        // GET: VeiwBooking
        public ActionResult Index(string searching)
        {
            using (UserModel db1 = new UserModel())
            {
                if (searching != null)
                {
                    return View(db1.Users.Where(x => x.Status == "Accepted" && x.Name.Contains(searching) || searching == null).ToList());
                }
                else
                {
                    return View(db1.Users.Where(x => x.Status == "Accepted").ToList());

                }
                // var drafts = db1.Users.Where(d => d.Status == "Accepted").ToList();
                //  return View(drafts);
            }
        }
        public ActionResult dashboard ()
        {
            row();
            return View();
        }
        public ActionResult ownerdashboard()
        {
            //row();
            return View();
        }
        public ActionResult UserDb()
        {
            //row();
            return View();
        }

        // GET: VeiwBooking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VeiwBooking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VeiwBooking/Create
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

        // GET: VeiwBooking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VeiwBooking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: VeiwBooking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VeiwBooking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
