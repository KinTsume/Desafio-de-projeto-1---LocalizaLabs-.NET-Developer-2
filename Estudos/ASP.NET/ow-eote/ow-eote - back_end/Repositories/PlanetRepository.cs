using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        public static List<Planet> PlanetsList = new List<Planet>();

        public Planet GetPlanet(Guid Id)
        {
            return PlanetsList.Single(planet => planet.id == Id);
        }

        public void Dispose()
        {
            //fecha conexão com banco
        }
    }
}
