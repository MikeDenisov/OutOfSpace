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
    /// <summary>
    /// Api for changing carma
    /// </summary>
    [RoutePrefix("api/carma")]
    public class CarmaController : ApiController
    {
        private readonly IGenericRepository<Carma> repository = new GenericRepository<Carma>(new DataContext());
        /// <summary>
        /// Increase carma of particaluar entity and its parent carma
        /// </summary>
        /// <param name="id">Carma item id</param>
        /// <returns>Updated carma item</returns>
        [HttpPut]
        [Route("{id}/increase")]
        public Carma Increase(Int64 id)
        {
            var carmaObj = repository.GetById(id);
            if (carmaObj == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            carmaObj.Increase();
            repository.Update(carmaObj);
            repository.Save();
            return carmaObj;
        }

        /// <summary>
        /// Decrease carma of particaluar entity and its parent carma
        /// </summary>
        /// <param name="id">Carma item id</param>
        /// <returns>Updated carma item</returns>
        [HttpPut]
        [Route("{id}/decrease")]
        public Carma Decrease(Int64 id)
        {
            var carmaObj = repository.GetById(id);
            if (carmaObj == null) throw new HttpResponseException(HttpStatusCode.NotFound);

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
    }
}