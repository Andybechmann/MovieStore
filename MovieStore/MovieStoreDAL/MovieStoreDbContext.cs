﻿using System.Data.Entity;

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
    
        public MovieStoreDbContext() : base("MusicStoreDbContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new MovieStoreDbInitializer());
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Address> Addresses { get; set; }

    }
}
