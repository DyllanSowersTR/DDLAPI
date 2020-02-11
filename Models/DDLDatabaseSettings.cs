﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Used to store the appsettings.json file DDLDatabaseSettings property values
namespace DDL.Models
{
    public class DDLDatabaseSettings : IDDLDatabaseSettings
    {
        public string RestaurantCollectionName { get; set; }
        public string UserCollectionName { get; set; }
        public string GroupCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
