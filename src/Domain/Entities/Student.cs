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
    public class Student : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Book> Books { get; set; }


        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
