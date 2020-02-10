using DDL.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace DDL.Services
{
    public class GroupService
    {
        private readonly IMongoCollection<Group> _groups;

        public GroupService(IDDLDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _groups = database.GetCollection<Group>(settings.GroupCollectionName);

        }

        public List<Group> Get() =>
            _groups.Find(Group => true).ToList();

        public Group Get(string id) =>
            _groups.Find<Group>(Group => Group.Id == id).FirstOrDefault();

        public Group Create(Group Group)
        {
            _groups.InsertOne(Group);
            return Group;
        }

        public void Update(string id, Group GroupIn) =>
            _groups.ReplaceOne(Group => Group.Id == id, GroupIn);

        public void Remove(Group GroupIn) =>
            _groups.DeleteOne(Group => Group.Id == GroupIn.Id);

        public void Remove(string id) =>
            _groups.DeleteOne(Group => Group.Id == id);
    }
}
