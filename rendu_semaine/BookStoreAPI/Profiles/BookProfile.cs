using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;

namespace BookStoreAPI.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, BookDto>();
        //CreateMap<Genre, GenreDto>();
        CreateMap<Author, AuthorDto>();
        CreateMap<BookCreateRequestDto, Book>();
    }
}
