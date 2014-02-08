using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OutOfSpace.Web.Data;
using OutOfSpace.Web.Models;

namespace OutOfSpace.Web.Controllers
{
    [RoutePrefix("api/spaceObjects")]
    public class SpaceObjectsController : ApiController
    {
        private readonly IGenericRepository<SpaceObject> repository = new GenericRepository<SpaceObject>(new DataContext());
        
        [HttpGet]
        [Route("")]
        public IEnumerable<SpaceObject> GetSpaceObjects()
        {
            return ((DbSet<SpaceObject>)repository.All()).Include(p=>p.Carma);
        }

        [HttpGet]
        [Route("{id}")]
        public SpaceObject GetSpaceObject(Int64 id)
        {
            var spaceObj = repository.GetById(id);
            if (spaceObj != null)
            {
                return spaceObj;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostSpaceObject(SpaceObject spaceObject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var createdObject = repository.Add(spaceObject);
                    return Request.CreateResponse(HttpStatusCode.Created, createdObject);                                        
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState.Values.SelectMany(v=>v.Errors).ToString());
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage PutSpaceObject(SpaceObject spaceObject)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(spaceObject);
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                catch (Exception e)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ModelState.Values.SelectMany(v => v.Errors).ToString());
        }

        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteSpaceObject(Int64 id)
        {
            if (id > 0)
            {
                var spaceObject = repository.GetById(id);
                if (spaceObject != null)
                {
                    try
                    {
                        repository.Delete(spaceObject);
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    catch (Exception e)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.Message);
                    }
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
