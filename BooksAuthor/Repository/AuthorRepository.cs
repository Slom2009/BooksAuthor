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
    public class AuthorRepository : IRepository<Author>
    {
        private readonly IMongoCollection<Author> _authorCollection;

        public AuthorRepository(IMongoDatabase database)
        {
            _authorCollection = database.GetCollection<Author>("Authors");
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _authorCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Author> GetEntityById(Guid id)
        {
            return await _authorCollection.Find(author => author.Id == id).FirstOrDefaultAsync();
        }

        public async Task AddEntity(Author author)
        {
            await _authorCollection.InsertOneAsync(author);
        }

        public async Task<bool> UpdateEntity(Author author)
        {
            var updateResult = await _authorCollection.ReplaceOneAsync(a => a.Id == author.Id, author);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteEntity(Guid id)
        {
            var deleteResult = await _authorCollection.DeleteOneAsync(author => author.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
