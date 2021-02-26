using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace qwerty.Controllers
{
    public class OwnerController : Controller
    {
        Venue_BookingEntities1 db = new Venue_BookingEntities1();
        // GET: Owner/index
        public ActionResult Index(string searching)
        {
           
            row();

            
                using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
                {
                    return View(db.Owners.Where(x => x.Name.Contains(searching) || searching == null ).ToList());

                }

        }
        public ActionResult reset()
        {
            return View();
        }

        // GET: Owner/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        public ActionResult Create(Owner owner)
        {
            try
            {
                using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
                {
                    db.Owners.Add(owner);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Edit/5
        public ActionResult Edit(int id)
        {
            using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
            {
                return View(db.Owners.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: Owner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Owner owner)
        {
            try
            {
                // TODO: Add update logic here
                using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
                {
                    db.Entry(owner).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Owner/Delete/5
        public ActionResult Delete(int id)
        {
            using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
            {
                return View(db.Owners.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: Owner/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Owner owner)
        {
            try
            {
                // TODO: Add delete logic here
                using (Venue_BookingEntities1 db = new Venue_BookingEntities1())
                {
                    owner = db.Owners.Where(x => x.ID == id).FirstOrDefault();
                    db.Owners.Remove(owner);
                    db.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //rowscount
        public ActionResult row()
        {
            ViewBag.Count = db.Owners.Count();
            return View();
        }
    }
}
