// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using AutoMapper;
// using BookStoreAPI.Entities;
// using BookStoreAPI.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;


// namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 


// // this designe la classe dans laquelle on se trouve


// // Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// // Dans ce contexte elle permet de définir que la classe GenreController est un contrôleur d'API
// // On parle aussi de decorator / décorateur
// [ApiController]
// [Route("api/[controller]")]
// public class GenreController : ControllerBase
// {

//     private readonly ApplicationDbContext _dbContext;
//     private readonly IMapper _mapper;

//     public GenreController(ApplicationDbContext dbContext, IMapper mapper)
//     {
//         _dbContext = dbContext;
//         _mapper = mapper;
//     }


//     // Ceci est une annotation, elle permet de définir des métadonnées sur une méthode
//     // ActionResult designe le type de retour de la méthode de controller d'api
//     //[Authorize]
//     [HttpGet("{id}")]
//     public async Task<IActionResult> GetGenreById(int id)
//     {
//         // Vérifiez si le genre existe dans la base de données
//         Genre? genre = await _dbContext.Genres.FindAsync(id);
 
//         if (genre == null)
//         {
//             return NotFound();
//         }
 
//         var genreDto = _mapper?.Map<GenreDto>(genre); // Vérifier la nullité de _mapper
//         if (genreDto == null)
//         {
//             return BadRequest();
//         }
 
//         return Ok(genreDto);
//     }
    

//     // POST: api/Genre
//     // BODY: genre (JSON)
//     //[Authorize]
//     [HttpPost]
//     [ProducesResponseType(201, Type = typeof(Genre))]
//     [ProducesResponseType(400)]
//     public async Task<ActionResult<Genre>> PostGenre([FromBody] Genre genre)
//     {
//         // we check if the parameter is null
//         if (genre == null)
//         {
//             return BadRequest();
//         }
//         // we check if the genre already exists
//         Genre? addedGenre = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Name == genre.Name);
//         if (addedGenre != null)
//         {
//             return BadRequest("Genre already exists");
//         }
//         else
//         {
//             // we add the genre to the database
//             await _dbContext.Gneres.AddAsync(genre);
//             await _dbContext.SaveChangesAsync();

//             // we return the genre
//             return Created("api/Genre", genre);

//         }
//     }

//     // TODO: Add PUT and DELETE methods
//     // PUT: api/Genre/5
//     // BODY: Genre (JSON)
//     // [HttpPut("{id}")]
//     // [ProducesResponseType(204)]
//     // [ProducesResponseType(400)]
//     // [ProducesResponseType(404)]
//     // public async Task<IActionResult> PutGenre(int id, [FromBody] Genre genre)
//     // {
//     //     if (id != genre.Id)
//     //     {
//     //         return BadRequest();
//     //     }
//     //     var genreToUpdate = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

//     //     if (genreToUpdate == null)
//     //     {
//     //         return NotFound();
//     //     }
        
        
//     //     genreToUpdate.Genre = genre.Genre;
//     //     // continuez pour les autres propriétés

//     //     _dbContext.Entry(genreToUpdate).State = EntityState.Modified;
//     //     await _dbContext.SaveChangesAsync();
//     //     return NoContent();
//     // }

//     // [HttpPost("validationTest")]
//     // public ActionResult ValidationTest([FromBody] GenreDto genre)
//     // {
//     //     if (!ModelState.IsValid)
//     //     {
//     //         return BadRequest(ModelState);
//     //     }
//     //     return Ok();
//     // }

//     [HttpDelete("{id}")]
//     public async Task<ActionResult<Genre>> DeleteGenre(int id)
//     {
//         var genreToDelete = await _dbContext.Genres.FindAsync(id);
//         // var genreToDelete = await _dbContext.Genres.FirstOrDefaultAsync(b => b.Id == id);

//         if (genreToDelete == null)
//         {
//             return NotFound();
//         }

//         _dbContext.Genres.Remove(genreToDelete);
//         await _dbContext.SaveChangesAsync();
//         return NoContent();
//     }

// }