using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ActionToView.Models;

namespace ActionToView.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile

        // Value passing from Action to View ***********************************************************************************************************************************
        // ViewBag and ViewData *****************************
        public ActionResult Index()
        {   // ViewBag
            ViewBag.helloMsg = "Hi There!";
            // ViewData
            ViewData["name"] = "Muntasir Maruf";

            return View();
        }

        // Model Binding *****************************
        public ActionResult Education()
        {
            // Create objects of EducationClass
            var degree1 = new EducationClass()
            {
                Institute = "Rajshahi Collegiate School",
                Degree = "SSC",
                Year = "2018",
                Result = "5.00 GPA"
            };
            var degree2 = new EducationClass()
            {
                Institute = "Rajshahi Govt. City College",
                Degree = "HSC",
                Year = "2020",
                Result = "5.00 GPA"
            };

            EducationClass[] degrees = new EducationClass[] { degree1, degree2 };
            return View(degrees);
        }

        // Model Binding *****************************
        public ActionResult Projects()
        {
            // Create objects of ProjectClass
            ProjectClass project1 = new ProjectClass();

            project1.Title = "E-Store";
            project1.Course = "OOP1";
            project1.Description = "This is a Java project of Object Oriented Programming 1 Course";

            ProjectClass project2 = new ProjectClass();
            project2.Title = "Eventify";
            project2.Course = "OOP2";
            project2.Description = "This is a C# project of Object Oriented Programming 2 Course";

            ProjectClass[] projects = { project1, project2 };

            return View(projects);
        }

        // ViewBag and ViewData *****************************
        public ActionResult Reference()
        {
            // ViewBag
            ViewBag.Name = "John Doe";
            // ViewData
            ViewData["Email"] = "john@gmail.com";

            return View();
        }

        // Value passing from View to Action ***********************************************************************************************************************************
        // Http Request Base Object *****************************
        public ActionResult Input()
        {
            ViewBag.Username = Request["Username"];
            ViewBag.Email = Request["Email"];
            ViewBag.Password = Request["Password"];

            return View();
        }

        // FormCollection Object *****************************
        [HttpGet] // Add this attribute to avoid ambiguous method error
        public ActionResult EducationInput()
        {
            return View();
        }

        [HttpPost] // Add this attribute to avoid ambiguous method error
        public ActionResult EducationInput(FormCollection fc)
        {
            ViewBag.Institute = fc["Institute"];
            ViewBag.Degree = fc["Degree"];
            ViewBag.Year = fc["Year"];
            ViewBag.Result = fc["Result"];

            return View();
        }


        // Variable Name Mapping *****************************
        public ActionResult ProjectInput(String PTitle, String Course, String Description)
        {
            ViewBag.PTitle = PTitle;
            ViewBag.Course = Course;
            ViewBag.Description = Description;

            return View();
        }

        // Model Binding *****************************

        [HttpGet] // Add this attribute to avoid ambiguous method error
        public ActionResult ProjectInputModelBinding()
        {

            return View(new ProjectInputModel());
        }

        [HttpPost] // Add this attribute to avoid ambiguous method error
        public ActionResult ProjectInputModelBinding(ProjectInputModel pm)
        {
            if(ModelState.IsValid)
            {
                ViewBag.TitleMB = pm.TitleMB;
                ViewBag.CourseMB = pm.CourseMB;
                ViewBag.DescriptionMB = pm.DescriptionMB;
                return View();
            }
            
            return View(pm);
        }


        // Validation *********************************************************************
        public ActionResult StudentInput(StudentInputClass s)
        {
            if (ModelState.IsValid)
            {

                return RedirectToAction("About", "Home");
            }

            return View(s);
        }
    }
}