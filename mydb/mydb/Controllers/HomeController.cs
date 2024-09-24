using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mydb.Models;

namespace mydb.Controllers
{
    public class HomeController : Controller
    {
        mydbEntities1 db = new mydbEntities1();
        // GET: Home
         //public ActionResult Index(string searchTerm)
        //{
            //List<student> std = db.students.ToList();
            //return View(std);

            //where id is <2:=== List<student> std = db.students.Where(s => s.Id < 2).ToList();
            //where name is like #name:=== var std = db.students.Where(s => s.lname.Contains("a")).ToList();

           // var students = db.students.AsQueryable();
            //if (!string.IsNullOrEmpty(searchTerm))
            //{
              //  students = students.Where(s => s.fname.Contains(searchTerm) || s.lname.Contains(searchTerm));
           // }
           // return View(students.ToList());
       // }
        [HttpGet]
        public ActionResult Index(string searchTerm, string searchItem)
        {
            List<student> std;
            if (!string.IsNullOrEmpty(searchTerm))
            {
                switch (searchItem)
                {
                    case "fname":
                        std = db.students.Where(s => s.fname.Contains(searchTerm)).ToList();
                        break;
                    case "lname":
                        std = db.students.Where(s => s.lname.Contains(searchTerm)).ToList();
                        break;
                    default:
                        std = db.students.Where(s => s.fname.Contains(searchTerm) || s.lname.Contains(searchTerm)).ToList();
                        break;
                }
            }
            else
            {
                std = db.students.ToList();
            }
            return View(std);
        }

        public ActionResult Delete(int id) 
        {
            student std = db.students.Find(id);
            db.students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult DeleteSelected(int[] selectedIds)
        {
            if (selectedIds != null)
            { 
                foreach(int id in selectedIds)
                {
                    student student = db.students.Find(id);
                    if(student != null)
                    {
                        db.students.Remove(student);
                    }
                }
                db.SaveChanges();
            }
            return RedirectToAction("index");
        
        }

        public ActionResult Registration(int? id)
        {
            student std = db.students.Find(id);
            return View(std);
        }
        [HttpPost]

        public ActionResult Registration(student s)
        {
            if(s.Id != 0)
            {
                //update code
                student std = db.students.Find(s.Id);
                std.fname = s.fname;
                std.lname = s.lname;
            }
            else 
            {
                db.students.Add(s);
            }
            db.SaveChanges();
            return RedirectToAction("index");
            
        }

    }
}