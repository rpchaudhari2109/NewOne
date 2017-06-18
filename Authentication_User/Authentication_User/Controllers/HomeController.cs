using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthenticationUser.Models;

//this commit from myownbranch branch

//this is first check in from visual studio

namespace AuthenticationUser.Controllers
{
    public class HomeController : Controller
    {
        private ClsPrac2Entities_Context db = new ClsPrac2Entities_Context();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.All_User.ToList());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            All_User all_user = db.All_User.Find(id);
            if (all_user == null)
            {
                return HttpNotFound();
            }
            return View(all_user);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(All_User allUser)
        {
            if (ModelState.IsValid)
            {
                db.All_User.Add(allUser);
                allUser.AddedDate = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allUser);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            All_User allUser = db.All_User.Find(id);
            if (allUser == null)
            {
                return HttpNotFound();
            }
            return View(allUser);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(All_User allUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allUser);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            All_User allUser = db.All_User.Find(id);
            if (allUser == null)
            {
                return HttpNotFound();
            }
            return View(allUser);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            All_User allUser = db.All_User.Find(id);
            db.All_User.Remove(allUser);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(FormCollection formcl)
        {
            var name = formcl["Email"];
            var Pswd = formcl["Password"];

            var result = db.All_User.Where(x => x.Email == name && x.Password == Pswd).FirstOrDefault();
            if (result == null)
            {
                return View();
            }
            return RedirectToAction("WelCome");
        }
 
        public ActionResult WelCome()
        {
            return View();
        }
    }
}