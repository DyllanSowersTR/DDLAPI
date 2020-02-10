using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/* This class should handle the properties of the 'Lunch Group' the user is creating, i.e. the people in the group,
 * the name of the group, the restaurant options to go to, and the max distance from the user to search for restaurants.
 * 
 * GroupName, UserIds, and MaxDistance will be populated from the request to the API by the user interface. 
 * 
 * Restaurant will be populated by this API through a request to Yelp.
 */
namespace DDL.Models
{
    public class Group
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string GroupName { get; set; }
        public User[] UserIds { get; set; } 

        public Restaurant[] Restaurants { get; set; }

        public int MaxDistance { get; set; }

        public int RestaurantType { get; set; }

    }
}
