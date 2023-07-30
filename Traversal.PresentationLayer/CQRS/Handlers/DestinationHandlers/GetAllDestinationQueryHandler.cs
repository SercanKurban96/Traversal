using Microsoft.EntityFrameworkCore;
using Traversal.DataAccessLayer.Concrete;
using Traversal.PresentationLayer.CQRS.Querries.DestinationQuerries;
using Traversal.PresentationLayer.CQRS.Results.DestinationResults;

namespace Traversal.PresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();
            return values;
            // AsNoTracking ----> EntityFramework ile bir select işlemi yaptığınızda, gelen data içeriğini güncelleyip SaveChanges yaparsak değişiklikler veritabanına yansır. Bu işlemi her zaman istemiyor olabilirsiniz. Bu durumda AsNoTracking ifadesi yardımımıza koşuyor. Bu ifade ile yaptığımız entity sorgusu sadece okumalıktır. Üzerinde değişiklik yapıp SaveChanges yaptığımızda veritabanında hiçbir değişiklik olmaz. Bu da bize minimum bellek kullanımı ve optimum performans sağlayacaktır.
        }
    }
}
