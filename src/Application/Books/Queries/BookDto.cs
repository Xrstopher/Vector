using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector.Application.Common.Mappings;
using Vector.Domain.Entities;

namespace Vector.Application.Books.Queries
{
    public class BookDto : IMapFrom<Book>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }

        public DateTime PublicationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDto>(MemberList.Destination);
        }
    }
}
