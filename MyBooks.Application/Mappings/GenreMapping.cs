using MyBooks.Api.DTOs;
using MyBooks.Domain.Entities;

namespace MyBooks.Application.Mappings
{
    public static class GenreMapping
    {
        public static Genre ToEntity(this GenreCreateRequest dto)
        {
            return new Genre { Name = dto.Name };
        }

        public static void MapToEntity(this GenreUpdateRequest dto, Genre entity)
        {
            entity.Name = dto.Name;
        }

        public static GenreResponse ToResponse(this Genre entity)
        {
            return new GenreResponse
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}