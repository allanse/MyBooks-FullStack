using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyBooks.Application.DTOs;
using MyBooks.Application.Interfaces;

[ApiVersion("1.0")]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetBooks()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponse>> GetBook(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookResponse>> PostBook(BookCreateRequest createRequest)
    {
        var createdBook = await _bookService.CreateAsync(createRequest);
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookResponse>> PutBook(int id, BookUpdateRequest updateRequest)
    {
        if (id != updateRequest.Id)
        {
            return BadRequest();
        }

        var updatedBook = await _bookService.UpdateAsync(id, updateRequest);
        if (updatedBook == null)
        {
            return NotFound();
        }
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var success = await _bookService.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}