using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vector.Application.Common.Interfaces;
using Vector.Domain.Enums;

namespace Vector.Application.Students.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {
    }

    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetStudentsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentDto>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                   .AsNoTracking()
                   .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                   .OrderBy(t => t.LastName)
                   .ToListAsync(cancellationToken);
        }
    }
}
