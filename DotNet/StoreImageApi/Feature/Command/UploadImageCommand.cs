using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreImageApi.Models;
using StoreImageApi.Models.RequestModel; // This should point to the correct namespace where ImageUploadModel is defined
using StoreImageApi.Models.ResponseModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace StoreImageApi.Feature.Command
{
    public class UploadImageCommand : IRequest<Response>
    {
        public IFormFile ImageFile { get; set; }
    }

    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Response>
    {
        private readonly sdirectdbContext _Context;
        private readonly IWebHostEnvironment _WebHostEnvironment;
        public UploadImageCommandHandler(sdirectdbContext Context, IWebHostEnvironment webHostEnvironment)
        {
            _Context = Context;
            _WebHostEnvironment = webHostEnvironment;
        }

        public async Task<Response> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            Response res = new Response();
            if (request.ImageFile == null)
            {
                throw new ArgumentNullException(nameof(request.ImageFile), "Image file is required");
            }

            string value = DateTime.Now.ToString();
            value = value.Replace("-", string.Empty);
            value = value.Replace(":", string.Empty);
            value = value.Replace(" ", string.Empty);

            string wwwrootPath = _WebHostEnvironment.WebRootPath;
            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + request.ImageFile.FileName;
            string uniqueFileName = value + "_" + request.ImageFile.FileName;
            string imagePath = Path.Combine(wwwrootPath, "Images", uniqueFileName);

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            var imageEntity = new StoreImages3008
            {
                ImageData = File.ReadAllBytes(imagePath),
                ImageLocation = imagePath // Save the image location
            };
            _Context.StoreImages3008s.Add(imageEntity);
            await _Context.SaveChangesAsync(cancellationToken);

            res.StatusCode = 200;
            res.Message = "Image Upload Successfully....";

            return res;
        }
    }
}
