﻿using System.Data.Entity;

namespace TaxiDriver.Context
{
    /// <summary>
    /// Class that repsresents Data Base context for app data
    /// </summary>
    public class DriverContext : DbContext
    {
        // FIELDS
        DbSet<DriverInfo> drivers;
        DbSet<Client> clients;
        DbSet<Street> streets;
        DbSet<Route> routes;
        DbSet<Score> scores;

        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor for context class
        /// </summary>
        public DriverContext()
            : base("TaxiDriverDB")  {  }

        // PROPERTIES
        /// <summary>
        /// Property that enable to interruct with drivers data
        /// </summary>
        /// <returns>Drivers data</returns>
        public DbSet<DriverInfo> Drivers
        {
            get
            {
                return drivers;
            }
            set
            {
                drivers = value;
            }
        }
        /// <summary>
        /// Property that enable to interruct with clients data
        /// </summary>
        /// <returns>Clients data</returns>
        public DbSet<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                clients = value;
            }
        }
        /// <summary>
        /// Property that enable to interruct with streets data
        /// </summary>
        /// <returns>streets data</returns>
        public DbSet<Street> Streets
        {
            get
            {
                return streets;
            }
            set
            {
                streets = value;
            }
        }
        /// <summary>
        /// Property that enable to interruct with routes data
        /// </summary>
        /// <returns>Routes data</returns>
        public DbSet<Route> Routes
        {
            get
            {
                return routes;
            }
            set
            {
                routes = value;
            }
        }
        /// <summary>
        /// Property that enable to interruct with scores data
        /// </summary>
        /// <returns>Scores data</returns>
        public DbSet<Score> Scores
        {
            get
            {
                return scores;
            }
            set
            {
                scores = value;
            }
        }
    }
}
