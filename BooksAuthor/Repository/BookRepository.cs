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
    public class BookRepository : IRepository<Book>
    {
        private readonly IMongoCollection<Book> _bookCollection;

        public BookRepository(IMongoDatabase database)
        {
            _bookCollection = database.GetCollection<Book>("Books");
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _bookCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Book> GetEntityById(Guid id)
        {
            return await _bookCollection.Find(book => book.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddEntity(Book book)
        {
            await _bookCollection.InsertOneAsync(book);
        }

        public async Task<bool> UpdateEntity(Book book)
        {
            var updateResult = await _bookCollection.ReplaceOneAsync(a => a.Id == book.Id, book);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            var deleteResult = await _bookCollection.DeleteOneAsync(book => book.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
