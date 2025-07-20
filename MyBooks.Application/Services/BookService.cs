using MyBooks.Application.DTOs;
using MyBooks.Application.Interfaces;
using MyBooks.Application.Mappings;
using MyBooks.Domain.Interfaces;

namespace MyBooks.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookResponse>> GetAllAsync()
        {
            var books = await _unitOfWork.Books.GetAllWithDetailsAsync();
            return books.Select(b => b.ToResponse());
        }

        public async Task<BookResponse?> GetByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.GetByIdWithDetailsAsync(id);
            return book?.ToResponse();
        }

        public async Task<BookResponse> CreateAsync(BookCreateRequest createRequest)
        {
            var bookEntity = createRequest.ToEntity();
            await _unitOfWork.Books.AddAsync(bookEntity);
            await _unitOfWork.CompleteAsync();

            var newBook = await _unitOfWork.Books.GetByIdWithDetailsAsync(bookEntity.Id);
            return newBook.ToResponse();
        }

        public async Task<BookResponse?> UpdateAsync(int id, BookUpdateRequest updateRequest)
        {
            var existingBook = await _unitOfWork.Books.GetByIdAsync(id);
            if (existingBook == null)
            {
                return null;
            }

            updateRequest.MapToEntity(existingBook);
            _unitOfWork.Books.Update(existingBook);
            await _unitOfWork.CompleteAsync();

            var updatedBook = await _unitOfWork.Books.GetByIdWithDetailsAsync(id);
            return updatedBook.ToResponse();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingBook = await _unitOfWork.Books.GetByIdAsync(id);
            if (existingBook == null)
            {
                return false;
            }

            _unitOfWork.Books.Remove(existingBook);
            await _unitOfWork.CompleteAsync();
            return true;
        }
    }
}