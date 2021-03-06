﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD_CFA.Models;

namespace CRUD_CFA.Controllers
{
    public class ClassesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Classes
        public ActionResult Index()
        {
            return View(db.Class.ToList());
        }

        // GET: Classes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesModel classesModel = db.Class.Find(id);
            if (classesModel == null)
            {
                return HttpNotFound();
            }
            return View(classesModel);
        }

        // GET: Classes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassId,ClassName")] ClassesModel classesModel)
        {
            if (ModelState.IsValid)
            {
                db.Class.Add(classesModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classesModel);
        }

        // GET: Classes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesModel classesModel = db.Class.Find(id);
            if (classesModel == null)
            {
                return HttpNotFound();
            }
            return View(classesModel);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassId,ClassName")] ClassesModel classesModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classesModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classesModel);
        }

        // GET: Classes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassesModel classesModel = db.Class.Find(id);
            if (classesModel == null)
            {
                return HttpNotFound();
            }
            return View(classesModel);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassesModel classesModel = db.Class.Find(id);
            db.Class.Remove(classesModel);
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
