using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day09.Models;
using MVC_Day09.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Controllers
{
    public class CourseController : Controller
    {
        
        private readonly ICourseRepositry crsRepository;
        private readonly ITrackRepository trackRepository;

        public CourseController(ICourseRepositry _crsRepository, ITrackRepository trackRepository)
        {
            crsRepository = _crsRepository;
            this.trackRepository = trackRepository;
        }
     
        // GET: CourseController
        public ActionResult Index()
        {
            return View(crsRepository.GetCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            return View(crsRepository.GetCourse(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewData["TrackID"] = new SelectList(trackRepository.GetTracks(), "ID", "Name");

            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid) {

                    Course crs = new Course();
                    crs.Grade = int.Parse(collection["Grade"]);
                    crs.Topic = collection["Topic"];
                    crs.TrackID = int.Parse(collection["TrackID"]);

                    crsRepository.Insert(crs);

                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["TrackID"] = new SelectList(trackRepository.GetTracks(), "ID", "Name");

            return View(crsRepository.GetCourse(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Course crs = new Course();
                    crs.Grade = int.Parse(collection["Grade"]);
                    crs.Topic = collection["Topic"];
                    crs.TrackID = int.Parse(collection["TrackID"]);
                    crsRepository.Update(id,crs);

                    return RedirectToAction(nameof(Index));
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crsRepository.GetCourse(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                crsRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
