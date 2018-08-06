using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Livraria.API.ViewModel;
using HBSIS.Livraria.Application.Interfaces;
using HBSIS.Livraria.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HBSIS.Livraria.API.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await this.bookService.ListBooksAsync().ConfigureAwait(false);

            books = books.OrderBy(x => x.Name);

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var book = await this.bookService.GetBook(id).ConfigureAwait(false);

            return Ok(book);
        }

       [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var book = await this.bookService.GetBook(id).ConfigureAwait(false);

            await bookService.Delete(book);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                await this.bookService.AddAsync(
                    new Domain.Book
                    {
                        Id = Guid.NewGuid(),
                        Name = bookViewModel.Name,
                        Category = bookViewModel.Category
                    }).ConfigureAwait(false);

                return Ok();
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] BookViewModel bookViewModel, Guid id)
        {
            if (ModelState.IsValid)
            {

                var book = await this.bookService.GetBook(id).ConfigureAwait(false);
                book.Name = bookViewModel.Name;
                book.Category = bookViewModel.Category;
                await this.bookService.SaveChanges().ConfigureAwait(false);

                return Ok();
            }

            return BadRequest();
        }
    }
}