using Vector.Domain.Common;
using System.Threading.Tasks;

namespace Vector.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
