using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Application.Books.Queries;
using Vector.Application.Common.Mappings;
using Vector.Domain.Entities;

namespace Vector.Application.Students.Queries
{
    public class StudentDto : IMapFrom<Student>
    {
        public StudentDto()
        {
            Books = new List<BookDto>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public IList<BookDto> Books { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDto>();
        }
    }
}
