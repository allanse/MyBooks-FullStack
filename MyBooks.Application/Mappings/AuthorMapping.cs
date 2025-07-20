using MyBooks.Application.DTOs;
using MyBooks.Domain.Entities;

namespace MyBooks.Application.Mappings
{
    public static class AuthorMapping
    {
        public static Author ToEntity(this AuthorCreateRequest dto)
        {
            return new Author { Name = dto.Name, Nationality = dto.Nationality };
        }

        public static void MapToEntity(this AuthorUpdateRequest dto, Author entity)
        {
            entity.Name = dto.Name;
            entity.Nationality = dto.Nationality;
        }

        public static AuthorResponse ToResponse(this Author entity)
        {
            return new AuthorResponse
            {
                Id = entity.Id,
                Name = entity.Name,
                Nationality = entity.Nationality
            };
        }
    }
}