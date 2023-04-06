using Domain;
using MediatR;
using Persistence;

namespace API.Controllers
{
    public class Create
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity);  // We are adding the activity in memory

                await _context.SaveChangesAsync();

                return Unit.Value;  // Means nothing
            }
        }
    }
}
