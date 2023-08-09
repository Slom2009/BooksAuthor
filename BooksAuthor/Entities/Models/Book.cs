using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
    }
}
