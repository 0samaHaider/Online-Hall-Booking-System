using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using qwerty.Models;
using System.Net.Mail;
using System.Net;


namespace qwerty.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            return View();
        }

        // GET: SignUp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SignUp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SignUp/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(user.Email);
                // mail.To.Add("osamakiani32@gmail.com");
                mail.From = new MailAddress("artisticmania8@gmail.com", "Hotel Di Wanne");
                mail.Subject = "Register Your Account";
                string output = " Dear " + user.Name + " ,  \nYour User Name and Password for Login is  "+ user.Name + " , "+user.Mobile+" \n Thank You. ";
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
                ModelState.Clear();
                ViewBag.SuccessMessage = "Account Created Successfully !! Please Wait for the Confirmation Mail then Login Through Login Page !!";
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        // GET: SignUp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SignUp/Edit/5
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

        // GET: SignUp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SignUp/Delete/5
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
