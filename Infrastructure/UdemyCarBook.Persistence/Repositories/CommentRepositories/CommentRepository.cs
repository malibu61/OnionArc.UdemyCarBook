using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.RepositoryDesign;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository<T> : IGenericRepository<Comment>
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public void Create(Comment entity)
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var values = _context.Comments.Select(x => new Comment()
            {
                CommentID = x.CommentID,
                BlogID = x.BlogID,
                CreatedDate = x.CreatedDate,
                Description = x.Description,
                Email = x.Email,
                Name = x.Name
            }).ToList();
            return values;
        }

        public Comment GetById(int id)
        {
            var values = _context.Comments.Find(id);
            return values;
        }

        public void Remove(int id)
        {
            var values = _context.Comments.Find(id);
            _context.Comments.Remove(values);
            _context.SaveChanges();
        }

        public void Update(Comment entity)
        {
            _context.Comments.Update(entity);
            _context.SaveChanges();
        }
    }
}
