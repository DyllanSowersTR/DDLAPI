using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DDL.Models
{
    public class Restaurant
    {
        public string Name { get; set; }
        public Location Location { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
    }
}
