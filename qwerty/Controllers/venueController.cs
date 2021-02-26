using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;
using System.Data.Entity;


namespace qwerty.Controllers
{
    public class venueController : Controller
    {
       Venue_BookingEntities3 db3 = new Venue_BookingEntities3();

        //for dropdownlist 
        public ActionResult dropdownlist()
        {
            var items = db3.venueinfoes.ToList();
            if (items != null)
            {
                ViewBag.data = items;
            }

            return View();
        }
        // GET: venue
        public ActionResult Index()
        {
            using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
            {
                return View(db3.venueinfoes.ToList());
            }
        }

        // GET: venue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: venue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: venue/Create
        [HttpPost]
        public ActionResult Create(venueinfo venueinfo)
        {
            try
            {


                // TODO: Add insert logic here
                using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
                {
                    db3.venueinfoes.Add(venueinfo);
                    db3.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return Content("ERROR , PLEASE RE-LOGIN !!");
            }
           
        }

        // GET: venue/Edit/5
        public ActionResult Edit(int id)
        {

            using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
            {
                return View(db3.venueinfoes.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: venue/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, venueinfo venueinfo)
        {
            try
            {
                using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
                {
                    db3.Entry(venueinfo).State = EntityState.Modified;
                    db3.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: venue/Delete/5
        public ActionResult Delete(int id)
        {
            using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
            {
                return View(db3.venueinfoes.Where(x => x.Id == id).FirstOrDefault());

            }
        }

        // POST: venue/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, venueinfo venueinfo)
        {
            try
            {
                using (Venue_BookingEntities3 db3 = new Venue_BookingEntities3())
                {
                    venueinfo = db3.venueinfoes.Where(x => x.Id == id).FirstOrDefault();
                    db3.venueinfoes.Remove(venueinfo);
                    db3.SaveChanges();
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
