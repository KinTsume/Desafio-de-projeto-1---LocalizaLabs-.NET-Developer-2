using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end.Services
{
    public interface IPlanetServices : IDisposable
    {
        List<Planet> GetPlanets();
        Planet GetRandomPlanet();
        void AddPlanet(Planet planet);
        void UpdatePlanet(Guid id, Planet planet);
        void DeletePlanet(Guid id);
    }
}
