using HBSIS.Livraria.Domain;
using HBSIS.Livraria.Infra.Dal.Context;
using HBSIS.Livraria.Infra.Dal.Interfaces;

namespace HBSIS.Livraria.Infra.Dal.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(BookStoreContext context) : base(context)
        {
        }
    }
}
