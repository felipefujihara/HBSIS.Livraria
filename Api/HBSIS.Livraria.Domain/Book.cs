using System;

namespace HBSIS.Livraria.Domain
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Name{ get; set; }

        public string Category { get; set; }
    }
}
