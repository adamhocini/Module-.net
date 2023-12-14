using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStoreAPI.Entities;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 


// this designe la classe dans laquelle on se trouve


// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur
[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public BookController(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
    // ActionResult designe le type de retour de la méthode de controller d'api
    //[Authorize]
    [HttpGet]
    public async Task<ActionResult<List<BookDto>>> GetGenre()
    {
        var genres = await _dbContext.Genres.ToListAsync();

        var booksDto = new List<BookDto>();

        foreach (var genre in genres)
        {
            booksDto.Add(_mapper.Map<BookDto>(genre));
        }


        return Ok(booksDto);

    }
    

    // POST: api/Book
    // BODY: Book (JSON)
    //[Authorize]
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Genre))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Genre genre)
    {
        // we check if the parameter is null
        if (genre == null)
        {
            return BadRequest();
        }
        // we check if the book already exists
        Genre? addedBook = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Name == genre.Name);
        if (addedGenre != null)
        {
            return BadRequest("Genre already exists");
        }
        else
        {
            // we add the book to the database
            await _dbContext.Books.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            // we return the book
            return Created("api/book", genre);

        }
    }

    // TODO: Add PUT and DELETE methods
    // PUT: api/Book/5
    // BODY: Book (JSON)
    [HttpPut("{id}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> PutGenre(int id, [FromBody] Genre genre)
    {
        if (id != genre.Id)
        {
            return BadRequest();
        }
        var genreToUpdate = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

        if (genreToUpdate == null)
        {
            return NotFound();
        }

        _dbContext.Entry(genreToUpdate).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("validationTest")]
    public ActionResult ValidationTest([FromBody] BookDto genre)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Genre>> DeleteGenre(int id)
    {
        var genreToDelete = await _dbContext.Genres.FindAsync(id);
        // var genreToDelete = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

        if (genreToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Genres.Remove(genreToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}