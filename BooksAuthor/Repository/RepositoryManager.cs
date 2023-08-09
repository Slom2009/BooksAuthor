using Contracts;
using Entities.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager :IRepositoryManager
    {
        private readonly IMongoDatabase _database;
        private IRepository<Book> _bookRepository;
        private IRepository<Author> _authorRepository;

        public RepositoryManager(IMongoDatabase database)
        {
            _database = database;
        }

        public IRepository<Book> BookRepository => _bookRepository ??= new BookRepository(_database);
        public IRepository<Author> AuthorRepository => _authorRepository ??= new AuthorRepository(_database);
    }
}
