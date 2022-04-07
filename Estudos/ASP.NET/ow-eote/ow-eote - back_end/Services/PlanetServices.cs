using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ow_eote___back_end.Repositories;

namespace ow_eote___back_end.Services
{
    public class PlanetServices : IPlanetServices
    {
        IMongoClient client = new MongoClient("mongodb://localhost");
        IMongoDatabase database;
        IMongoCollection<Planet> PlanetsCollection;

        public PlanetServices ()
        {
            database = client.GetDatabase("Planets");
            PlanetsCollection = database.GetCollection<Planet>("Planets");
        }

        public List<Planet> GetPlanets()
        {            
            return PlanetsCollection.Find(item => true).ToList<Planet>();
        }

        public Planet GetRandomPlanet()
        {
            var collection = GetPlanets();

            var rdm = new Random();
            var index = rdm.Next(collection.Count - 1);

            return collection[index];
        }

        public void AddPlanet(Planet planet)
        {
            PlanetsCollection.InsertOne(planet);
        }

        public void UpdatePlanet(Guid id, Planet planet)
        {
            PlanetsCollection.ReplaceOne(item => item.id == id, planet);
        }

        public void DeletePlanet(Guid id)
        {
            PlanetsCollection.DeleteOne(item => item.id == id);
        }

        public void Dispose()
        {
            
        }        
    }
}
