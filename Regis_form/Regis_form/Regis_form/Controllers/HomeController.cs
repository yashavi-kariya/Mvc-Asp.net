using Regis_form.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Regis_form.Controllers
{
    public class HomeController : Controller
    {
        studentEntities se = new studentEntities();
        // GET: Home
        public ActionResult Index()
        {
            List<student> s = se.students.ToList();
            

            return View(s);
        }
        public ActionResult registration(student s)
        {
             se.students.Add(s);
              se.SaveChanges();

            return View();
        }
    }
}
