using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vector.Application.Common.Models;
using Vector.Domain.Events;

namespace Vector.Application.Students.EventHandlers
{
    public class StudentCreatedEventHandler : INotificationHandler<DomainEventNotification<StudentCreatedEvent>>
    {
        private readonly ILogger<StudentCreatedEventHandler> _logger;

        public StudentCreatedEventHandler(ILogger<StudentCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<StudentCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("Vector Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
