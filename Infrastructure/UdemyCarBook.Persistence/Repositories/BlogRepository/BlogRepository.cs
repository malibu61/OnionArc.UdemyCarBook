﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<Blog> AllBlogsWithAuthor()
        {
            var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).ToList();
            return values;
        }

        public Blog GetBlogAndAuthorByBlogId(int id)
        {
            var values = _context.Blogs.Include(x => x.Author).Where(x => x.BlogID == id).FirstOrDefault();
            return values;
        }

        public List<Blog> GetBlogByAuthorId(int id)
        {
            var values = _context.Blogs.Include(x => x.Author).Include(x => x.Category).Where(x => x.AuthorID == id).ToList();
            return values;
        }

        public List<Blog> Last3BlogsWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).OrderByDescending(x => x.BlogID).Take(3).ToList();
            return values;
        }
    }
}
