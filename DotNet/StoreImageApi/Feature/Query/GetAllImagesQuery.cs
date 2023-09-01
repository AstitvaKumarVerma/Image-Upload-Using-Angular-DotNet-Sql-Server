using MediatR;
using Microsoft.EntityFrameworkCore;
using StoreImageApi.Models;
using System.Collections.Generic;

namespace StoreImageApi.Feature.Query
{
    public class GetAllImagesQuery : IRequest<List<StoreImages3008>>
    {
    }

    public class GetAllImagesQueryHandler : IRequestHandler<GetAllImagesQuery, List<StoreImages3008>>
    {
        private readonly sdirectdbContext _dbContext;

        public GetAllImagesQueryHandler(sdirectdbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<StoreImages3008>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            var images = await _dbContext.StoreImages3008s.ToListAsync(cancellationToken);
            return images;
        }
    }
}
