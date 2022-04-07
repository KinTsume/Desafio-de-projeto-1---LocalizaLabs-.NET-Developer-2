using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end
{
    public interface IPlanetRepository : IDisposable
    {
        //Using CRUD operations (Create, Read, Update, Delete)
        Planet ReadPlanet(Guid Id);
        Planet ReadRandomPlanet();
        void CreatePlanet(Planet planet);

        //First argument is the id of the planet to update
        void UpdatePlanet(Guid id, Planet planet);
        void DeletePlanet(Guid id);
    }
}
