using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HBSIS.Livraria.Application.Interfaces;
using HBSIS.Livraria.Domain;
using HBSIS.Livraria.Infra.Dal.Interfaces;

namespace HBSIS.Livraria.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task AddAsync(Book book)
        {
            _bookRepository.AddAsync(book);
            return _bookRepository.SaveChangesAsync();
        }


        public Task<Book> GetBook(Guid id)
        {
            return _bookRepository.GetSingleAsync(book => book.Id == id);
        }

        public Task<IEnumerable<Book>> ListBooksAsync()
        {
            return _bookRepository.GetAllAsync();
        }

        public Task Delete(Book book)
        {
            _bookRepository.Delete(book);
            return _bookRepository.SaveChangesAsync();
        }

        public Task SaveChanges()
        {
            return _bookRepository.SaveChangesAsync();
        }
    }
}
