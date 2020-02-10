using DDL.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DDL.Services
{
    public class RestaurantService
    {

        private readonly IMongoCollection<Restaurant> _restaurants;

        public RestaurantService(IDDLDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _restaurants = database.GetCollection<Restaurant>(settings.RestaurantCollectionName);
        }

        public List<Restaurant> Get() =>
            _restaurants.Find(Restaurant => true).ToList();

        public Restaurant Get(string id) =>
            _restaurants.Find<Restaurant>(Restaurant => Restaurant.Id == id).FirstOrDefault();

        public Restaurant Create(Restaurant Restaurant)
        {
            _restaurants.InsertOne(Restaurant);
            return Restaurant;
        }

        public void Update(string id, Restaurant RestaurantIn) =>
            _restaurants.ReplaceOne(Restaurant => Restaurant.Id == id, RestaurantIn);

        public void Remove(Restaurant RestaurantIn) =>
            _restaurants.DeleteOne(Restaurant => Restaurant.Id == RestaurantIn.Id);

        public void Remove(string id) =>
            _restaurants.DeleteOne(Restaurant => Restaurant.Id == id);
    }
}
