using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public interface ICourseRepositry
    {
        public List<Course> GetCourses();
        public Course GetCourse(int id);
        public void Insert(Course course);
        public void Update(int id, Course course);
        public void Delete(int id);
    }
}
