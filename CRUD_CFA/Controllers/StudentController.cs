using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_CFA.Models;

namespace CRUD_CFA.Controllers
{
    public class StudentController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Student.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.Student.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            ViewBag.classes = db.Class.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                //call stored procedure
                //var parameter1 = new SqlParameter("@parameter1",para1);
                //var parameter2 = new SqlParameter("@parameter1", para2);
                //db.Database.SqlQuery<StudentModel>(@"EXEC stored_procedure_name(@parameter1,@parameter2)",parameter1,parameter2).FirstOrDefault();
                db.Student.Add(studentModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentModel);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.Student.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,Name,Address,Mobile")] StudentModel studentModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentModel);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentModel studentModel = db.Student.Find(id);
            if (studentModel == null)
            {
                return HttpNotFound();
            }
            return View(studentModel);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentModel studentModel = db.Student.Find(id);
            db.Student.Remove(studentModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
