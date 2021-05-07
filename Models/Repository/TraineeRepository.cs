using Microsoft.EntityFrameworkCore;
using MVC_Day09.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly TraineesDB_Context context;
        public TraineeRepository(TraineesDB_Context _context) {
            context = _context;
        }
        public void Delete(int id)
        {
            var trainee = context.Trainees.FirstOrDefault(T => T.ID == id);
            context.Trainees.Remove(trainee);
            context.SaveChangesAsync();

        }

        public Trainee GetTrainee(int id)
        {
            return context.Trainees.Include(c => c.Track).FirstOrDefault(T => T.ID == id);
        }

        public List<Trainee> GetTrainees()
        {
            return context.Trainees.Include(c => c.Track).ToList();
        }

        public void Insert(Trainee trainee)
        {
            context.Trainees.Add(trainee);
            context.SaveChangesAsync();
        }

        public void Update(int id, Trainee trainee)
        {
            Trainee trainee1 = context.Trainees.FirstOrDefault(T => T.ID == id);
            trainee1.Name = trainee.Name;
            trainee1.BirthDate = trainee.BirthDate;
            trainee1.Gender = trainee.Gender;
            trainee1.MobileNum = trainee.MobileNum;
            trainee1.TrackID = trainee.TrackID;

            context.SaveChangesAsync();

        }
    }
}
