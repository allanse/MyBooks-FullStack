// MyBooks.Application/Services/GenreService.cs
using MyBooks.Api.DTOs;
using MyBooks.Application.Interfaces;
using MyBooks.Application.Mappings;
using MyBooks.Domain.Interfaces;

namespace MyBooks.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GenreResponse>> GetAllAsync()
        {
            var genres = await _unitOfWork.Genres.GetAllAsync();
            return genres.Select(g => g.ToResponse());
        }

        public async Task<GenreResponse?> GetByIdAsync(int id)
        {
            var genre = await _unitOfWork.Genres.GetByIdAsync(id);
            return genre?.ToResponse();
        }

        public async Task<GenreResponse> CreateAsync(GenreCreateRequest createRequest)
        {
            var genreEntity = createRequest.ToEntity();
            await _unitOfWork.Genres.AddAsync(genreEntity);
            await _unitOfWork.CompleteAsync();
            return genreEntity.ToResponse();
        }

        public async Task<GenreResponse?> UpdateAsync(int id, GenreUpdateRequest updateRequest)
        {
            var existingGenre = await _unitOfWork.Genres.GetByIdAsync(id);
            if (existingGenre == null)
            {
                return null;
            }

            updateRequest.MapToEntity(existingGenre);
            _unitOfWork.Genres.Update(existingGenre);
            await _unitOfWork.CompleteAsync();

            return existingGenre.ToResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingGenre = await _unitOfWork.Genres.GetByIdAsync(id);
            if (existingGenre == null)
            {
                return false;
            }

            _unitOfWork.Genres.Remove(existingGenre);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}