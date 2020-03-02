using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDL.Models
{
    public class RestaurantWithVoters : Restaurant
    {
        public List<User> Voters { get; set; } = new List<User>();
    }
}
