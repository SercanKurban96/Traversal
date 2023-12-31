﻿using Traversal.DataAccessLayer.Concrete;
using Traversal.PresentationLayer.CQRS.Commands.DestinationCommands;

namespace Traversal.PresentationLayer.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var values = _context.Destinations.Find(command.DestinationID);
            values.City = command.City;
            values.DayNight = command.Daynight;
            values.Price = command.Price;
            _context.SaveChanges();
        }
    }
}
