using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Motionlab.DB
{
    /// <summary>
    /// Db context for entity framework, includes migration if the db has not already been created. 
    /// </summary>
    class InterviewTestContext : DbContext
    {
        public DbSet<InterviewTestDb> InterviewTestDb { get; set; }
        public InterviewTestContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(@"Data Source=sqlite5.db");
        }
    }
}
