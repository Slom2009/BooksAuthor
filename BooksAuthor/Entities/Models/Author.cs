using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        [BsonId]
        public Guid Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
