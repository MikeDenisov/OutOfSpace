using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OutOfSpace.API.Models;

namespace OutOfSpace.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<SpaceObject> Stars { get; set; }

        public static string ConnectionStringName
        {get
            {
                if (ConfigurationManager.AppSettings["ConnectionStringName"]
                    != null)
                {
                    return ConfigurationManager.
                        AppSettings["ConnectionStringName"];
                }

                return "DefaultConnection";
            }
        }

        static DataContext()
        {
            Database.SetInitializer(new OutOfSpaceDatabaseInitializer());
        }

        public DataContext()
            : base(ConnectionStringName)
        {
        }
    }

    public class OutOfSpaceDatabaseInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var stars = new List<SpaceObject>()
            {
                new SpaceObject()
                {
                    Alt = 0,
                    Description = "The star of death",
                    Heading = 0,
                    Lat = 10.4748333333333,
                    Lng =  9.96954166666666,
                    Name = "DEATH STAR",
                    Range = 7337,
                    Tilt = 0
                }
            };

            context.Stars.AddRange(stars);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}