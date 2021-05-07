using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC_Day09.Models;
using MVC_Day09.Models.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository traineeRepository;
        private readonly ITrackRepository trackRepository;

        public TraineeController(ITraineeRepository _traineeRepository, ITrackRepository trackRepository) {
            traineeRepository = _traineeRepository;
            this.trackRepository = trackRepository;
        }

        // GET: TraineeController
        public ActionResult Index()
        {
            return View(traineeRepository.GetTrainees());
        }

        // GET: TraineeController/Details/5
        public ActionResult Details(int id)
        {
            return View(traineeRepository.GetTrainee(id));
        }

        // GET: TraineeController/Create
        public ActionResult Create()
        {

            ViewData["TrackID"] = new SelectList(trackRepository.GetTracks(), "ID", "Name");
            return View();
        }

        // POST: TraineeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid) {
                    Trainee trainee = new Trainee();
                    trainee.Name = collection["Name"];
                    trainee.BirthDate = DateTime.Parse(collection["BirthDate"]);
                    Gender g;
                    Enum.TryParse(collection["Gender"], out g);
                    trainee.Gender = g;
                    trainee.MobileNum = collection["MobileNum"];
                    trainee.TrackID = int.Parse(collection["TrackID"]);
                    traineeRepository.Insert(trainee);


                    //ViewData["TrackID"] = new SelectList(trackRepository.GetTracks(), "ID", "Name", trainee.TrackID);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewData["TrackID"] = new SelectList(trackRepository.GetTracks(), "ID", "Name");
            return View(traineeRepository.GetTrainee(id));
        }

        // POST: TraineeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Trainee trainee = new Trainee();
                    trainee.Name = collection["Name"];
                    trainee.BirthDate = DateTime.Parse(collection["BirthDate"]);
                    Gender g;
                    Enum.TryParse(collection["Gender"], out g);
                    trainee.Gender = g;
                    trainee.MobileNum = collection["MobileNum"];
                    trainee.TrackID = int.Parse(collection["TrackID"]);
                    traineeRepository.Update(id,trainee);
                    
                    return RedirectToAction(nameof(Index));
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        // GET: TraineeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(traineeRepository.GetTrainee(id));
        }

        // POST: TraineeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                traineeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
