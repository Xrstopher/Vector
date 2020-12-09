using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Domain.Common;

namespace Vector.Domain.Entities
{
    public class Book : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }

        public DateTime PublicationDate { get; set; }
        public virtual ICollection<Student> Students { get; set; }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
