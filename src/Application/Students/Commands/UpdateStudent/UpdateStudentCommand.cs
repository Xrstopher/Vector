using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vector.Application.Common.Exceptions;
using Vector.Application.Common.Interfaces;
using Vector.Domain.Entities;

namespace Vector.Application.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStudentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Students.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.MiddleName = request.MiddleName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
