using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace StudentCrudApp.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            var context = new ConsortoUniversity1Entities1();
            var students = context.STUDENTS;

            return View(students.ToList<STUDENT>());
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            var context = new ConsortoUniversity1Entities1();
            var students = context.STUDENTS;
            var result = students.Where(s => s.StudentId == id).FirstOrDefault();

            return View(result);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(STUDENT student)
        {
            try
            {
                // TODO: Add insert logic here
                var context = new ConsortoUniversity1Entities1();
                var students = context.STUDENTS;
                students.Add(student);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new ConsortoUniversity1Entities1();
            var students = context.STUDENTS;
            var result = students.Where(s => s.StudentId == id).FirstOrDefault();

            return View(result);
        }

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, STUDENT student)
        {
            try
            {
                // TODO: Add update logic here
                var context = new ConsortoUniversity1Entities1();
                var students = context.STUDENTS;
                context.Entry(student).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new ConsortoUniversity1Entities1();
            var students = context.STUDENTS;
            var result = students.Where(s => s.StudentId == id).FirstOrDefault();

            return View(result);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var context = new ConsortoUniversity1Entities1();
                var students = context.STUDENTS;
                var result = students.Where(s => s.StudentId == id).FirstOrDefault();
                students.Remove(result);
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
