using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Arengo6_MVC.Models;

namespace Arengo6_MVC.Controllers
{
    public class AdminController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ArengoSixEntities db = new ArengoSixEntities();
        
        /*
                Index pages for all            
        */

        // GET: Admin
        //[Authorize]
        public ActionResult Index()
        {
            return View();//View(db.Services.ToList());
        }

        public ActionResult ServiceIndex()
        {
            return View(db.Services.ToList());
        }

        public ActionResult CareerIndex()
        {
            return View(db.Careers.ToList());
        }

        public ActionResult ProjectIndex()
        {
            return View(db.Projects.ToList());
        }

        /*
            Details for all
        */

        // GET: Admin/Details/5
        public ActionResult ServiceDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        public ActionResult CareerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }
            return View(career);
        }

        public ActionResult ProjectDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        /*
            Create Functionality
        */

        // GET: Admin/Create
        public ActionResult ServiceCreate()
        {
            return View();
        }

        public ActionResult CareerCreate()
        {
            return View();
        }

        public ActionResult ProjectCreate()
        {
            return View();
        }    

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ServiceCreate([Bind(Include = "ID,ServiceName,Description,ServiceParent,ServiceOrder")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("ServiceIndex");
            }

            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CareerCreate([Bind(Include = "ID,JobTitle,JobDescription,DateRequired,Tags")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Careers.Add(career);
                db.SaveChanges();
                return RedirectToAction("CareerIndex");
            }

            return View(career);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectCreate([Bind(Include = "ID,ProjectName,ProjectTags")]Project project)
        {
            if(ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("ProjectIndex");
            }
            return View(project);
        }

        // GET: Admin/Edit/5
        public ActionResult ServiceEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }

            return View(service);
        }

        public ActionResult CareerEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if (career == null)
            {
                return HttpNotFound();
            }

            return View(career);
        }

        public ActionResult ProjectEdit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project==null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ServiceEdit([Bind(Include = "ID,ServiceName,Description,ServiceParent,ServiceOrder")] Service service)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ServiceIndex");
            }
            return View(service);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CareerEdit([Bind(Include = "")] Career career)
        {
            if (ModelState.IsValid)
            {
                db.Entry(career).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CareerIndex");
            }
            return View(career);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectEdit([Bind(Include ="ProjectName,ProjectTags")] Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProjectIndex");
            }
            return View(project);
        }

        // GET: Admin/Delete/5
        public ActionResult ServiceDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        public ActionResult CareerDelete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Career career = db.Careers.Find(id);
            if(career==null)
            {
                return HttpNotFound();
            }
            return View(career);
        }    

        public ActionResult ProjectDelete(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project==null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("ServiceDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ServiceDeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("ServiceIndex");
        }

        [HttpPost,ActionName("CareerDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CareerDeleteConfirm(int id)
        {
            Career career = db.Careers.Find(id);
            db.Careers.Remove(career);
            db.SaveChanges();
            return RedirectToAction("CareerIndex");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectDeleteConfirmation(int id)
        {
            Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("ProjectIndex");
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