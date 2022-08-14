using Application.Interfaces;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactPersonFeatures.Commands
{
    public class DeleteContactPersonByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteContactPersonByIdCommandHandler : IRequestHandler<DeleteContactPersonByIdCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteContactPersonByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(DeleteContactPersonByIdCommand command, CancellationToken cancellationToken)
            {
                var contactPerson = await _context.ContactPersons.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (contactPerson == null)
                {
                    throw new ContactPersonNotFoundException(command.Id);
                }

                _context.ContactPersons.Remove(contactPerson);
                await _context.SaveChangesAsync();
                return contactPerson.Id;
            }


        }
    }
}
