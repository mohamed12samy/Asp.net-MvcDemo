using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Day09.Models;
using MVC_Day09.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Controllers
{
    public class TrackController : Controller
    {
        private readonly ITrackRepository trackRepository;

        public TrackController(ITrackRepository _trackRepository)
        {
            trackRepository = _trackRepository;
        }
        // GET: TrackController
        public ActionResult Index()
        {
            return View(trackRepository.GetTracks());
        }

        // GET: TrackController/Details/5
        public ActionResult Details(int id)
        {
            return View(trackRepository.GetTrack(id));
        }

        // GET: TrackController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Track t = new Track();

                    t.Description = collection["Description"];
                    t.Name = collection["Name"];
                    trackRepository.Insert(t);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(trackRepository.GetTrack(id));
        }

        // POST: TrackController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Track t = new Track();

                    t.Description = collection["Description"];
                    t.Name = collection["Name"];
                    trackRepository.Update(id, t);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: TrackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(trackRepository.GetTrack(id));
        }

        // POST: TrackController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                trackRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
