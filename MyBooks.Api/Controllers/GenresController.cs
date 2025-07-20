// MyBooks.Api/Controllers/GenresController.cs
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Api.DTOs;
using MyBooks.Application.Interfaces;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class GenresController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenresController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreResponse>>> GetGenres()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreResponse>> GetGenre(int id)
    {
        var genre = await _genreService.GetByIdAsync(id);
        if (genre == null)
        {
            return NotFound();
        }
        return Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult<GenreResponse>> PostGenre(GenreCreateRequest createRequest)
    {
        var createdGenre = await _genreService.CreateAsync(createRequest);
        return CreatedAtAction(nameof(GetGenre), new { id = createdGenre.Id }, createdGenre);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GenreResponse>> PutGenre(int id, GenreUpdateRequest updateRequest)
    {
        if (id != updateRequest.Id)
        {
            return BadRequest();
        }

        var updatedGenre = await _genreService.UpdateAsync(id, updateRequest);
        if (updatedGenre == null)
        {
            return NotFound();
        }
        return Ok(updatedGenre);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGenre(int id)
    {
        var success = await _genreService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}