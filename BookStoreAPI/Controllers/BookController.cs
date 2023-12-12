using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 



// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur
[ApiController]
public class BookController : ControllerBase
{
    [HttpGet("books")]
    public ActionResult<List<Book>> GetBooks()
    {

        var books = new List<Book>
        {
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }

    [HttpPost("books")]
    public IActionResult CreatBook(Book book)
    {
        Console.WriteLine(book.Title);

        return CreatedAtAction(nameof(GetBooks), new {Id = 2, Title = "Naruto", Author = "Masashi Kishimoto"});
        
    }

    [HttpPut("books")]
    public IActionResult CreatBook(Book book)
    {
        Console.WriteLine(book.Title);

        return CreatedAtAction(nameof(GetBooks), new {Id = 2, Title = "OnePiece", Author = "A"});
        
    }
}