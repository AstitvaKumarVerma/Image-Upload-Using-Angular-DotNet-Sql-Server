using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreImageApi.Feature.Command;
using StoreImageApi.Feature.Query;
using StoreImageApi.Models.RequestModel;
using StoreImageApi.Models;
using System.Threading.Tasks;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace StoreImageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MainController(IMediator mediator, IWebHostEnvironment environment)
        {
            _mediator = mediator;
            _webHostEnvironment = environment;
        }

        [HttpGet]
        [Route("GetAllImages")]
        public async Task<IActionResult> GetAllImages()
        {
            var query = new GetAllImagesQuery();
            var images = await _mediator.Send(query);

            return Ok(images);
        }


        [HttpGet]
        [Route("GetImageById")]
        public async Task<IActionResult> GetImage(int id)
        {
            var query = new GetImageQuery { Id = id };
            var imageData = await _mediator.Send(query);

            if (imageData == null)
                return NotFound();

            return Ok(new { image = imageData });
        }

        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] ImageUploadModel model)
        {
            var command = new UploadImageCommand
            {
                ImageFile = model.ImageFile
            };
            return Ok(await _mediator.Send(command));

            //return Ok(new { message = "Image uploaded successfully" });
        }

        //[HttpPost]
        //[Route("UploadImage")]
        //public async Task<IActionResult> UploadImage([FromForm] UploadImageCommand model)
        //{
        //    return Ok(await _mediator.Send(model));
        //}
    }

}
