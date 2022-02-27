using Microsoft.EntityFrameworkCore;
using OrchestraManagement_GD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Services
{
    public class DbOrchestraRepository : IOrchestraRepository
    {

                                                            //This class uses the IOrchestraRepository interface to complete the crud methods

        private readonly OrchestraDbContext dbContext;

        public DbOrchestraRepository(OrchestraDbContext db) //injecting the Dbcontext into this class to be able to use the Dbcontext class
        {
            dbContext = db;
        }

        public ICollection<Orchestra> ReadAll()             //reads all data from the orchestra table and returns it
        {
            return dbContext.Orchestras.Include(p => p.Musicians).Include(p => p.Conductors).ToList();
        }

        public Orchestra Create(Orchestra orchestra)        //adds a existing orchestra object to the db
        {
            dbContext.Orchestras.Add(orchestra);
            dbContext.SaveChanges();
            return orchestra;
        }

        public Orchestra Details(int id)                    //reads a single orchestra from the database
        {
            return dbContext.Orchestras.Include(p => p.Conductors).Include(p => p.Musicians).FirstOrDefault(p => p.Id == id);
        }

        public void Edit(int oldId, Orchestra orchestra)    // updates an existing orchestra with any chnages made to it from the view
        {
            Orchestra orchestraToUpdate = Details(oldId);
            orchestraToUpdate.Name = orchestra.Name;
            orchestraToUpdate.AddressLine1 = orchestra.AddressLine1;
            orchestraToUpdate.AddressLine2 = orchestra.AddressLine2;
            orchestraToUpdate.City = orchestra.City;
            orchestraToUpdate.State = orchestra.State;
            orchestraToUpdate.ZipCode = orchestra.ZipCode;
            orchestraToUpdate.WebsiteURL = orchestra.WebsiteURL;
            dbContext.SaveChanges();
        }

        public void Delete(int id)                          //deletes an orchestra object from the database 
        {
            Orchestra orchestraToDelete = Details(id);
            dbContext.Orchestras.Remove(orchestraToDelete);
            dbContext.SaveChanges();         
        }

        public Musician AddMusician(int orchestraId, Musician musician) //adds a existing musician object to the db
        {
            var orchestraDetails = Details(orchestraId);

            if(orchestraDetails != null)                   //checks to see if the requested orchestra exists
            {
                orchestraDetails.Musicians.Add(musician); //if the orchestra exists the musician is added
                dbContext.SaveChanges();
            }
            return musician;
        }

        public Musician MusicianDetails(int id)           //reads a single musician from the database
        {
            return dbContext.Musicians.FirstOrDefault(p => p.Id == id);
        }

        public void EditMusician(int oldId, Musician musician) // updates an existing musician with any changes made to it from the view
        {
            Musician musicianToUpdate = MusicianDetails(oldId);
            musicianToUpdate.Id = musician.Id;
            musicianToUpdate.FirstName = musician.FirstName;
            musicianToUpdate.LastName = musician.LastName;
            musicianToUpdate.SectionName = musician.SectionName;
            musicianToUpdate.IsSectionLeader = musician.IsSectionLeader;
            dbContext.SaveChanges();
        }

        public void DeleteMusician(int id)                    //deletes an musician object from the database 
        {
            Musician musicianToDelete = MusicianDetails(id);
            dbContext.Musicians.Remove(musicianToDelete);
            dbContext.SaveChanges();
        }

        public Conductor AddConductor(int orchestraId, Conductor conductor) //adds a existing conductor object to the db
        {
            var orchestraDetails = Details(orchestraId);

            if (orchestraDetails != null)                    //checks to see if the requested orchestra exists
            {
                orchestraDetails.Conductors.Add(conductor); //if the orchestra exists the conductor is added
                dbContext.SaveChanges();
            }

            return conductor;
        }

        public Conductor ConductorDetails(int id)           //reads a single conductor from the database
        {
            return dbContext.Conductors.FirstOrDefault(p => p.Id == id);
        }

        public void EditConductor(int oldId, Conductor conductor) // updates an existing conductor with any chnages made to it from the view
        {
            Conductor conductorToUpdate = ConductorDetails(oldId);
            conductorToUpdate.Id = conductor.Id;
            conductorToUpdate.FirstName = conductor.FirstName;
            conductorToUpdate.LastName = conductor.LastName;
            dbContext.SaveChanges();
        }

        public void DeleteConductor(int id)                     //deletes an conductor object from the database 
        {
            Conductor conductorToDelete = ConductorDetails(id);
            dbContext.Conductors.Remove(conductorToDelete);
            dbContext.SaveChanges();
        }

    }
}
