using MyBooks.Application.DTOs;
using MyBooks.Application.Interfaces;
using MyBooks.Application.Mappings;
using MyBooks.Domain.Interfaces;

namespace MyBooks.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AuthorResponse>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return authors.Select(a => a.ToResponse());
        }

        public async Task<AuthorResponse?> GetByIdAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetByIdAsync(id);
            return author?.ToResponse();
        }

        public async Task<AuthorResponse> CreateAsync(AuthorCreateRequest createRequest)
        {
            var authorEntity = createRequest.ToEntity();
            await _unitOfWork.Authors.AddAsync(authorEntity);
            await _unitOfWork.CompleteAsync();
            return authorEntity.ToResponse();
        }

        public async Task<AuthorResponse?> UpdateAsync(int id, AuthorUpdateRequest updateRequest)
        {
            var existingAuthor = await _unitOfWork.Authors.GetByIdAsync(id);
            if (existingAuthor == null)
            {
                return null;
            }

            updateRequest.MapToEntity(existingAuthor);
            _unitOfWork.Authors.Update(existingAuthor);
            await _unitOfWork.CompleteAsync();

            return existingAuthor.ToResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingAuthor = await _unitOfWork.Authors.GetByIdAsync(id);
            if (existingAuthor == null)
            {
                return false;
            }

            _unitOfWork.Authors.Remove(existingAuthor);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}