using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreImageApi.Models;

namespace StoreImageApi.Feature.Query
{
    public class GetImageQuery : IRequest<string>
    {
        public int Id { get; set; }
    }

    public class GetImageQueryHandler : IRequestHandler<GetImageQuery, string>
    {
        private readonly sdirectdbContext _Context;
        public GetImageQueryHandler(sdirectdbContext Context)
        {
            _Context = Context;
        }

        public async Task<string> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            var imageEntity = await _Context.StoreImages3008s.FirstOrDefaultAsync(image => image.Id == request.Id, cancellationToken);

            if (imageEntity == null)
                return null;

            return Convert.ToBase64String(imageEntity.ImageData);
        }
    }

}
