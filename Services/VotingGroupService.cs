using DDL.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;


namespace DDL.Services
{
    public class VotingGroupService
    {
        private readonly IMongoCollection<VotingGroup> VotingGroups;

        public VotingGroupService(IDDLDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            VotingGroups = database.GetCollection<VotingGroup>(settings.VotingGroupsCollectionName);
        }

        public List<VotingGroup> Get() =>
            VotingGroups.Find(VotingGroup => true).ToList();

        public VotingGroup Get(string id) =>
            VotingGroups.Find<VotingGroup>(VotingGroup => VotingGroup.Id == id).FirstOrDefault();

        public VotingGroup Create(VotingGroup votingGroup)
        {
            VotingGroups.InsertOne(votingGroup);
            return votingGroup;
        }

        public void Update(string id, VotingGroup votingGroupIn) =>
            VotingGroups.ReplaceOne(VotingGroup => VotingGroup.Id == id, votingGroupIn);

        public void Remove(VotingGroup votingGroupIn) =>
            VotingGroups.DeleteOne(VotingGroup => VotingGroup.Id == votingGroupIn.Id);

        public void Remove(string id) =>
            VotingGroups.DeleteOne(VotingGroup => VotingGroup.Id == id);
    }
}
