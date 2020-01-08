using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUD_CFA.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DbContext") { }

        /// <summary>
        /// StudentModel treated as Table Name
        /// </summary>
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<ClassesModel> Class { get; set; }
    }
}