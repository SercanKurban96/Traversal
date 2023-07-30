namespace Traversal.PresentationLayer.CQRS.Querries.DestinationQuerries
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
