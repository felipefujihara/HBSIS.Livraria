using System;
using HBSIS.Livraria.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HBSIS.Livraria.Application.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(Book book);
        Task<IEnumerable<Book>> ListBooksAsync();
        Task Delete(Book book);
        Task<Book> GetBook(Guid id);
        Task SaveChanges();
    }
}
