using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDL.Models
{
    public interface IDDLDatabaseSettings
    {
        string RestaurantCollectionName { get; set; }

        string GroupCollectionName { get; set; }

        string UserCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
