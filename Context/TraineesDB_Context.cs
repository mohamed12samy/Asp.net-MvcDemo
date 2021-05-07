using Microsoft.EntityFrameworkCore;
using MVC_Day09.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Day09.Context
{
    public class TraineesDB_Context:DbContext
    {

        public TraineesDB_Context(DbContextOptions options):base(options) { }

        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
