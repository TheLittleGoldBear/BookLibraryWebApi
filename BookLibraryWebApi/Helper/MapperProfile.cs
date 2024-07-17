using AutoMapper;
using BookLibraryWebApi.Dto;
using BookLibraryWebApi.Model;

namespace BookLibraryWebApi.Helper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookCreateDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}
