using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetEntityById(Guid id);
        Task AddEntity(T author);
        Task<bool> UpdateEntity(T author);
        Task<bool> DeleteEntity(Guid id);
    }
}
