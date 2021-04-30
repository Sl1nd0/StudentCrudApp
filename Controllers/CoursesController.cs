using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentCrudApp.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        public ActionResult Index()
        {
            var context = new ConsortoUniversity1Entities1();
            var courses = context.COURSES;

            return View(courses.ToList<COURS>());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            var context = new ConsortoUniversity1Entities1();
            //var courses = context.COURSES;
            var students = context.STUDENTS;
            var result = students.Where(s => s.CoureseId == id).ToList<STUDENT>();

            return View(result);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(COURS course)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new ConsortoUniversity1Entities1();
                var courses = context.COURSES;
                courses.Add(course);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new ConsortoUniversity1Entities1();
            var courses = context.COURSES;
            var result = courses.Where(s => s.CoureseId == id).FirstOrDefault();

            return View(result);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, COURS course)
        {
            try
            {
                // TODO: Add update logic here
                // TODO: Add update logic here
                var context = new ConsortoUniversity1Entities1();
                var courses = context.COURSES;
                context.Entry(course).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {

            var context = new ConsortoUniversity1Entities1();
            var courses = context.COURSES;
            var result = courses.Where(s => s.CoureseId == id).FirstOrDefault();

            return View();
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                // TODO: Add delete logic here
                var context = new ConsortoUniversity1Entities1();
                var courses = context.COURSES;
                var result = courses.Where(s => s.CoureseId == id).FirstOrDefault();
                courses.Remove(result);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
