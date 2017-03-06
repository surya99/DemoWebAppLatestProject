using DemoLoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoLoginApp.Controllers
{
    public class LoginDemoController : Controller
    {

        SuryaTechDBEntities _dbEntites = new SuryaTechDBEntities();
        // GET: /LoginDemo/
        public ActionResult Index()
        {
            tbl_RegisterUser model = new tbl_RegisterUser();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(tbl_RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Welcome");
            }
            else
            {
                return View(model);
            }
            
        }
        [HttpPost]
        public ActionResult Register(tbl_RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                _dbEntites.tbl_RegisterUser.Add(model);
                _dbEntites.SaveChanges();
                return Json("Reigstration Successfull", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return RedirectToAction("Index", model);
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_RegisterUser model)
        {
            return View(model);
        }
	}
}