using Application.Interfaces;
using Domain.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactPersonFeatures.Commands
{
    public class UpdateContactPersonCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public class UpdateContactPersonCommandHandler : IRequestHandler<UpdateContactPersonCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public UpdateContactPersonCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(UpdateContactPersonCommand command, CancellationToken cancellationToken)
            {
                var contactPerson = _context.ContactPersons.Where(a => a.Id == command.Id).FirstOrDefault();

                if (contactPerson == null)
                {
                    throw new ContactPersonNotFoundException(command.Id);
                }
                else
                {
                    contactPerson.FirstName = command.FirstName;
                    contactPerson.LastName = command.LastName;
                    contactPerson.PhoneNumber = command.PhoneNumber;
                    contactPerson.Email = command.Email;
                    await _context.SaveChangesAsync();
                    return contactPerson.Id;
                }
            }
        }
    }
}
