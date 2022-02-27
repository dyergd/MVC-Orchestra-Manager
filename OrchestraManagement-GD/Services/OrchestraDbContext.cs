using Microsoft.EntityFrameworkCore;
using OrchestraManagement_GD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Services
{
    public class OrchestraDbContext : DbContext
    {
        // this class interacts directly with the database
        public OrchestraDbContext(DbContextOptions options) : base(options)
        {

        }

        //Each dbset is essentally a table in the database

        public DbSet<Orchestra> Orchestras { get; set; } 
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Conductor> Conductors { get; set; }


    }
}
