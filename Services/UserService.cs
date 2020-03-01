using DDL.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DDL.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> Users;

        public UserService(IDDLDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Users = database.GetCollection<User>(settings.UsersCollectionName);
        }

        public List<User> Get() =>
            Users.Find(User => true).ToList();

        public User Get(string id) =>
            Users.Find<User>(User => User.Id == id).FirstOrDefault();

        public User Create(User user)
        {
            Users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn) =>
            Users.ReplaceOne(User => User.Id == id, userIn);

        public void Remove(User userIn) =>
            Users.DeleteOne(User => User.Id == userIn.Id);

        public void Remove(string id) =>
            Users.DeleteOne(User => User.Id == id);
    }
}
