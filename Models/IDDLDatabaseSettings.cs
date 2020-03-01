using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Interface used by Database Settings objects
namespace DDL.Models
{
    public interface IDDLDatabaseSettings
    {
        string VotingGroupsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
