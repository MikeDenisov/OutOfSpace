using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;
using OutOfSpace.Web.Enums;
using OutOfSpace.Web.Models;

namespace OutOfSpace.Web.Data
{
    public class DataContext : DbContext, IDbContext
    {
        public DbSet<SpaceObject> Stars { get; set; }
        public DbSet<Carma> Carma { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }

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
                    Alt_enum = 1,
                    Description = "The star of death",
                    Heading = 0,
                    Lat = 10.4748333333333,
                    Lng =  9.96954166666666,
                    Name = "DEATH STAR",
                    Range = 7337,
                    Tilt = 0,
                    Carma = new Carma()
                    {
                        Amount = 0,
                        Rate = CarmaRates.SpaceObject
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Carma = new Carma()
                            {
                                Amount = 0,
                                Rate = CarmaRates.Photo
                            },
                            Url = "http://static2.wikia.nocookie.net/__cb20090309234128/starwars/images/e/ee/DeathStar2.jpg"
                        },
                        new Photo()
                        {
                            Carma = new Carma()
                            {
                                Amount = 0,
                                Rate = CarmaRates.Photo
                            },
                            Url = "http://dontmesswithtaxes.typepad.com/.a/6a00d8345157c669e2017d3fdabf1c970c-pi"
                        }
                    }
                },
                new SpaceObject()
                {
                    Alt = 0,
                    Alt_enum = 1,
                    Description = "The star of life",
                    Heading = 0,
                    Lat = 2.4748333333333,
                    Lng =  5.96954166666666,
                    Name = "Life Star",
                    Range = 7337,
                    Tilt = 0,
                    Carma = new Carma()
                    {
                        Amount = 0,
                        Rate = CarmaRates.SpaceObject
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Carma = new Carma()
                            {
                                Amount = 0,
                                Rate = CarmaRates.Photo
                            },
                            Url = "http://jwst.nasa.gov/ImagesContent/heic0706a.jpg"
                        }
                    }
                },
                new SpaceObject()
                {
                    Alt = 0,
                    Alt_enum = 1,
                    Description = "The star of happieness",
                    Heading = 0,
                    Lat = 6.4748333333333,
                    Lng =  1.96954166666666,
                    Name = "Happieness Star",
                    Range = 7337,
                    Tilt = 0,
                    Carma = new Carma()
                    {
                        Amount = 0,
                        Rate = CarmaRates.SpaceObject
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Carma = new Carma()
                            {
                                Amount = 0,
                                Rate = CarmaRates.Photo
                            },
                            Url = "http://upload.wikimedia.org/wikipedia/commons/8/80/NGC_2818_by_the_Hubble_Space_Telescope.jpg"
                        }
                    }
                },
                new SpaceObject()
                {
                    Alt = 0,
                    Alt_enum = 1,
                    Description = "The star of health",
                    Heading = 0,
                    Lat = 10.4748333333333,
                    Lng =  9.96954166666666,
                    Name = "Health Star",
                    Range = 7337,
                    Tilt = 0,
                    Carma = new Carma()
                    {
                        Amount = 0,
                        Rate = CarmaRates.SpaceObject
                    },
                    Photos = new List<Photo>()
                    {
                        new Photo()
                        {
                            Carma = new Carma()
                            {
                                Amount = 0,
                                Rate = CarmaRates.Photo
                            },
                            Url = "http://www.stepbystep.com/wp-content/uploads/2013/04/Difference-between-Atmosphere-and-Space1.jpg"
                        }
                    }
                }
            };

            context.Stars.AddRange(stars);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}