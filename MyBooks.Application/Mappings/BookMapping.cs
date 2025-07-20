using MyBooks.Application.DTOs;
using MyBooks.Domain.Entities;

namespace MyBooks.Application.Mappings
{
    public static class BookMapping
    {
        public static Book ToEntity(this BookCreateRequest dto)
        {
            return new Book
            {
                Title = dto.Title,
                PublicationYear = dto.PublicationYear,
                NumberOfPages = dto.NumberOfPages,
                GenreId = dto.GenreId,
                AuthorId = dto.AuthorId
            };
        }

        public static void MapToEntity(this BookUpdateRequest dto, Book entity)
        {
            entity.Title = dto.Title;
            entity.PublicationYear = dto.PublicationYear;
            entity.NumberOfPages = dto.NumberOfPages;
            entity.GenreId = dto.GenreId;
            entity.AuthorId = dto.AuthorId;
        }

        public static BookResponse ToResponse(this Book entity)
        {
            return new BookResponse
            {
                Id = entity.Id,
                Title = entity.Title,
                PublicationYear = entity.PublicationYear,
                NumberOfPages = entity.NumberOfPages,
                Author = entity.Author?.ToResponse(),
                Genre = entity.Genre?.ToResponse()
            };
        }
    }
}