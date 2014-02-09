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
    public class PhotosController : ApiController
    {
        static readonly string ServerUploadFolder = Path.GetTempPath();
        private readonly IGenericRepository<SpaceObject> spaceObjectRepository = new GenericRepository<SpaceObject>(new DataContext());
        private readonly IGenericRepository<Photo> photoRepository = new GenericRepository<Photo>(new DataContext());

        [HttpPost]
        public async Task<IEnumerable<Photo>> UploadPhoto(Int64 spaceObjectId)
        {
            // Verify that this is an HTML Form file upload request
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.UnsupportedMediaType));
            }

            var spaceObject = spaceObjectRepository.GetById(spaceObjectId);
            if (spaceObject != null)
            {
                // Create a stream provider for setting up output streams
                var streamProvider = new MultipartFormDataStreamProvider(ServerUploadFolder);

                // Read the MIME multipart asynchronously content using the stream provider we just created.
                await Request.Content.ReadAsMultipartAsync(streamProvider);

                var result = streamProvider.FileData.Select(entry => entry.LocalFileName).Select(fileName => new Photo()
                {
                    Carma = new Carma()
                    {
                        Amount = 0, Rate = CarmaRates.Photo
                    },
                    Target = spaceObject, Url = fileName
                }).ToList();

                //ToDO
                //photoRepository.AddRange(result);

                return result;
            }
            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }
    }
}
