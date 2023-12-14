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
public class AuthorController : ControllerBase
{

    private readonly ApplicationDbContext _dbContext;
        private readonly IMapper? _mapper;
 
        public AuthorController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

    // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
    // ActionResult designe le type de retour de la méthode de controller d'api
    //[Authorize]

    [HttpGet]
    public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
    {
        var authors = await _dbContext.Authors.ToListAsync();

        var authorsDto = new List<AuthorDto>();

        foreach (var author in authors)
        {
            authorsDto.Add(_mapper.Map<AuthorDto>(author));
        }


        return Ok(authorsDto);

    }
    // [HttpGet]
    // public async Task<ActionResult<List<AuthorDto>>> GetAuthors()
    // {
    //     var authors = await _dbContext.Authors.ToListAsync();

    //     var AuthorsDto = new List<AuthorDto>();

    //     foreach (var author in authors)
    //     {
    //         authorsDto.Add(_mapper.Map<AuthorDto>(author));
    //     }


    //     return Ok(authorsDto);

    // }
    
    //[HttpGet]
    //public async Task<ActionResult<List<BookDto>>> GetBooks()
    //{
    //    var books = await _dbContext.Books.ToListAsync();
    //
    //    var booksDto = new List<BookDto>();
    //
    //    foreach (var book in books)
    //    {
    //        booksDto.Add(_mapper.Map<BookDto>(book));
    //    }
    //    return Ok(booksDto);
    //}


    // POST: api/Book
    // BODY: Book (JSON)
    //[Authorize]
    [HttpPost]
[ProducesResponseType(201, Type = typeof(Author))]
[ProducesResponseType(400)]
public async Task<ActionResult<Author>> PostAuthor([FromBody] Author author)
{
    if (author == null)
    {
        return BadRequest();
    }

    // Vérifie si l'auteur existe déjà dans la base de données
    bool authorExists = await _dbContext.Authors.AnyAsync(a => a.Name == author.Name);
    if (authorExists)
    {
        return BadRequest("Author already exists");
    }
    else
    {
        // Ajoute le nouvel auteur à la base de données
        await _dbContext.Authors.AddAsync(author);
        await _dbContext.SaveChangesAsync();

        // Retourne une réponse indiquant la création réussie de l'auteur
        return Created("api/author", author);
    }
}

[HttpPut("{id}")]
[ProducesResponseType(204)]
[ProducesResponseType(400)]
[ProducesResponseType(404)]
public async Task<IActionResult> PutAuthor(int id, [FromBody] Author author)
{
    if (id != author.Id)
    {
        return BadRequest();
    }

    var authorToUpdate = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);

    if (authorToUpdate == null)
    {
        return NotFound();
    }

    authorToUpdate.Name = author.Name; // Assurez-vous de mettre à jour les propriétés correctes

    _dbContext.Entry(authorToUpdate).State = EntityState.Modified;
    await _dbContext.SaveChangesAsync();
    return NoContent();
}

    [HttpPost("validationTest")]
    public ActionResult ValidationTest([FromBody] AuthorDto author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Author>> DeleteAuthor(int id)
    {
        var authorToDelete = await _dbContext.Authors.FindAsync(id);
        // var authorToDelete = await _dbContext.Authors.FirstOrDefaultAsync(b => b.Id == id);

        if (authorToDelete == null)
        {
            return NotFound();
        }

        _dbContext.Authors.Remove(authorToDelete);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }

}