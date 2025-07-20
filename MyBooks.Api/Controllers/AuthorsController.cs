using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.DTOs;
using MyBooks.Application.Interfaces;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorResponse>>> GetAuthors()
    {
        var authors = await _authorService.GetAllAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponse>> GetAuthor(int id)
    {
        var author = await _authorService.GetByIdAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorResponse>> PostAuthor(AuthorCreateRequest createRequest)
    {
        var createdAuthor = await _authorService.CreateAsync(createRequest);
        return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AuthorResponse>> PutAuthor(int id, AuthorUpdateRequest updateRequest)
    {
        if (id != updateRequest.Id)
        {
            return BadRequest();
        }

        var updatedAuthor = await _authorService.UpdateAsync(id, updateRequest);
        if (updatedAuthor == null)
        {
            return NotFound();
        }
        return Ok(updatedAuthor);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var success = await _authorService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}