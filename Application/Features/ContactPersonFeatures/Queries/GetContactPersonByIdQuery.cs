using Application.Interfaces;
using Domain.Exceptions;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactPersonFeatures.Queries
{
    public class GetContactPersonByIdQuery : IRequest<ContactPerson>
    {
        public Guid Id { get; set; }
        public class GetContactPersonByIdQueryHandler : IRequestHandler<GetContactPersonByIdQuery, ContactPerson>
        {
            private readonly IApplicationDbContext _context;
            public GetContactPersonByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<ContactPerson?> Handle(GetContactPersonByIdQuery query, CancellationToken cancellationToken)
            {
                var contactPerson = _context.ContactPersons.Where(a => a.Id == query.Id).FirstOrDefault();
                if (contactPerson == null)
                {
                    throw new ContactPersonNotFoundException(query.Id);
                }
                return contactPerson;
            }
        }
    }
}
