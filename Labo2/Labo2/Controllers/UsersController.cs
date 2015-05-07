using Labo2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Labo2.Controllers
{
   public class UsersController : Controller
   {
      //
      // GET: /Users/
      public ActionResult Index()
      {
         return View();
      }
      public ActionResult Lister()
      {
         User users = new User(Session["MainDB"]);
         users.SelectAll();
         return View(users);
      }
      public ActionResult Inscription()
      {
         return View();
      }
      public ActionResult Modify(User user)
      {
         return View(user);
      }
      [HttpGet]
      public ActionResult InscriptionTest()
      {
         ViewBag.Sexe = new SelectList(new List<string> { "Masculin", "Feminin" }, "Sexe", "Sexe");

         return View();
      }
      [HttpPost]
      public ActionResult InscriptionTest(User user)
      {
         if (ModelState.IsValid)
         {
            User users = new User(Session["MainDB"]);
            users.InsertRecord(user);

            return this.RedirectToAction("Index");
         }
         return View(user);
      }
   }
}