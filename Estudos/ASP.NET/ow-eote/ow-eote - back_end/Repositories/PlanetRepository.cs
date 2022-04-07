using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ow_eote___back_end.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        IMongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database;
        public static List<Planet> PlanetsList = new List<Planet>();



        public Planet ReadPlanet(Guid Id)
        {
            return PlanetsList.Single(planet => planet.id == Id);
        }

        public Planet ReadRandomPlanet()
        {
            Random rnd = new Random();
            Guid rndId = PlanetsList[rnd.Next(PlanetsList.Count - 1)].id; 
            return PlanetsList.Single(planet => planet.id == rndId);
        }

        public void CreatePlanet(Planet planet) 
        {
            database = client.GetDatabase("Planets");
        }

        public void UpdatePlanet(Guid id, Planet planet)
        {

        }

        public void DeletePlanet(Guid id)
        {

        }

        public void Dispose()
        {
            //fecha conexão com banco
        }
    }
}
