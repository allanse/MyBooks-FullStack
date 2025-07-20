// MyBooks.Application.Tests/GenreServiceTests.cs
using Moq;
using MyBooks.Api.DTOs;
using MyBooks.Application.Services;
using MyBooks.Domain.Entities;
using MyBooks.Domain.Interfaces;

namespace MyBooks.Application.Tests
{
    public class GenreServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly GenreService _sut;

        public GenreServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _sut = new GenreService(_mockUnitOfWork.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenGenreExists_ShouldReturnGenreResponse()
        {
            // Arrange
            var genreId = 1;
            var genre = new Genre { Id = genreId, Name = "Ficção Científica" };

            
            var mockGenreRepo = new Mock<IGenericRepository<Genre>>();
            mockGenreRepo.Setup(repo => repo.GetByIdAsync(genreId)).ReturnsAsync(genre);
            _mockUnitOfWork.Setup(uow => uow.Genres).Returns(mockGenreRepo.Object);

            // Act
            var result = await _sut.GetByIdAsync(genreId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<GenreResponse>(result);
            Assert.Equal(genreId, result.Id);
            Assert.Equal("Ficção Científica", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_WhenGenreDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var genreId = 99;

            var mockGenreRepo = new Mock<IGenericRepository<Genre>>();            
            mockGenreRepo.Setup(repo => repo.GetByIdAsync(genreId)).ReturnsAsync((Genre)null);
            _mockUnitOfWork.Setup(uow => uow.Genres).Returns(mockGenreRepo.Object);

            // Act
            var result = await _sut.GetByIdAsync(genreId);

            // Assert
            Assert.Null(result);
        }
    }
}