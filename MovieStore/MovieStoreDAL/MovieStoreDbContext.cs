﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieStoreDAL
{
    public class MovieStoreDbContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieStoreDbContext() : base("MovieStoreShop")
        {
            Database.SetInitializer(new MovieStoreDbInitializer());
        }

        public System.Data.Entity.DbSet<MovieStoreDAL.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MovieStoreDAL.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<MovieStoreDAL.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MovieStoreDAL.Address> Addresses { get; set; }

    }
}
