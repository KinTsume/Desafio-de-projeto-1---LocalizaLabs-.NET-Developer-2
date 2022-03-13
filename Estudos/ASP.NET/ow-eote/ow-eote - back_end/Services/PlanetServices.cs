using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ow_eote___back_end.Repositories;

namespace ow_eote___back_end.Services
{
    public class PlanetServices : IPlanetServices
    {
        IPlanetRepository _planetRepository;

        public PlanetServices (IPlanetRepository planetRepository)
        {
            _planetRepository = planetRepository;
        }

        public Planet GetPlanet(Guid Id)
        {
            return _planetRepository.GetPlanet(Id);
        }

        public void AddPlanet(Planet planet)
        {
            PlanetRepository.PlanetsList.Add(planet);
        }

        public void UpdatePlanet(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _planetRepository?.Dispose();
        }        
    }
}
