using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using OutOfSpace.Web.Data;
using OutOfSpace.Web.Enums;
using OutOfSpace.Web.Models;

namespace OutOfSpace.Web.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotosController : ApiController
    {
        static readonly string ServerUploadFolder = Path.GetTempPath();
        private readonly IGenericRepository<SpaceObject> spaceObjectRepository = new GenericRepository<SpaceObject>(new DataContext());
        private readonly IGenericRepository<Photo> photoRepository = new GenericRepository<Photo>(new DataContext());

        [HttpPost]
        [Route("")]
        public async Task<IEnumerable<Photo>> UploadPhoto(Int64 spaceObjectId)
        {
            // Verify that this is an HTML Form file upload request
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            var spaceObject = spaceObjectRepository.GetById(spaceObjectId);

            if (spaceObject == null) 
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            // Create a stream provider for setting up output streams
            var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);

            // Read the MIME multipart asynchronously content using the stream provider we just created.
            await Request.Content.ReadAsMultipartAsync(streamProvider);

            var result = new List<Photo>();
            foreach (var fileName in streamProvider.FileData.Select(entry => entry.LocalFileName))
            {
                var newPhoto = new Photo()
                {
                    Carma = new Carma()
                    {
                        Amount = 0,
                        Rate = CarmaRates.Photo
                    },
                    Target = spaceObject,
                    Url = fileName
                };
                photoRepository.Add(newPhoto);
                result.Add(newPhoto);
            }

            photoRepository.Save();

            return result;
        }
    }
}
