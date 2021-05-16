using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace ProductStoreEditor.Controllers
{
    public class ImagesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly string _notFoundImageLocation;

        public ImagesController(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _notFoundImageLocation = Path.Combine(environment.WebRootPath, "wwwroot", "Images", "NotFound.png");
        }

        public IActionResult Get(int productId, string fileName)
        {
            string imagesLocation = _configuration.GetValue<string>("ProductPhotosLocation");
            string imagePath = Path.Combine(imagesLocation, productId.ToString(), fileName);

            FileStream image;
            if (System.IO.File.Exists(imagePath))
            {
                image = System.IO.File.OpenRead(imagePath);
            }
            else
            {
                image = System.IO.File.OpenRead(_notFoundImageLocation);

            }

            return File(image, "image/jpeg");
        }
    }
}
