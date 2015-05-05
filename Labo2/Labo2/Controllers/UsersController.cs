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
        [HttpGet]
        public ActionResult Inscription()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Subscribe(User newUser)
        {
            User users = new User(Session["MainDB"]);
            if (!String.IsNullOrEmpty(newUser.Prenom))
            {
                if (!String.IsNullOrEmpty(newUser.Nom))
                {
                    users.Prenom = newUser.Prenom;
                    users.Nom = newUser.Nom;
                    users.Telephone = newUser.Telephone;
                    users.Code_Postal = newUser.Code_Postal;
                    users.Naissance = newUser.Naissance;
                    users.Sexe = newUser.Sexe;
                    users.Etat_Civil = newUser.Etat_Civil;

                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file != null && file.ContentLength > 0)
                        {
                            users.Picture = Guid.NewGuid().ToString();
                            file.SaveAs(Server.MapPath(@"~\Avatars\") + users.Picture + ".png");
                        }
                    }
                    users.Insert();
                    return RedirectToAction("Index", "Home"); ;
                }
                else
                {
                    TempData["Notice"] = "Le mot de passe est vide...";
                }
            }
            else
            {
                TempData["Notice"] = "Cet usager existe déjà...";
            }
            return View(newUser);
        }
	}
}