using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        mydbEntities db = new mydbEntities();
        public ActionResult Index()
        {
            
            Student std = new Student();


            List<Student> stds = db.Students.ToList();

            db.Students.Add(std);
            db.SaveChanges();
            return View(stds);
        }
        public ActionResult Registration(int? id)
        {
            Student std = db.Students.Find(id);
            return View(std);
        }
        [HttpPost]
        public ActionResult Registration(Student s)
        {   
            if(s.Id == 0)
            {
                Student std = db.Students.Find(s.Id);
                std.fname = s.fname;
                std.lname = s.lname;
            }
            else
            {

                db.Students.Add(s);
            }
            db.SaveChanges ();
            return RedirectToAction("Index");
        }
    }
}