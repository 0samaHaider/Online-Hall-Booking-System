using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using qwerty.Models;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;

namespace qwerty.Controllers
{
    public class ReqOfUsersController : Controller
    {
        // GET: ReqOfUsers
        public ActionResult Index1(string searching)
        {
            using (UserModel db1 = new UserModel())
            {
                return View(db1.Users.Where(x => x.Name.Contains(searching) || searching == null).ToList());
            }
        }

        // GET: ReqOfUsers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ReqOfUsers/Create
        
        public ActionResult Create1()
        {
            return View();
        }

        // POST: ReqOfUsers/Create
        [HttpPost]
        public ActionResult Create1(User user)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                // mail.To.Add("osamakiani32@gmail.com");
                mail.From = new MailAddress("artisticmania8@gmail.com", "Hotel Di Wanne");
                mail.Subject = "Register Your Request";
                string output = " Dear " + user.Name + " ,  \n We Register  Your request to Book a Room, \n You Will Get A Confirmation Message Soon !! \n Thank You. ";
                mail.Body = output;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("artisticmania8@gmail.com", "42Art91429142Art914291");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.ErrorMessage = "Email send";


            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Email not found or matched";

            }
            try
            {
                using (UserModel db1 = new UserModel())
                {
                    db1.Users.Add(user);
                    db1.SaveChanges();
                }
                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReqOfUsers/Edit/5
        public ActionResult Edit_(int id)
        {
            using (UserModel db1 = new UserModel())
            {
                return View(db1.Users.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: ReqOfUsers/Edit/5
        [HttpPost]
        public ActionResult Edit_(int id, User user)
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                // mail.To.Add("osamakiani32@gmail.com");
                mail.From = new MailAddress("artisticmania8@gmail.com", "Hotel Di Wanne");
                mail.Subject = "Confirmation Message";
                string output = " Dear " + user.Name + " ,  \n Your Request For Register a Room is " + user.Status + " . \n Enjoy Your Time With Hotel Di Wanne .\n Thank You !! ";
                mail.Body = output;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Credentials = new NetworkCredential("artisticmania8@gmail.com", "42Art91429142Art914291");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                ViewBag.ErrorMessage = "Email send";


            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Email not found or matched";

            }
            try
            {
                // TODO: Add update logic here
                using (UserModel db1 = new UserModel())
                {
                    db1.Entry(user).State = EntityState.Modified;
                    db1.SaveChanges();
                }

                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
        }

        // GET: ReqOfUsers/Delete/5
        public ActionResult Delete(int id)
        {
            using (UserModel db1 = new UserModel())
            {
                return View(db1.Users.Where(x => x.ID == id).FirstOrDefault());

            }
        }

        // POST: ReqOfUsers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User user)
        {

            try
            {
                ///////////////////////////////////////////////// TODO: Add delete logic here
                using (UserModel db1 = new UserModel())
                {
                    user = db1.Users.Where(x => x.ID == id).FirstOrDefault();
                    db1.Users.Remove(user);
                    db1.SaveChanges(); MailMessage mail = new MailMessage();
                    mail.To.Add(user.Email);
                    // mail.To.Add("osamakiani32@gmail.com");
                    mail.From = new MailAddress("artisticmania8@gmail.com", "Hotel Di Wanne");
                    mail.Subject = "Confirmation Message";
                    string output = " Dear " + user.Name + " ,  \n Your Request For Register a Room is Deleted Due to Some Reasons. \n Please Contact With Us At Our Number (+32 89 30 47 70) .\n Thank You !! ";
                    mail.Body = output;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Credentials = new NetworkCredential("artisticmania8@gmail.com", "42Art91429142Art914291");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    ViewBag.ErrorMessage = "Email send";


                }

                return RedirectToAction("Index1");
            }
            catch
            {
                return View();
            }
            
           
            
        }
    }
}
