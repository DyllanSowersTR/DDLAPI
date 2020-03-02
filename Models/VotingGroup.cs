using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DDL.Models
{
    /**
     * This class represents a voting group (i.e. a lunch group) who are voting on a collection of
     * restaurants (contained within the voting group). A voting group keeps track of the votes per
     * restaurant, and perhaps the voter information. Restaurants in the voting group are populated
     * with data from the restaurant endpoint(s).
     */
    public class VotingGroup
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string GroupName { get; set; }

        public List<RestaurantWithVoters> Restaurants { get; set; } = new List<RestaurantWithVoters>();
    }
}
