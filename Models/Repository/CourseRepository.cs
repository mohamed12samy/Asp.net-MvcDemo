using Microsoft.EntityFrameworkCore;
using MVC_Day09.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Models.Repository
{
    public class CourseRepository : ICourseRepositry
    {
        private readonly TraineesDB_Context context;
        public CourseRepository(TraineesDB_Context _context)
        {
            context = _context;
        }
        public void Delete(int id)
        {
            var course = context.Courses.FirstOrDefault(C=>C.ID == id);
            context.Courses.Remove(course);
            context.SaveChangesAsync();
        }

        public Course GetCourse(int id)
        {
            return context.Courses.Include(c => c.Track).FirstOrDefault(C => C.ID == id); 
        }

        public List<Course> GetCourses()
        {
            return context.Courses.Include(c => c.Track ).ToList();
        }

        public void Insert(Course course)
        {
            context.Courses.Add(course);
            context.SaveChangesAsync();
        }

        public void Update(int id, Course course)
        {
            var _course = context.Courses.FirstOrDefault(C => C.ID == id);
            _course.Topic = course.Topic;
            _course.Grade = course.Grade;
            _course.TrackID = course.TrackID;
            context.SaveChangesAsync();
        }
    }
}
