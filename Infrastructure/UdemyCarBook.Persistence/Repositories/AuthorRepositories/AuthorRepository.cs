using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.AuthorInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.AuthorRepositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly CarBookContext _context;

        public AuthorRepository(CarBookContext context)
        {
            _context = context;
        }

        public int AuthorCount()
        {
            return _context.Authors.Count();
        }
    }
}
