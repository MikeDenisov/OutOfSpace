using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Razor.Text;
using System.Web.Routing;
using OutOfSpace.API.Data;
using OutOfSpace.API.Models;
using System.Linq;

namespace OutOfSpace.API.Controllers
{
    public class SpaceObjectsController : ApiController
    {
        private readonly DataContext context = new DataContext();

        [HttpGet]
        [Route("api/spaceObject")]
        public IEnumerable<SpaceObject> GetSpaceObjects()
        {
            //context.Stars.
            return (from star in this.context.Stars
                select star).ToList();

        }

        
        [HttpPost]
        [Route("api/spaceObject")]
        public void PostSpaceObject(SpaceObject spaceObject)
        {
            if (ModelState.IsValid)
            {
                context.Stars.Add(spaceObject);
                context.SaveChanges();
            }
        }
 
    }
}
