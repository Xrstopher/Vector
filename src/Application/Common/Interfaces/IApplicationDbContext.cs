using Vector.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Vector.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Student> Students { get; set; }

        DbSet<Book> Books { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
