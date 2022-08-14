using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactPersonFeatures.Queries
{
    public class GetAllContactPersonsQuery : IRequest<IEnumerable<ContactPerson>>
    {
        public class GetAllContactPersonsQueryHandler : IRequestHandler<GetAllContactPersonsQuery, IEnumerable<ContactPerson>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllContactPersonsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ContactPerson>?> Handle(GetAllContactPersonsQuery query, CancellationToken cancellationToken)
            {
                var contactPersonList = await _context.ContactPersons.ToListAsync();
                if (contactPersonList == null)
                {
                    return null;
                }
                return contactPersonList.AsReadOnly();
            }
        }
    }
}
