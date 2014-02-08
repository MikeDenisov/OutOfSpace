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
        [Route("api/spaceObjects")]
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

        [HttpPut]
        [Route("api/spaceObject")]
        public void PutSpaceObject(SpaceObject spaceObject)
        {
            if (ModelState.IsValid)
            {
                var objectToUpdate = context.Stars.First(s => s.Id == spaceObject.Id);
                if (objectToUpdate != null)
                {
                }
            }
        }
    }
}
