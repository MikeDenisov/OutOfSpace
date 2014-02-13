using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OutOfSpace.Web.Data;
using OutOfSpace.Web.Models;

namespace OutOfSpace.Web.Controllers
{
    [RoutePrefix("api/carma")]
    public class CarmaController : ApiController
    {
        private readonly IGenericRepository<Carma> repository = new GenericRepository<Carma>(new DataContext());

        [HttpPut]
        [Route("{id}/increase")]
        public Carma Increase(Int64 id)
        {
            var carmaObj = repository.GetById(id);
            if (carmaObj != null)
            {
                carmaObj.Increase();
                repository.Update(carmaObj);
                repository.Save();
                return carmaObj;
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        [HttpPut]
        [Route("{id}/decrease")]
        public Carma Decrease(Int64 id)
        {
            var carmaObj = repository.GetById(id);
            if (carmaObj != null)
            {
                try
                {
                    carmaObj.Decrease();
                    repository.Update(carmaObj);
                    repository.Save();
                    return carmaObj;
                }
                catch (Exception e)
                {
                    throw new HttpResponseException(HttpStatusCode.InternalServerError);
                }
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}