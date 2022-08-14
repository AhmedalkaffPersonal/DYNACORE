using Application.Interfaces;
using Domain.Models.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactPersonFeatures.Commands
{
    public class CreateContactPersonCommand : IRequest<Guid>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateContactPersonCommand, Guid>
        {
            private readonly IApplicationDbContext _context;
            public CreateProductCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateContactPersonCommand command, CancellationToken cancellationToken)
            {
                var contactPerson = new ContactPerson();
                contactPerson.FirstName = command.FirstName;
                contactPerson.LastName = command.LastName;
                contactPerson.PhoneNumber = command.PhoneNumber;
                contactPerson.Email = command.Email;
                _context.ContactPersons.Add(contactPerson);
                await _context.SaveChangesAsync();
                return contactPerson.Id;
            }


        }
    }
}
