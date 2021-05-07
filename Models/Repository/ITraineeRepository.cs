using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public interface ITraineeRepository
    {
        public List<Trainee> GetTrainees();
        public Trainee GetTrainee(int id);
        public void Insert(Trainee trainee);
        public void Update(int id, Trainee trainee);
        public void Delete(int id);
    }
}
