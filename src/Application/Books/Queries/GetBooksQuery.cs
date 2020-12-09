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

namespace Vector.Application.Books.Queries
{
    public class GetBooksQuery : IRequest<IEnumerable<BookDto>>
    {
    }

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _context.Books
                   .AsNoTracking()
                   .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                   .OrderBy(t => t.Title)
                   .ToListAsync(cancellationToken);
        }
    }
}
