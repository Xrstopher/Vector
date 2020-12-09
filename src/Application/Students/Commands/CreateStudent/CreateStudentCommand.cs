using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vector.Application.Common.Interfaces;
using Vector.Domain.Entities;
using Vector.Domain.Events;

namespace Vector.Application.Students.Commands.CreateStudent
{
    public class CreateStudentCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Student
            {
                FirstName = request.FirstName,
                MiddleName = request.MiddleName,
                LastName = request.LastName,
                Email = request.Email
            };

            entity.DomainEvents.Add(new StudentCreatedEvent(entity));

            _context.Students.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
