using MediatR;
using Microsoft.EntityFrameworkCore;
using Traversal.DataAccessLayer.Concrete;
using Traversal.PresentationLayer.CQRS.Querries.GuideQuerries;
using Traversal.PresentationLayer.CQRS.Results.GuideResults;

namespace Traversal.PresentationLayer.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler : IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                Description = x.Description,
                GuideImage = x.GuideImage,
                Name = x.Name
            }).AsNoTracking().ToListAsync();
            // buradaki kod kısmı tamamlandıktan sonra Program.cs kısmına geliyoruz.
        }
    }
}
