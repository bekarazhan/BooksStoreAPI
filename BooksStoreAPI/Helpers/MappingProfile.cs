using AutoMapper;
using BooksStoreAPI.Core.Models.DTOs;
using BooksStoreAPI.Core.Models.Entities;

namespace API.Helpers {
    public class MappingProfile : Profile {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
               .ForMember(dest => dest.PublisherName, opt => opt.MapFrom(src => src.Publisher.Name));
            CreateMap<BookDto, Book>();

            CreateMap<Publisher, PublisherDto>()
                .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            CreateMap<PublisherDto, Publisher>();
        }
    }
}
