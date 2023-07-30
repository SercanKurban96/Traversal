using MediatR;
using Traversal.PresentationLayer.CQRS.Results.GuideResults;

namespace Traversal.PresentationLayer.CQRS.Querries.GuideQuerries
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
