using OrchestraManagement_GD.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraManagement_GD.Services
{
    public interface IOrchestraRepository
    {
        //this class creates the method headers for our crud operations

        ICollection<Orchestra> ReadAll();

        Orchestra Create(Orchestra orchestra);

        Orchestra Details(int id);

        void Edit(int oldId, Orchestra orchestra);

        void Delete(int id);

        Musician AddMusician(int orchestraId, Musician musician);

        void EditMusician(int oldId, Musician musician);

        Musician MusicianDetails(int id);

        void DeleteMusician(int id);

        Conductor AddConductor(int orchestraId, Conductor conductor);

        void EditConductor(int oldId, Conductor conductor);

        Conductor ConductorDetails(int id);

        void DeleteConductor(int id);



    }
}
